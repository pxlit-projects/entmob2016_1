using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Domain
{
    public class Employee
    {
        public int employee_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string salt { get; set; }
        public string surName { get; set; }
        public string name { get; set; }
        public string street { get; set; }
        public string houseNr { get; set; }
        public City city { get; set; }
        public DateTime date_employement { get; set; }
        public string mobile_phone { get; set; }
        public string telephone_number { get; set; }
        public string email { get; set; }
        public string sex { get; set; }
        public bool status { get; set; }
    }
}
