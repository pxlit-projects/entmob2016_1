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
        Task<IEnumerable<ProductPerCargo>> GetAllProductsPerCargos();
        Task<ProductPerCargo> GetProductsPerCargoById(int id);
        void AddProductsPerCargo(ProductPerCargo productsPerCargo);
        void UpdateProductsPerCargo(ProductPerCargo productsPerCargo);
        void DeleteProductsPerCargo(int id);
    }
}
