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
        private HttpClient client;

        public SensorRepository(string username, string password)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(Global.IP_ADRESS);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", username, password))));
        }

        public async Task<List<Sensor>> GetAllSensors()
        {
            var url = "/sensors/all";
            HttpResponseMessage response = client.GetAsync(url).Result;
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var sensors = JsonConvert.DeserializeObject<List<Sensor>>(jsonString);
            if (sensors != null)
            {
                return sensors;
            }
            else
            {
                return new List<Sensor>();
            }
        }

        public async Task<Sensor> GetSensorById(int id)
        {
            var url = "/sensors/get/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
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
            HttpResponseMessage response = client.PostAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json")).Result;
        }

        public void UpdateSensor(Sensor sensor)
        {
            var url = "/sensors/update";
            var jsonString = JsonConvert.SerializeObject(sensor);
            HttpResponseMessage response = client.PutAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json")).Result;
        }
    }
}
