using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace front_end.Domain
{
    public class Destination
    {
        public int Destination_id { get; set; }
        public City City { get; set; }
        public string Housenr { get; set; }
        public string Description { get; set; }
    }
}
