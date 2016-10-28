using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Domain
{
    public class Comment
    {
        public int Comment_id { get; set; }
        public Employee Employee { get; set; }
        public Sensor Sensor { get; set; }
        public Cargo Cargo { get; set; }
        public string Description { get; set; }
        public string Time { get; set; }

    }
}
