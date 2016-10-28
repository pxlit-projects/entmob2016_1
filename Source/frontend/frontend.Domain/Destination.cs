using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Domain
{
    public class Destination
    {
        public int Destination_id { get; set; }
        public City City { get; set; }
        public string Housenr { get; set; }
        public string Street { get; set; }
        public string Description { get; set; }
        public List<Cargo> Cargos { get; set; }
    }
}
