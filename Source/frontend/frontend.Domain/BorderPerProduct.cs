using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Domain
{
    public class BorderPerProduct
    {
        public BorderPerProductPK Id { get; set; }
        public Product Product { get; set; }
        public Variable Variable { get; set; }
        public float Border_value_number { get; set; }
    }
}

