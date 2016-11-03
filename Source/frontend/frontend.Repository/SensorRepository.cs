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

        public SensorRepository(string username, string password)
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(Global.IP_ADRESS);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", username, password))));
        }

        public async Task<List<Sensor>> GetAllSensors()
        {
            var url = "/sensors/all";
            HttpResponseMessage response = Client.GetAsync(url).Result;
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var sensors = JsonConvert.DeserializeObject<List<Sensor>>(jsonString);
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

        public void AddSensor(Sensor sensor)
        {
            var url = "/sensors/add";
            var jsonString = JsonConvert.SerializeObject(sensor);
            HttpResponseMessage response = Client.PostAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json")).Result;
        }

        public void UpdateSensor(Sensor sensor)
        {
            var url = "/sensors/update";
            var jsonString = JsonConvert.SerializeObject(sensor);
            HttpResponseMessage response = Client.PutAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json")).Result;
        }
    }
}
