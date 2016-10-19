using frontend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int id);
        Task<Employee> GetEmployeeByUsername(String username);
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);
    }
}
