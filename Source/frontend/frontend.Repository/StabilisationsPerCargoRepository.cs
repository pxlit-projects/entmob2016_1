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
    public class StabilisationsPerCargoRepository : IStabilisationsPerCargoRepository
    {
        public HttpClient Client { get; set; }

        public StabilisationsPerCargoRepository()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(Global.IP_ADRESS);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<StabilisationPerCargo>> GetAllStabilisationsPerCargos()
        {
            var url = "/stabilisationspercargos/all";
            HttpResponseMessage response = Client.GetAsync(url).Result;
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var stabilisationsPerCargos = JsonConvert.DeserializeObject<IEnumerable<StabilisationPerCargo>>(jsonString);
            return stabilisationsPerCargos;
        }

        public async Task<StabilisationPerCargo> GetStabilisationsPerCargoById(int id)
        {
            var url = "/stabilisationspercargos/get/" + id;
            HttpResponseMessage response = Client.GetAsync(url).Result;
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var stabilisationsPerCargo = JsonConvert.DeserializeObject<StabilisationPerCargo>(jsonString);
            return stabilisationsPerCargo;
        }

        public async void AddStabilisationsPerCargo(StabilisationPerCargo stabilisationsPerCargo)
        {
            var url = "/stabilisationspercargos/add";
            var jsonString = JsonConvert.SerializeObject(stabilisationsPerCargo);
            await Client.PostAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }

        public async void UpdateStabilisationsPerCargo(StabilisationPerCargo stabilisationsPerCargo)
        {
            var url = "/stabilisationspercargos/update";
            var jsonString = JsonConvert.SerializeObject(stabilisationsPerCargo);
            await Client.PutAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }

        public async void DeleteStabilisationsPerCargo(int id)
        {
            var url = "/stabilisationspercargos/delete/" + id;
            await Client.DeleteAsync(url);
        }
    }
}
