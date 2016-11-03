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
        [JsonProperty("cargo_border_id")]
        public int Cargo_border_id { get; set; }
        [JsonProperty("value")]
        public float Value { get; set; }
        [JsonProperty("cargo")]
        public Cargo Cargo { get; set; }
        [JsonProperty("variable")]
        public Variable Variable { get; set; }
    }
}
