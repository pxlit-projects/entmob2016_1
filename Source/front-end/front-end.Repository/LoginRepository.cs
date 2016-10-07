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
    public class LoginRepository
    {
        public HttpClient Client { get; set; }

        public LoginRepository()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8080/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Login>> GetAllLogins()
        {
            var url = "/logins/all";
            HttpResponseMessage response = await Client.GetAsync(url);
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var logins = JsonConvert.DeserializeObject<IEnumerable<Login>>(jsonString);
            return logins;
        }

        public async Task<Login> GetLoginById(int id)
        {
            var url = "/logins/get/" + id;
            HttpResponseMessage response = await Client.GetAsync(url);
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var login = JsonConvert.DeserializeObject<Login>(jsonString);
            return login;
        }

        public async void AddLogin(Login login)
        {
            var url = "/logins/add";
            var jsonString = JsonConvert.SerializeObject(login);
            var content = new StringContent(jsonString);
            await Client.PostAsync(url, content);
        }

        public async void UpdateLogin(Login login)
        {
            var url = "/logins/update/" + login.Login_id;
            var jsonString = JsonConvert.SerializeObject(login);
            var content = new StringContent(jsonString);
            await Client.PutAsync(url, content);
        }

        public async void DeleteLogin(int id)
        {
            var url = "/logins/delete/" + id;
            await Client.DeleteAsync(url);
        }
    }
}
