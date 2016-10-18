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
        Task<IEnumerable<ProductsPerCargo>> GetAllProductsPerCargos();
        Task<ProductsPerCargo> GetProductsPerCargoById(int id);
        void AddProductsPerCargo(ProductsPerCargo productsPerCargo);
        void UpdateProductsPerCargo(ProductsPerCargo productsPerCargo);
        void DeleteProductsPerCargo(int id);
    }
}
