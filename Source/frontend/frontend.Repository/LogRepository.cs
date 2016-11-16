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
        private HttpClient client;

        public LogRepository(string username, string password)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(Global.IP_ADRESS);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", username, password))));
        }

        public async Task<List<Log>> GetAllLogs()
        {
            var url = "/logs/all";
            HttpResponseMessage response = client.GetAsync(url).Result;
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var logs = JsonConvert.DeserializeObject<List<Log>>(jsonString);
            if (logs != null)
            {
                return logs;
            }
            else
            {
                return new List<Log>();
            }
        }
    }
}
