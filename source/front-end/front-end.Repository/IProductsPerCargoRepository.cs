using front_end.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace front_end.Repository
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
