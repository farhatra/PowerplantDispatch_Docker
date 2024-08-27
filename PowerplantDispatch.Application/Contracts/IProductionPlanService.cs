using PowerplantDispatch.Domain.Entities;

namespace PowerplantDispatch.Application.Contracts
{
    public interface IProductionPlanService
    {
        Task<List<PowerOutput>> CalculateProductionPlanAsync(ProductionPlan productionPlan);
    }
}

