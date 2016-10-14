using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Domain
{
    public class SensorUsage
    {
        public int sensor_usage_id { get; set; }
        public Employee employee { get; set; }
        public Sensor sensor { get; set; }
        public DateTime employee_start { get; set; }
        public DateTime employee_end { get; set; }
    }
}
