using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Domain
{
    public class Variable
    {
        public int Variable_id { get; set; }
        public string Description { get; set; }
        public List<ExceedingPerCargo> Exceedings { get; set; }
        public List<CargoBorder> Borders { get; set; }
    }
}
