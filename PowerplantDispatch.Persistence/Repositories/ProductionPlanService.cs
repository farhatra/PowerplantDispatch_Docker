using PowerplantDispatch.Application.Contracts;
using PowerplantDispatch.Domain.Entities;

namespace PowerplantDispatch.Persistence.Repositories
{
    public class ProductionPlanService : IProductionPlanService
    {
        public async Task<List<PowerOutput>> CalculateProductionPlanAsync(ProductionPlan productionPlan)
        {
            var powerOutputs = new List<PowerOutput>();

            // Calculate the cost of generating power for each powerplant
            var powerPlantsWithCost = productionPlan.PowerPlants.Select(pp => new
            {
                PowerPlant = pp,
                Cost = CalculateCost(pp, productionPlan.Fuels)
            })
            .OrderBy(x => x.Cost)
            .ToList();

            decimal remainingLoad = productionPlan.Load;

            // Iterate over the sorted power plants and allocate power to meet the load
            foreach (var ppWithCost in powerPlantsWithCost)
            {
                var powerPlant = ppWithCost.PowerPlant;
                var pMin = powerPlant.Pmin;
                var pMax = powerPlant.Pmax;

                // Skip wind turbines if wind is 0%
                if (powerPlant.Type == "windturbine" && productionPlan.Fuels.WindPercentage == 0)
                {
                    continue;
                }

                // Wind turbines' max output depends on wind percentage
                if (powerPlant.Type == "windturbine")
                {
                    pMax = pMax * productionPlan.Fuels.WindPercentage / 100;
                }

                decimal powerToProduce = 0;

                // Allocate power
                if (remainingLoad >= pMin)
                {
                    powerToProduce = Math.Min(remainingLoad, pMax);
                }
                else if (remainingLoad > 0)
                {
                    powerToProduce = remainingLoad;
                }

                if (powerToProduce > 0)
                {
                    remainingLoad -= powerToProduce;
                    powerOutputs.Add(new PowerOutput
                    {
                        Name = powerPlant.Name,
                        P = powerToProduce
                    });
                }

                // If we've met the load, break out of the loop
                if (remainingLoad <= 0)
                {
                    break;
                }
            }

            // If we couldn't meet the load, throw an exception
            if (remainingLoad > 0)
            {
                throw new InvalidOperationException("Unable to meet the required load with the available powerplants.");
            }

            return await Task.FromResult(powerOutputs);
        }

        private decimal CalculateCost(PowerPlant powerPlant, Fuel fuels)
        {
            decimal costPerMWh;

            switch (powerPlant.Type)
            {
                case "gasfired":
                    costPerMWh = fuels.GasCost / powerPlant.Efficiency;
                    break;
                case "turbojet":
                    costPerMWh = fuels.KerosineCost / powerPlant.Efficiency;
                    break;
                case "windturbine":
                    costPerMWh = 0; // Wind is free
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unknown powerplant type");
            }

            return costPerMWh;
        }
    }
}
