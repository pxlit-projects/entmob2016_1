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
        List<ProductPerCargo> All();
        ProductPerCargo Find(int id);
        void Add(ProductPerCargo productsPerCargo);
    }
}
