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
    public class EmployeeRepository : IEmployeeRepository
    {
        public HttpClient Client { get; set; }

        public EmployeeRepository()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(Global.IP_ADRESS);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            var url = "/employees/all";
            HttpResponseMessage response = Client.GetAsync(url).Result;
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var employees = JsonConvert.DeserializeObject<IEnumerable<Employee>>(jsonString);
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

        public async void AddEmployee(Employee employee)
        {
            var url = "/employees/add";
            var jsonString = JsonConvert.SerializeObject(employee);
            await Client.PostAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }

        public async void UpdateEmployee(Employee employee)
        {
            var url = "/cities/update/" + employee.employee_id;
            var jsonString = JsonConvert.SerializeObject(employee);
            await Client.PutAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }

        public async void DeleteEmployee(int id)
        {
            var url = "/employees/delete/" + id;
            await Client.DeleteAsync(url);
        }
    }
}
