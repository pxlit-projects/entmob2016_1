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
        private HttpClient client;

        public CargoRepository(string username, string password)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(Global.IP_ADRESS);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic", 
                Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", username, password))));
        }

        public async Task<List<Cargo>> GetAllCargos()
        {
            var url = "/cargos/all";
            HttpResponseMessage response = client.GetAsync(url).Result;
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var cargos = JsonConvert.DeserializeObject<List<Cargo>>(jsonString);
            if (cargos != null)
            {
                return cargos;
            }
            else
            {
                return new List<Cargo>();
            }
        }

        public async Task<Cargo> GetCargoById(int id)
        {
            var url = "/cargos/get/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var cargo = JsonConvert.DeserializeObject<Cargo>(jsonString);
            return cargo;
        }

        public void AddCargo(Cargo cargo)
        {
            var url = "/cargos/add";
            var jsonString = JsonConvert.SerializeObject(cargo);
            HttpResponseMessage response = client.PostAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json")).Result;
        }

        public void UpdateCargo(Cargo cargo)
        {
            var url = "/cargos/update";
            var jsonString = JsonConvert.SerializeObject(cargo);
            HttpResponseMessage response = client.PutAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json")).Result;
        }
    }
}
