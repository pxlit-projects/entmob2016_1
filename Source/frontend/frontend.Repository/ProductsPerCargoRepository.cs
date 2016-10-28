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
    public class ProductsPerCargoRepository : IProductsPerCargoRepository
    {
        public HttpClient Client { get; set; }

        public ProductsPerCargoRepository()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(Global.IP_ADRESS);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<ProductPerCargo>> GetAllProductsPerCargos()
        {
            var url = "/productPerCargos/all";
            HttpResponseMessage response = Client.GetAsync(url).Result;
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var productsPerCargos = JsonConvert.DeserializeObject<IEnumerable<ProductPerCargo>>(jsonString);
            return productsPerCargos;
        }

        public async Task<ProductPerCargo> GetProductsPerCargoById(int id)
        {
            var url = "/productPerCargos/get/" + id;
            HttpResponseMessage response = Client.GetAsync(url).Result;
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var productPerCargo = JsonConvert.DeserializeObject<ProductPerCargo>(jsonString);
            return productPerCargo;
        }

        public async void AddProductsPerCargo(ProductPerCargo productsPerCargo)
        {
            var url = "/productPerCargos/add";
            var jsonString = JsonConvert.SerializeObject(productsPerCargo);
            await Client.PostAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }

        public async void UpdateProductsPerCargo(ProductPerCargo productsPerCargo)
        {
            var url = "/cities/update";
            var jsonString = JsonConvert.SerializeObject(productsPerCargo);
            await Client.PutAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }

        public async void DeleteProductsPerCargo(int id)
        {
            var url = "/productsPerCargo/delete/" + id;
            await Client.DeleteAsync(url);
        }
    }
}
