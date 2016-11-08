using frontend.Domain;
using frontend.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Service
{
    public class EmployeeService : IEmployeeService
    {
        private EmployeeRepository employeeRepository;

        public EmployeeService()
        {
        }

        public EmployeeService(string username, string password)
        {
            employeeRepository = new EmployeeRepository(username, password);
        }

        public void Add(Employee employee)
        {
            employeeRepository.AddEmployee(employee);
        }

        public List<Employee> All()
        {
            var employees = employeeRepository.GetAllEmployees().Result.ToList();
            if (employees != null)
            {
                return employees;
            }
            else
            {
                return new List<Employee>();
            }
        }
        
        public Employee Find(int id)
        {
            var employee = employeeRepository.GetEmployeeById(id).Result;
            if (employee != null)
            {
                return employee;
            }
            else
            {
                return new Employee();
            }
        }

        public Employee FindByUsername(String username) {
            var employee = employeeRepository.GetEmployeeByUsername(username).Result;
            if (employee != null)
            {
                return employee;
            }
            else
            {
                return new Employee();
            }
        }

        public void Update(Employee employee)
        {
            employeeRepository.UpdateEmployee(employee);
        }
    }
}
