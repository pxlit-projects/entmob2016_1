using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Domain
{
    public class Login
    {
        public int login_id { get; set; }
        public Employee employee { get; set; }
        public DateTime time { get; set; }
    }
}
