using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerplantDispatch.Domain.Entities
{
    public class PowerOutput
    {
        public string Name { get; set; } = string.Empty;
        public decimal P { get; set; } // the amount of power to be produced by the power plant
    }
}
