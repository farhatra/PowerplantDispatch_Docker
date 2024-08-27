using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerplantDispatch.Domain.Entities
{
    public class Fuel
    {
        public decimal GasCost { get; set; } // gas(euro/MWh)
        public decimal KerosineCost { get; set; } // kerosine(euro/MWh)
        public decimal Co2Cost { get; set; } // co2(euro/ton)
        public decimal WindPercentage { get; set; } // wind(%)
    }
}
