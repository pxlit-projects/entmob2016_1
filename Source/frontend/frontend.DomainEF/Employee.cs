using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace frontend.DomainEF
{
    [Table("employees")]
    public class Employee
    {
        // Fluent API -->
        public int Employee_id { get; set; }
        
        [Column("username")]
        public string Username { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("salt")]
        public string Salt { get; set; }

        [Column("surName")]
        public string SurName { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("status")]
        public bool Status { get; set; }

        [Column("clearance")]
        public Role Clearance { get; set; }
    }
}
