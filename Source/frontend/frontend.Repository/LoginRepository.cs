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
    public class LoginRepository : ILoginRepository
    {
        public HttpClient Client { get; set; }

        public LoginRepository()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(Global.IP_ADRESS);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Login>> GetAllLogins()
        {
            var url = "/logins/all";
            HttpResponseMessage response = Client.GetAsync(url).Result;
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
            HttpResponseMessage response = Client.GetAsync(url).Result;
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
            await Client.PostAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }

        public async void UpdateLogin(Login login)
        {
            var url = "/logins/update/" + login.login_id;
            var jsonString = JsonConvert.SerializeObject(login);
            await Client.PutAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }

        public async void DeleteLogin(int id)
        {
            var url = "/logins/delete/" + id;
            await Client.DeleteAsync(url);
        }
    }
}
