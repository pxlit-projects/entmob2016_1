using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Domain
{
    public class BordersPerProduct
    {
        public BordersPerProductPK id { get; set; }
        public Product product { get; set; }
        public Variable variable { get; set; }
        public float border_value_number { get; set; }
    }
}

