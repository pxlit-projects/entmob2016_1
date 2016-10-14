using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Domain
{
    public class ProductsPerCargo
    {
        public ProductsPerCargoPK id { get; set; }
        public Product product { get; set; }
        public Cargo cargo { get; set; }
        public int amount { get; set; }
    }
}
