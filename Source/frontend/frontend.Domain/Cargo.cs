using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace frontend.Domain
{
    public class Cargo
    {
        [JsonProperty("cargo_id")]
        public int Cargo_id { get; set; }
        [JsonProperty("sensor_id")]
        public int Sensor_id { get; set; }
        [JsonProperty("weight")]
        public float Weight { get; set; }
        [JsonProperty("exceedings")]
        public List<ExceedingPerCargo> Exceedings { get; set; }
        [JsonProperty("borders")]
        public List<CargoBorder> Borders { get; set; }
    }
}
