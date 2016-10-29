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

        public ProductPerCargo Find(int cargo_id, int product_id)
        {
            return productsPerCargoRepository.GetProductsPerCargoById(cargo_id, product_id).Result;
        }
    }
}
