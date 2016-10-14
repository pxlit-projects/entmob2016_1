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
        public int sensor_id { get; set; }
        public string sensor_name { get; set; }
        public bool status { get; set; }
        public ObservableCollection<SensorUsage> cargos { get; set; }
    }
}
