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
    public class EmployeeRepository : IEmployeeRepository
    {
        public HttpClient Client { get; set; }

        public EmployeeRepository()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8080/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            var url = "/employees/all";
            HttpResponseMessage response = await Client.GetAsync(url);
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
            HttpResponseMessage response = await Client.GetAsync(url);
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
            var content = new StringContent(jsonString);
            await Client.PostAsync(url, content);
        }

        public async void UpdateEmployee(Employee employee)
        {
            var url = "/cities/update/" + employee.Employee_id;
            var jsonString = JsonConvert.SerializeObject(employee);
            var content = new StringContent(jsonString);
            await Client.PutAsync(url, content);
        }

        public async void DeleteEmployee(int id)
        {
            var url = "/employees/delete/" + id;
            await Client.DeleteAsync(url);
        }
    }
}
