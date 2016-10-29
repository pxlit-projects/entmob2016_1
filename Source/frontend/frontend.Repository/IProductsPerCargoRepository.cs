using frontend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Repository
{
    public interface IProductsPerCargoRepository
    {
        Task<List<ProductPerCargo>> GetAllProductsPerCargos();
        Task<ProductPerCargo> GetProductsPerCargoById(int cargo_id, int product_id);
        void AddProductsPerCargo(ProductPerCargo productsPerCargo);
    }
}
