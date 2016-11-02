using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace frontend.Domain
{
    public class Cargo
    {
        public int Cargo_id { get; set; }
        public int Sensor_id { get; set; }
        public float Weight { get; set; }
        //[JsonProperty("cargos_exceedings")]
        public List<ExceedingPerCargo> Exceedings { get; set; }
        //[JsonProperty("cargos_borders")]
        public List<CargoBorder> Borders { get; set; }
    }
}
