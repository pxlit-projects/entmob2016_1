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
        [JsonProperty("employee_id")]
        public int Employee_id { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("salt")]
        public string Salt { get; set; }
        [JsonProperty("surName")]
        public string SurName { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("status")]
        public bool Status { get; set; }
        [JsonProperty("clearance")]
        public Role Clearance { get; set; }
    }
}
