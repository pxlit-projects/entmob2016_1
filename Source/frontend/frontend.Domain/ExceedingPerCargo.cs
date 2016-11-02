using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace frontend.Domain
{
    public class ExceedingPerCargo
    {
        public int Exceeding_per_cargo_id { get; set; }
        //[JsonProperty("cargos_exceedings")]
        public Cargo Cargo { get; set; }
        public Variable Variable { get; set; }
        public float Value { get; set; }
        public string time { get; set; }
    }
}
