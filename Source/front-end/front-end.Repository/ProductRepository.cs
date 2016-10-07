using front_end.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace front_end.Repository
{
    public class ProductRepository
    {
        public HttpClient Client { get; set; }

        public ProductRepository()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8080/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var url = "/products/all";
            HttpResponseMessage response = await Client.GetAsync(url);
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(jsonString);
            return products;
        }

        public async Task<Product> GetProductById(int id)
        {
            var url = "/products/get/" + id;
            HttpResponseMessage response = await Client.GetAsync(url);
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var product = JsonConvert.DeserializeObject<Product>(jsonString);
            return product;
        }

        public async void AddProduct(Product product)
        {
            var url = "/products/add";
            var jsonString = JsonConvert.SerializeObject(product);
            var content = new StringContent(jsonString);
            await Client.PostAsync(url, content);
        }

        public async void UpdateProduct(Product product)
        {
            var url = "/products/update/" + product.Product_id;
            var jsonString = JsonConvert.SerializeObject(product);
            var content = new StringContent(jsonString);
            await Client.PutAsync(url, content);
        }

        public async void DeleteProduct(int id)
        {
            var url = "/products/delete/" + id;
            await Client.DeleteAsync(url);
        }
    }
}
