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
    public class SensorUsageRepository : ISensorUsageRepository
    {
        public HttpClient Client { get; set; }

        public SensorUsageRepository()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(Global.IP_ADRESS);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<SensorUsage>> GetAllSensorUsages()
        {
            var url = "/sensorusages/all";
            HttpResponseMessage response = Client.GetAsync(url).Result;
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var sensorUsages = JsonConvert.DeserializeObject<IEnumerable<SensorUsage>>(jsonString);
            return sensorUsages;
        }

        public async Task<SensorUsage> GetSensorUsageById(int id)
        {
            var url = "/sensorusages/get/" + id;
            HttpResponseMessage response = Client.GetAsync(url).Result;
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var sensorUsage = JsonConvert.DeserializeObject<SensorUsage>(jsonString);
            return sensorUsage;
        }

        public async void AddSensorUsage(SensorUsage sensorUsage)
        {
            var url = "/sensorusages/add";
            var jsonString = JsonConvert.SerializeObject(sensorUsage);
            await Client.PostAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }

        public async void UpdateSensorUsage(SensorUsage sensorUsage)
        {
            var url = "/sensorusages/update/" + sensorUsage.sensor_usage_id;
            var jsonString = JsonConvert.SerializeObject(sensorUsage);
            await Client.PutAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }

        public async void DeleteSensorUsage(int id)
        {
            var url = "/sensorusages/delete/" + id;
            await Client.DeleteAsync(url);
        }
    }
}
