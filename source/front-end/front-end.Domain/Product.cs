using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace front_end.Domain
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
