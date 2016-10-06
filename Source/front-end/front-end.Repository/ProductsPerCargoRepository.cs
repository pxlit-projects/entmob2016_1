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
    public class ProductsPerCargoRepository
    {
        public HttpClient Client { get; set; }

        public ProductsPerCargoRepository()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<ProductsPerCargo>> GetAllProductsPerCargos()
        {
            var url = "/productPerCargos/all";
            HttpResponseMessage response = await Client.GetAsync(url);
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var productsPerCargos = JsonConvert.DeserializeObject<IEnumerable<ProductsPerCargo>>(jsonString);
            return productsPerCargos;
        }

        public async Task<ProductsPerCargo> GetProductsPerCargoById(int id)
        {
            var url = "/productPerCargos/get/" + id;
            HttpResponseMessage response = await Client.GetAsync(url);
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var productPerCargo = JsonConvert.DeserializeObject<ProductsPerCargo>(jsonString);
            return productPerCargo;
        }

        public async void AddProductsPerCargo(ProductsPerCargo productsPerCargo)
        {
            var url = "/productPerCargos/add";
            var jsonString = JsonConvert.SerializeObject(productsPerCargo);
            var content = new StringContent(jsonString);
            await Client.PostAsync(url, content);
        }

        public async void UpdateProductsPerCargo(ProductsPerCargo productsPerCargo)
        {
            var url = "/cities/update/" + productsPerCargo.Id;
            var jsonString = JsonConvert.SerializeObject(productsPerCargo);
            var content = new StringContent(jsonString);
            await Client.PutAsync(url, content);
        }

        public async void DeleteProductsPerCargo(int id)
        {
            var url = "/productsPerCargo/delete/" + id;
            await Client.DeleteAsync(url);
        }
    }
}
