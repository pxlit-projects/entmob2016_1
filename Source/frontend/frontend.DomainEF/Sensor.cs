using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace frontend.DomainEF
{
    [Table("sensors")]
    public class Sensor
    {
        // Fluent API -->
        public int Sensor_id { get; set; }

        [Column("sensor_name")]
        public string Sensor_name { get; set; }

        [Column("status")]
        public bool Status { get; set; }

        public virtual ICollection<SensorData> Data { get; set; }
    }
}
