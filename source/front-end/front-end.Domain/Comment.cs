using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace front_end.Domain
{
    public class Comment
    {
        public int comment_id { get; set; }
        public Employee employee { get; set; }
        public Sensor sensor { get; set; }
        public Cargo cargo { get; set; }
        public string description { get; set; }
        public DateTime time { get; set; }
    }
}
