using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace front_end.Domain
{
    public class SensorData
    {
        public int Sensor_data_id {get;set;}
        public DateTime Time { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
       public double BaroMeter { get; set; }
        public double AcceleroMeter { get; set; }
        public double MagnetMeter { get; set; }
        public double Gyroscoop { get; set; }
        public double Lightsensor { get; set; }
    }
}
