using frontend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Service
{
    public class ProductService : IProductService
    {
        private ProductRepository productRepository;

        public ProductService()
        {
            productRepository = new ProductRepository();
        }

        public void Add(Product product)
        {
            productRepository.AddProduct(product);
        }

        public List<Product> All()
        {
            return productRepository.GetAllProducts().Result.ToList();
        }

        public void Delete(int id)
        {
            productRepository.DeleteProduct(id);
        }

        public Product Find(int id)
        {
            return productRepository.GetProductById(id).Result;
        }

        public void Update(Product product)
        {
            productRepository.UpdateProduct(product);
        }
        public void ChangeStatus(Product product)
        {
            if (product.status == true)
            {
                product.status = false;

            }
            else
            {
                product.status = true;
            }
            productRepository.UpdateProduct(product);
        }
    }
}
