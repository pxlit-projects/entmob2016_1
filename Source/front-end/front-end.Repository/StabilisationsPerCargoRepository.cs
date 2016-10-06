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
    public class StabilisationsPerCargoRepository
    {
        public HttpClient Client { get; set; }

        public StabilisationsPerCargoRepository()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<StabilisationsPerCargo>> GetAllStabilisationsPerCargos()
        {
            var url = "/stabilisationspercargos/all";
            HttpResponseMessage response = await Client.GetAsync(url);
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var stabilisationsPerCargos = JsonConvert.DeserializeObject<IEnumerable<StabilisationsPerCargo>>(jsonString);
            return stabilisationsPerCargos;
        }

        public async Task<StabilisationsPerCargo> GetStabilisationsPerCargoById(int id)
        {
            var url = "/stabilisationspercargos/get/" + id;
            HttpResponseMessage response = await Client.GetAsync(url);
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var stabilisationsPerCargo = JsonConvert.DeserializeObject<StabilisationsPerCargo>(jsonString);
            return stabilisationsPerCargo;
        }

        public async void AddStabilisationsPerCargo(StabilisationsPerCargo stabilisationsPerCargo)
        {
            var url = "/stabilisationspercargos/add";
            var jsonString = JsonConvert.SerializeObject(stabilisationsPerCargo);
            var content = new StringContent(jsonString);
            await Client.PostAsync(url, content);
        }

        public async void UpdateStabilisationsPerCargo(StabilisationsPerCargo stabilisationsPerCargo)
        {
            var url = "/stabilisationspercargos/update/" + stabilisationsPerCargo.Stabilisations_per_cargo_id;
            var jsonString = JsonConvert.SerializeObject(stabilisationsPerCargo);
            var content = new StringContent(jsonString);
            await Client.PutAsync(url, content);
        }

        public async void DeleteStabilisationsPerCargo(int id)
        {
            var url = "/stabilisationspercargos/delete/" + id;
            await Client.DeleteAsync(url);
        }
    }
}
