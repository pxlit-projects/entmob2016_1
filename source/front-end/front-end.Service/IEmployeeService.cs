﻿using front_end.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace front_end.Services
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