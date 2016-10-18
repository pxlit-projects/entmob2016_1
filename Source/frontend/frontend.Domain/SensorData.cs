using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Domain
{
    public class SensorData
    {
        public int sensor_data_id { get; set; }
        public DateTime time { get; set; }
        public double temperature { get; set; }
        public double humidity { get; set; }
        public double baroMeter { get; set; }
        public double acceleroMeter { get; set; }
        public double magnetMeter { get; set; }
        public double gyroscoop { get; set; }
        public double lightsensor { get; set; }
    }
}
