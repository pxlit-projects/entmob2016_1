using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace frontend.Domain
{
    public class CargoBorder
    {
        public int Cargo_border_id { get; set; }
        public float Value { get; set; }
        //[JsonProperty("cargos_borders")]
        public Cargo Cargo { get; set; }
        public Variable Variable { get; set; }
    }
}
