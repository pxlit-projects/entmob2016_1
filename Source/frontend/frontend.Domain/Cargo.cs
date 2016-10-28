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
        public Sensor Sensor { get; set; }
        public Destination Destination { get; set; }
        public float Weight { get; set; }
        public List<ProductPerCargo> Products { get; set; }
        public List<ExceedingPerCargo> Exceedings { get; set; }
        public List<StabilisationPerCargo> Stabilisations { get; set; }
    }
}
