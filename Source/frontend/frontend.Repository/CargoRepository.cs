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
    public class CargoRepository : ICargoRepository
    {
        public HttpClient Client { get; set; }

        public CargoRepository(string username, string password)
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(Global.IP_ADRESS);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic", 
                Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", username, password))));
        }

        public async Task<List<Cargo>> GetAllCargos()
        {
            var url = "/cargos/all";
            HttpResponseMessage response = Client.GetAsync(url).Result;
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var cargos = JsonConvert.DeserializeObject<List<Cargo>>(jsonString);
            return cargos;
        }

        public async Task<Cargo> GetCargoById(int id)
        {
            var url = "/cargos/get/" + id;
            HttpResponseMessage response = Client.GetAsync(url).Result;
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var cargo = JsonConvert.DeserializeObject<Cargo>(jsonString);
            return cargo;
        }

        public async void AddCargo(Cargo cargo)
        {
            var url = "/cargos/add";
            var jsonString = JsonConvert.SerializeObject(cargo);
            await Client.PostAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }

        public async void UpdateCargo(Cargo cargo)
        {
            var url = "/cargos/update";
            var jsonString = JsonConvert.SerializeObject(cargo);
            await Client.PutAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }
    }
}
