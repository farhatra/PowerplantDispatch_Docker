using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerplantDispatch.Domain.Entities
{
    public class PowerPlant
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; //(can be enum) gasfired, turbojet, or windturbine
        public decimal Efficiency { get; set; }
        public decimal Pmin { get; set; }
        public decimal Pmax { get; set; }
    }
}
