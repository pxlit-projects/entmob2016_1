using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using frontend.Domain;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace frontend.Repository
{
    public class LogRepository : ILogRepository
    {
        public HttpClient Client { get; set; }

        public LogRepository(string username, string password)
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(Global.IP_ADRESS);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", username, password))));
        }

        public async Task<List<Log>> GetAllLogs()
        {
            var url = "/logs/all";
            HttpResponseMessage response = Client.GetAsync(url).Result;
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var logs = JsonConvert.DeserializeObject<List<Log>>(jsonString);
            return logs;
        }
    }
}
