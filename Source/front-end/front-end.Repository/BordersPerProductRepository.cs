using front_end.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace front_end.Repository
{
    public class BordersPerProductRepository
    {
        public HttpClient Client { get; set; }

        public BordersPerProductRepository()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<BordersPerProduct>> GetBordersPerProduct()
        {
            var url = "/bordersperproducts/all";
            HttpResponseMessage response = await Client.GetAsync(url);
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var bordersPerProducts = JsonConvert.DeserializeObject<IEnumerable<BordersPerProduct>>(jsonString);
            return bordersPerProducts;
        }
    }
}
