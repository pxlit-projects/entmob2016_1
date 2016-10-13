using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace front_end.Domain
{
    public class StabilisationsPerCargo
    {
        public int stabilisations_per_cargo_id { get; set; }
        public ExceedingsPerCargo exceedingsPerCargo { get; set; }
        public DateTime time { get; set; }
    }
}
