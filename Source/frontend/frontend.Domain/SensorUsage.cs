using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Domain
{
    public class SensorUsage
    {
        public int Sensor_usage_id { get; set; }
        public Employee Employee { get; set; }
        public Sensor Sensor { get; set; }
        public DateTime Employee_start { get; set; }
        public DateTime Employee_end { get; set; }
    }
}
