using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace frontend.Domain
{
    public class Log
    {
        [JsonProperty("log_id")]
        public int Log_id { get; set; }
        [JsonProperty("time")]
        public string Time { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
