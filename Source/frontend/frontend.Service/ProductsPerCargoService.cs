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

        public void Add(ProductsPerCargo productsPerCargo)
        {
            productsPerCargoRepository.AddProductsPerCargo(productsPerCargo);
        }

        public List<ProductsPerCargo> All()
        {
            return productsPerCargoRepository.GetAllProductsPerCargos().Result.ToList();
        }

        public void Delete(int id)
        {
            productsPerCargoRepository.DeleteProductsPerCargo(id);
        }

        public ProductsPerCargo Find(int id)
        {
            return productsPerCargoRepository.GetProductsPerCargoById(id).Result;
        }

        public void Update(ProductsPerCargo productsPerCargo)
        {
            productsPerCargoRepository.UpdateProductsPerCargo(productsPerCargo);
        }
    }
}
