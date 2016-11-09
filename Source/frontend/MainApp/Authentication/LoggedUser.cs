using frontend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Authentication
{
    public class LoggedUser
    {
        public static int Employee_id { get; set; }

        public static string Username { get; set; }

        public static string Password { get; set; }

        public static string Salt { get; set; }

        public static string SurName { get; set; }

        public static string Name { get; set; }

        public static bool Status { get; set; }

        public static Role Clearance { get; set; }
    }
}
