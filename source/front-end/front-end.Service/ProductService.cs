using front_end.Repository;
using front_end.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace front_end.Services
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
            if (product.Status==true)
            {
                product.Status = false;

            } else
            {
                product.Status = true;
            }
            productRepository.UpdateProduct(product);
        }
    }
}
