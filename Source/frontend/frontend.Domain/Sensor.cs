using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Domain
{
    public class Sensor
    {
        public int Sensor_id { get; set; }
        public string Sensor_name { get; set; }
        public bool Status { get; set; }
        public List<SensorUsage> Usages { get; set; }
        public List<SensorData> Data { get; set; }
    }
}
