using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace frontend.Domain
{
    public class SensorData
    {
        [JsonProperty("sensor_data_id")]
        public int Sensor_data_id { get; set; }
        [JsonProperty("time")]
        public string Time { get; set; }
        [JsonProperty("temperature")]
        public float Temperature { get; set; }
        [JsonProperty("humidity")]
        public float Humidity { get; set; }
        [JsonProperty("pressure")]
        public float Pressure { get; set; }
        [JsonProperty("acceleration")]
        public float Acceleration { get; set; }
        [JsonProperty("magnetism")]
        public float Magnetism { get; set; }
        [JsonProperty("gyroscope")]
        public float Gyroscope { get; set; }
        [JsonProperty("light")]
        public float Light { get; set; }
        [JsonProperty("sensor")]
        public Sensor Sensor { get; set; }
    }
}
