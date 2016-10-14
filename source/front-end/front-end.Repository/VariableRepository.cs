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
    public class VariableRepository : IVariableRepository
    {
        public HttpClient Client { get; set; }

        public VariableRepository()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(Global.IP_ADRESS);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Variable>> GetAllVariables()
        {
            var url = "/variables/all";
            HttpResponseMessage response = Client.GetAsync(url).Result;
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var variables = JsonConvert.DeserializeObject<IEnumerable<Variable>>(jsonString);
            return variables;
        }

        public async Task<Variable> GetVariableById(int id)
        {
            var url = "/variables/get/" + id;
            HttpResponseMessage response = Client.GetAsync(url).Result;
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var variable = JsonConvert.DeserializeObject<Variable>(jsonString);
            return variable;
        }

        public async void AddVariable(Variable variable)
        {
            var url = "/variables/add";
            var jsonString = JsonConvert.SerializeObject(variable);
            await Client.PostAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }

        public async void UpdateVariable(Variable variable)
        {
            var url = "/variables/update/" + variable.variable_id;
            var jsonString = JsonConvert.SerializeObject(variable);
            await Client.PutAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }

        public async void DeleteVariable(int id)
        {
            var url = "/variables/delete/" + id;
            await Client.DeleteAsync(url);
        }
    }
}
