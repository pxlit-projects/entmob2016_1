using frontend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Service
{
    public interface IEmployeeService
    {
        List<Employee> All();
        Employee Find(int id);
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
    }
}
