using front_end.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace front_end.Services
{
    public interface IProductsPerCargoService
    {
        List<ProductsPerCargo> All();
        ProductsPerCargo Find(int id);
        void Add(ProductsPerCargo productsPerCargo);
        void Update(ProductsPerCargo productsPerCargo);
        void Delete(int id);
    }
}
