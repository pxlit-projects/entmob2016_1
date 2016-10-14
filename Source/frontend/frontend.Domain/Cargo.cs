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
        public int cargo_id { get; set; }
        public SensorUsage sensor_usage { get; set; }
        public Employee employee { get; set; }
        public Destination destination { get; set; }
        public float weight { get; set; }
        public ObservableCollection<ProductsPerCargo> productsPerCargos { get; set; }
        public ObservableCollection<ExceedingsPerCargo> exceedingsPerCargo { get; set; }
    }
}
