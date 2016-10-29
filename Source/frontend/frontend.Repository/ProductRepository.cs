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
    public class ProductRepository : IProductRepository
    {
        public HttpClient Client { get; set; }

        public ProductRepository()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(Global.IP_ADRESS);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var url = "/products/all";
            HttpResponseMessage response = Client.GetAsync(url).Result;
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var products = JsonConvert.DeserializeObject<List<Product>>(jsonString);
            return products;
        }

        public async Task<Product> GetProductById(int id)
        {
            var url = "/products/get/" + id;
            HttpResponseMessage response = Client.GetAsync(url).Result;
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
            await Client.PostAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }

        public async void UpdateProduct(Product product)
        {
            var url = "/products/update";
            var jsonString = JsonConvert.SerializeObject(product);
            await Client.PutAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }
    }
}
