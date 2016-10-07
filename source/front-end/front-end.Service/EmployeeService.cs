using front_end.Repository;
using front_end.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace front_end.Services
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

        public void Delete(int id)
        {
            employeeRepository.DeleteEmployee(id);
        }

        public Employee Find(int id)
        {
            return employeeRepository.GetEmployeeById(id).Result;
        }

        public void Update(Employee employee)
        {
            employeeRepository.UpdateEmployee(employee);
        }
    }
}
