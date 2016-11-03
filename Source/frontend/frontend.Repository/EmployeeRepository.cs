using frontend.Domain;
using frontend.Domain.Converter;
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
        public HttpClient Client { get; set; }

        public EmployeeRepository(string username, string password)
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(Global.IP_ADRESS);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", username, password))));
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            var url = "/employees/all";
            HttpResponseMessage response = Client.GetAsync(url).Result;
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }
            
            var employees = JsonConvert.DeserializeObject<List<Employee>>(jsonString);
            return employees;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var url = "/employees/get/" + id;
            HttpResponseMessage response = Client.GetAsync(url).Result;
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
            HttpResponseMessage response = Client.GetAsync(url).Result;
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
            HttpResponseMessage response = Client.PostAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json")).Result;
        }

        public void UpdateEmployee(Employee employee)
        {
            var url = "/employees/update";
            var jsonString = JsonConvert.SerializeObject(employee);
            HttpResponseMessage response = Client.PutAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json")).Result;
        }
    }
}
