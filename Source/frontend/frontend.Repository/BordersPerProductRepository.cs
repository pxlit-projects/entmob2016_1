using frontend.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Repository
{
    public class BordersPerProductRepository : IBordersPerProductRepository
    {
        public HttpClient Client { get; set; }

        public IProductRepository ProductRepository { get; set; }

        public BordersPerProductRepository()
        {
            ProductRepository = new ProductRepository();
            Client = new HttpClient();
            Client.BaseAddress = new Uri(Global.IP_ADRESS);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<BorderPerProduct>> GetAllBordersPerProducts()
        {
            var products = await ProductRepository.GetAllProducts();
            List<BorderPerProduct> borderPerProducts = new List<BorderPerProduct>();
            products.ForEach(p => p.Borders.ForEach(b => borderPerProducts.Add(b)));
            return borderPerProducts;
        }

        public async Task<BorderPerProduct> GetBordersPerProductById(int product_id, int variable_id)
        {
            var borderPerProducts = await GetAllBordersPerProducts();
            var borderPerProduct = borderPerProducts.FirstOrDefault(b => b.Id.Product_id == product_id && b.Id.Variable_id == variable_id);
            return borderPerProduct;
        }

        public async void AddBordersPerProduct(BorderPerProduct bordersPerProduct)
        {
            var product = await ProductRepository.GetProductById(bordersPerProduct.Product.Product_id);
            product.Borders.Add(bordersPerProduct);
            ProductRepository.UpdateProduct(product);
        }
    }
}
