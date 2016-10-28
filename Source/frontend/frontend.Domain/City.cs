using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Domain
{
    public class City
    {
        public string Postal_code { get; set; }
        [JsonProperty("city")]
        public string City_name { get; set; }
    }
}
