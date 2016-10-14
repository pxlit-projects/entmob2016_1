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
    public class ExceedingsPerCargoRepository : IExceedingsPerCargoRepository
    {
        public HttpClient Client { get; set; }

        public ExceedingsPerCargoRepository()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(Global.IP_ADRESS);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<ExceedingsPerCargo>> GetAllExceedingsPerCargos()
        {
            var url = "/exceedingsPerCargos/all";
            HttpResponseMessage response = Client.GetAsync(url).Result;
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var exceedingsPerCargos = JsonConvert.DeserializeObject<IEnumerable<ExceedingsPerCargo>>(jsonString);
            return exceedingsPerCargos;
        }

        public async Task<ExceedingsPerCargo> GetExceedingsPerCargoById(int id)
        {
            var url = "/exceedinsPerCargos/get/" + id;
            HttpResponseMessage response = Client.GetAsync(url).Result;
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var exceedingsPerCargo = JsonConvert.DeserializeObject<ExceedingsPerCargo>(jsonString);
            return exceedingsPerCargo;
        }

        public async void AddExceedingsPerCargo(ExceedingsPerCargo exceedingsPerCargo)
        {
            var url = "/exceedingsPerCargos/add";
            var jsonString = JsonConvert.SerializeObject(exceedingsPerCargo);
            await Client.PostAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }

        public async void UpdateExceedingsPerCargo(ExceedingsPerCargo exceedingsPerCargo)
        {
            var url = "/exceedingsPerCargo/update/" + exceedingsPerCargo.exceeding_per_cargo_id;
            var jsonString = JsonConvert.SerializeObject(exceedingsPerCargo);
            await Client.PutAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }

        public async void DeleteExceedingsPerCargo(int id)
        {
            var url = "/exceedingsPerCargo/delete/" + id;
            await Client.DeleteAsync(url);
        }
    }
}
