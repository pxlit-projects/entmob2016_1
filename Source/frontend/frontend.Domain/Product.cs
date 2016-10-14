using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Domain
{
    public class Product
    {
        public int product_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public bool status { get; set; }
        public List<ProductsPerCargo> products { get; set; }
    }
}
