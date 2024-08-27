using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerplantDispatch.Application.DTOs
{
    public class PowerOutputDto
    {
        public string Name { get; set; }
        public decimal P { get; set; } // the amount of power to be produced by the power plant
    }
}
