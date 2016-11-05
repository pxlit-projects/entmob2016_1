using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Domain
{
    public class Variable
    {
        [JsonProperty("variable_id")]
        public int Variable_id { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("exceedings")]
        public List<ExceedingPerCargo> Exceedings { get; set; }
        [JsonProperty("borders")]
        public List<CargoBorder> Borders { get; set; }
    }
}
