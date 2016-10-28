using frontend.Domain;
using frontend.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Service
{
    public class ProductsPerCargoService : IProductsPerCargoService
    {
        private ProductsPerCargoRepository productsPerCargoRepository;

        public ProductsPerCargoService()
        {
            productsPerCargoRepository = new ProductsPerCargoRepository();
        }

        public void Add(ProductPerCargo productsPerCargo)
        {
            productsPerCargoRepository.AddProductsPerCargo(productsPerCargo);
        }

        public List<ProductPerCargo> All()
        {
            return productsPerCargoRepository.GetAllProductsPerCargos().Result.ToList();
        }

        public void Delete(int id)
        {
            productsPerCargoRepository.DeleteProductsPerCargo(id);
        }

        public ProductPerCargo Find(int id)
        {
            return productsPerCargoRepository.GetProductsPerCargoById(id).Result;
        }

        public void Update(ProductPerCargo productsPerCargo)
        {
            productsPerCargoRepository.UpdateProductsPerCargo(productsPerCargo);
        }
    }
}
