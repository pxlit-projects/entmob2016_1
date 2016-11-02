﻿using frontend.Domain.Converter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Domain
{
    public class Employee
    {
        public int Employee_id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string SurName { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public Role Clearance { get; set; }
    }
}
