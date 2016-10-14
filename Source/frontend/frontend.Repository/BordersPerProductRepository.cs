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

        public BordersPerProductRepository()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(Global.IP_ADRESS);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<BordersPerProduct>> GetAllBordersPerProducts()
        {
            var url = "/bordersperproducts/all";
            HttpResponseMessage response = Client.GetAsync(url).Result;
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var bordersPerProducts = JsonConvert.DeserializeObject<IEnumerable<BordersPerProduct>>(jsonString);
            return bordersPerProducts;
        }

        public async Task<BordersPerProduct> GetBordersPerProductById(int id)
        {
            var url = "/bordersperproducts/get/" + id;
            HttpResponseMessage response = Client.GetAsync(url).Result;
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var bordersPerProducts = JsonConvert.DeserializeObject<BordersPerProduct>(jsonString);
            return bordersPerProducts;
        }

        public async void AddBordersPerProduct(BordersPerProduct bordersPerProduct)
        {
            var url = "/bordersperproducts/add";
            var jsonString = JsonConvert.SerializeObject(bordersPerProduct);
            await Client.PostAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }

        public async void UpdateBordersPerProduct(BordersPerProduct bordersPerProduct)
        {
            var url = "/bordersperproducts/update/" + bordersPerProduct.id;
            var jsonString = JsonConvert.SerializeObject(bordersPerProduct);
            await Client.PutAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }

        public async void DeleteBordersPerProduct(int id)
        {
            var url = "/bordersperproducts/delete/" + id;
            await Client.DeleteAsync(url);
        }
    }
}
