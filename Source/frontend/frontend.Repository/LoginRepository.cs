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

        public IEmployeeRepository EmployeeRepository { get; set; }

        public LoginRepository()
        {
            EmployeeRepository = new EmployeeRepository();
            Client = new HttpClient();
            Client.BaseAddress = new Uri(Global.IP_ADRESS);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Login>> GetAllLogins()
        {
            var employees = await EmployeeRepository.GetAllEmployees();
            List<Login> logins = new List<Login>();
            employees.ForEach(e => e.Logins.ForEach(l => logins.Add(l)));
            return logins;
        }

        public async Task<Login> GetLoginById(int id)
        {
            var logins = await GetAllLogins();
            var login = logins.FirstOrDefault(l => l.Login_id == id);
            return login;
        }

        public async void AddLogin(Login login)
        {
            var employee = await EmployeeRepository.GetEmployeeById(login.Employee.Employee_id);
            employee.Logins.Add(login);
            EmployeeRepository.UpdateEmployee(employee);
        }
    }
}
