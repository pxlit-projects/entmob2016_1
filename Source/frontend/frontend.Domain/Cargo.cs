using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace frontend.Domain
{
    public class Cargo
    {
        public int Cargo_id { get; set; }
        public SensorUsage Sensor_usage { get; set; }
        public Employee Employee { get; set; }
        public Destination Destination { get; set; }
        public float Weight { get; set; }
        public ObservableCollection<ProductsPerCargo> ProductsPerCargos { get; set; }
        public ObservableCollection<ExceedingsPerCargo> ExceedingsPerCargo { get; set; }
    }
}
