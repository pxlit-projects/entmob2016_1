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
        public int Product_id { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public ObservableCollection<ProductsPerCargo> Products { get; set; }
    }
}
