using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Domain
{
    public class ExceedingPerCargo
    {
        public int Exceeding_per_cargo_id { get; set; }
        public Cargo Cargo { get; set; }
        public Variable Variable { get; set; }
        public float Value { get; set; }
        public TimeSpan time { get; set; }
    }
}
