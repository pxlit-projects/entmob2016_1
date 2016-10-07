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
    public class CargoRepository
    {
        public HttpClient Client { get; set; }

        public CargoRepository()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Cargo>> GetAllCargos()
        {
            var url = "/cargos/all";
            HttpResponseMessage response = await Client.GetAsync(url);
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var cargos = JsonConvert.DeserializeObject<IEnumerable<Cargo>>(jsonString);
            return cargos;
        }

        public async Task<Cargo> GetCargoById(int id)
        {
            var url = "/cargos/get/" + id;
            HttpResponseMessage response = await Client.GetAsync(url);
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
            var content = new StringContent(jsonString);
            await Client.PostAsync(url, content);
        }

        public async void UpdateCargo(Cargo cargo)
        {
            var url = "/cargos/update/" + cargo.Cargo_id;
            var jsonString = JsonConvert.SerializeObject(cargo);
            var content = new StringContent(jsonString);
            await Client.PutAsync(url, content);
        }

        public async void DeleteCargo(int id)
        {
            var url = "/cargos/delete/" + id;
            await Client.DeleteAsync(url);
        }
    }
}
