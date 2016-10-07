using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace front_end.Domain
{
    public class Sensor
    {
        public int Sensor_id { get; set; }
        public string Sensor_name { get; set; }
        public bool Status{ get; set; }
        public ObservableCollection<SensorUsage> Cargos { get; set; }
    }
}
