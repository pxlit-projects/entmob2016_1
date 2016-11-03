using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace frontend.Domain
{
    public class Sensor
    {
        [JsonProperty("sensor_id")]
        public int Sensor_id { get; set; }
        [JsonProperty("sensor_name")]
        public string Sensor_name { get; set; }
        [JsonProperty("status")]
        public bool Status { get; set; }
    }
}
