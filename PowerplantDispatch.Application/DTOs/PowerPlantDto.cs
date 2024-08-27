using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerplantDispatch.Application.DTOs
{
    public class PowerPlantDto
    {
        public string Name { get; set; }
        public string Type { get; set; } // gasfired, turbojet, or windturbine
        public decimal Efficiency { get; set; }
        public decimal Pmin { get; set; }
        public decimal Pmax { get; set; }
    }
}
