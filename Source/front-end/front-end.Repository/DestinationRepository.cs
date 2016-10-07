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
    public class DestinationRepository
    {
        public HttpClient Client { get; set; }

        public DestinationRepository()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8080/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Destination>> GetAllDestinations()
        {
            var url = "/destinations/all";
            HttpResponseMessage response = await Client.GetAsync(url);
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var destinations = JsonConvert.DeserializeObject<IEnumerable<Destination>>(jsonString);
            return destinations;
        }

        public async Task<Destination> GetDestinationById(int id)
        {
            var url = "/destinations/get/" + id;
            HttpResponseMessage response = await Client.GetAsync(url);
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var destination = JsonConvert.DeserializeObject<Destination>(jsonString);
            return destination;
        }

        public async void AddDestination(Destination destination)
        {
            var url = "/destinations/add";
            var jsonString = JsonConvert.SerializeObject(destination);
            var content = new StringContent(jsonString);
            await Client.PostAsync(url, content);
        }

        public async void UpdateDestination(Destination destination)
        {
            var url = "/destinations/update/" + destination.Destination_id;
            var jsonString = JsonConvert.SerializeObject(destination);
            var content = new StringContent(jsonString);
            await Client.PutAsync(url, content);
        }

        public async void DeleteDestination(int id)
        {
            var url = "/destinations/delete/" + id;
            await Client.DeleteAsync(url);
        }
    }
}
