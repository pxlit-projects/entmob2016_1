using frontend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Service
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
