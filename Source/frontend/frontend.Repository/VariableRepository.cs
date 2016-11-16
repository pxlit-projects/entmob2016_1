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
    public class VariableRepository : IVariableRepository
    {
        private HttpClient client;

        public VariableRepository(string username, string password)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(Global.IP_ADRESS);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", username, password))));
        }

        public async Task<List<Variable>> GetAllVariables()
        {
            var url = "/variables/all";
            HttpResponseMessage response = client.GetAsync(url).Result;
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var variables = JsonConvert.DeserializeObject<List<Variable>>(jsonString);
            if (variables != null)
            {
                return variables;
            }
            else
            {
                return new List<Variable>();
            }
        }

        public async Task<Variable> GetVariableById(int id)
        {
            var url = "/variables/get/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var variable = JsonConvert.DeserializeObject<Variable>(jsonString);
            return variable;
        }
    }
}
