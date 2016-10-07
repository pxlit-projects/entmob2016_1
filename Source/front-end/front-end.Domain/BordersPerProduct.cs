using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace front_end.Domain
{
    public class BordersPerProduct
    {
        public BordersPerProductPK Id { get; set; }
        public Product Product { get; set; }
        public Variable Variable { get; set; }
        public float Border_value_number { get; set; }
    }
}
