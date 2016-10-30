using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Domain
{
    public class StabilisationPerCargo
    {
        public int Stabilisations_per_cargo_id { get; set; }
        public ExceedingPerCargo ExceedingPerCargo { get; set; }
        public Cargo Cargo { get; set; }
        public string Time { get; set; }
    }
}
