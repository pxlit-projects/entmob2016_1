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
    public class SensorRepository : ISensorRepository
    {
        public HttpClient Client { get; set; }

        public SensorRepository()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(Global.IP_ADRESS);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Sensor>> GetAllSensors()
        {
            var url = "/sensors/all";
            HttpResponseMessage response = Client.GetAsync(url).Result;
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var sensors = JsonConvert.DeserializeObject<IEnumerable<Sensor>>(jsonString);
            return sensors;
        }

        public async Task<Sensor> GetSensorById(int id)
        {
            var url = "/sensors/get/" + id;
            HttpResponseMessage response = Client.GetAsync(url).Result;
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var sensor = JsonConvert.DeserializeObject<Sensor>(jsonString);
            return sensor;
        }

        public async void AddSensor(Sensor sensor)
        {
            var url = "/sensors/add";
            var jsonString = JsonConvert.SerializeObject(sensor);
            await Client.PostAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }

        public async void UpdateSensor(Sensor sensor)
        {
            var url = "/sensors/update";
            var jsonString = JsonConvert.SerializeObject(sensor);
            await Client.PutAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }

        public async void DeleteSensor(int id)
        {
            var url = "/sensors/delete/" + id;
            await Client.DeleteAsync(url);
        }
    }
}
