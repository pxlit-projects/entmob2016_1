using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace front_end.Domain
{
    public class Destination
    {
        public int destination_id { get; set; }
        public City city { get; set; }
        public string housenr { get; set; }
        public string description { get; set; }
    }
}
