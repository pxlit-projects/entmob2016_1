using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Domain
{
    public class Login
    {
        public int Login_id { get; set; }
        public Employee Employee { get; set; }
        public DateTime Time { get; set; }
    }
}
