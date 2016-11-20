using frontend.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private HttpClient client;

        public EmployeeRepository(string username, string password)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(Global.IP_ADRESS);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (username != "" && username != null && password != "" && password != null)
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", username, password))));
            }
            else
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "joran007", "test123"))));
            }
            
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            var url = "/employees/all";
            HttpResponseMessage response = client.GetAsync(url).Result;
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }
            
            var employees = JsonConvert.DeserializeObject<List<Employee>>(jsonString);
            if (employees != null)
            {
                return employees;
            }
            else
            {
                return new List<Employee>();
            }
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var url = "/employees/get/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var employee = JsonConvert.DeserializeObject<Employee>(jsonString);
            return employee;
        }

        public async Task<Employee> GetEmployeeByUsername(String username)
        {
            var url = "/employees/get/username/" + username;
            HttpResponseMessage response = client.GetAsync(url).Result;
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var employee = JsonConvert.DeserializeObject<Employee>(jsonString);
            return employee;
        }

        public void AddEmployee(Employee employee)
        {
            var url = "/employees/add";
            var jsonString = JsonConvert.SerializeObject(employee);
            HttpResponseMessage response = client.PostAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json")).Result;
        }

        public void UpdateEmployee(Employee employee)
        {
            var url = "/employees/update";
            var jsonString = JsonConvert.SerializeObject(employee);
            HttpResponseMessage response = client.PutAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json")).Result;
        }
    }
}
