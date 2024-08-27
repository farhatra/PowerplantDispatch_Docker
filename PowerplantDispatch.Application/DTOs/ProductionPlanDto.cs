using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerplantDispatch.Application.DTOs
{
    public class ProductionPlanDto
    {
        public decimal Load { get; set; }
        public FuelDto Fuels { get; set; }
        public List<PowerPlantDto> PowerPlants { get; set; }
    }
}
