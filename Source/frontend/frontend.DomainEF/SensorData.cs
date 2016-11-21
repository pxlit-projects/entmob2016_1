using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace frontend.DomainEF
{
    [Table("sensor_data")]
    public class SensorData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("sensor_data_id")]
        public int Sensor_data_id { get; set; }

        [Column("time")]
        public DateTime Time { get; set; }

        [Column("temperature")]
        public float Temperature { get; set; }

        [Column("humidity")]
        public float Humidity { get; set; }

        [Column("pressure")]
        public float Pressure { get; set; }

        [Column("acceleration")]
        public float Acceleration { get; set; }

        [Column("magnetism")]
        public float Magnetism { get; set; }

        [Column("gyroscope")]
        public float Gyroscope { get; set; }

        [Column("light")]
        public float Light { get; set; }

        [ForeignKey("Sensor")]
        [Column("sensor_id")]
        public int Sensor_id { get; set; }

        public virtual Sensor Sensor { get; set; }
    }
}
