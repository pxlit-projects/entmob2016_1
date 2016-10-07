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
    public class SensorRepository
    {
        public HttpClient Client { get; set; }

        public SensorRepository()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8080/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Sensor>> GetAllSensors()
        {
            var url = "/sensors/all";
            HttpResponseMessage response = await Client.GetAsync(url);
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
            HttpResponseMessage response = await Client.GetAsync(url);
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
            var content = new StringContent(jsonString);
            await Client.PostAsync(url, content);
        }

        public async void UpdateSensor(Sensor sensor)
        {
            var url = "/sensors/update/" + sensor.Sensor_id;
            var jsonString = JsonConvert.SerializeObject(sensor);
            var content = new StringContent(jsonString);
            await Client.PutAsync(url, content);
        }

        public async void DeleteSensor(int id)
        {
            var url = "/sensors/delete/" + id;
            await Client.DeleteAsync(url);
        }
    }
}
