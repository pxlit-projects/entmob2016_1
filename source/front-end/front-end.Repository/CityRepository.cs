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
    public class CityRepository : ICityRepository
    {
        public HttpClient Client { get; set; }

        public CityRepository()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8080/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<City>> GetAllCities()
        {
            var url = "/cities/all";
            HttpResponseMessage response = Client.GetAsync(url).Result;
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var cities = JsonConvert.DeserializeObject<IEnumerable<City>>(jsonString);
            return cities;
        }

        public async Task<City> GetCityById(int id)
        {
            var url = "/cities/get/" + id;
            HttpResponseMessage response = Client.GetAsync(url).Result;
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var city = JsonConvert.DeserializeObject<City>(jsonString);
            return city;
        }

        public async void AddCity(City city)
        {
            var url = "/cities/add";
            var jsonString = JsonConvert.SerializeObject(city);
            await Client.PostAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }

        public async void UpdateCity(City city)
        {
            var url = "/cities/update/" + city.postal_code;
            var jsonString = JsonConvert.SerializeObject(city);
            await Client.PutAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }

        public async void DeleteCity(int id)
        {
            var url = "/cities/delete/" + id;
            await Client.DeleteAsync(url);
        }
    }
}
