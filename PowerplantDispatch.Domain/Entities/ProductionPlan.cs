using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerplantDispatch.Domain.Entities
{
    public class ProductionPlan
    {
        public decimal Load { get; set; }
        public Fuel Fuels { get; set; } = new Fuel();
        public List<PowerPlant> PowerPlants { get; set; } = new List<PowerPlant>();
    }
}
