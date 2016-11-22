using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace frontend.Domain
{
    public class ExceedingPerCargo
    {
        [JsonIgnore]
        public int Exceeding_per_cargo_id { get; set; }
        [JsonIgnore]
        public Cargo Cargo { get; set; }
        [JsonProperty("variable")]
        public Variable Variable { get; set; }
        [JsonProperty("value")]
        public float Value { get; set; }
        [JsonProperty("time")]
        public string Time { get; set; }
    }
}
