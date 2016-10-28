using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Domain
{
    public class StabilisationsPerCargo
    {
        public int Stabilisations_per_cargo_id { get; set; }
        public ExceedingsPerCargo ExceedingsPerCargo { get; set; }
        public DateTime Time { get; set; }
    }
}
