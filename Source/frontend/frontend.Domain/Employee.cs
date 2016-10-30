using frontend.Domain.Converter;
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
        public string Street { get; set; }
        public string HouseNr { get; set; }
        public City City { get; set; }
        public string Date_employment { get; set; }
        public string Mobile_phone { get; set; }
        public string Telephone_number { get; set; }
        public string Email { get; set; }
        public string Sex { get; set; }
        public bool Status { get; set; }
        public List<Login> Logins { get; set; }
        public List<SensorUsage> Usages { get; set; }
    }
}
