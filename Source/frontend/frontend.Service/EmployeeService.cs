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
            employeeRepository = new EmployeeRepository();
        }

        public void Add(Employee employee)
        {
            employeeRepository.AddEmployee(employee);
        }

        public List<Employee> All()
        {
            return employeeRepository.GetAllEmployees().Result.ToList();
        }
        
        public Employee Find(int id)
        {
            return employeeRepository.GetEmployeeById(id).Result;
        }

        public Employee FindByUsername(String username) {
            return employeeRepository.GetEmployeeByUsername(username).Result;
        }

        public void Update(Employee employee)
        {
            employeeRepository.UpdateEmployee(employee);
        }
    }
}
