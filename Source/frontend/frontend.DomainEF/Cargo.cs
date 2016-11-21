using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace frontend.DomainEF
{
    [Table("cargos")]
    public class Cargo
    {
        // Fluent API -->
        public int Cargo_id { get; set; }

        [Column("sensor_id")]
        public int Sensor_id { get; set; }

        [Column("weight")]
        public float Weight { get; set; }

        public virtual ICollection<ExceedingPerCargo> Exceedings { get; set; }

        public virtual ICollection<CargoBorder> Borders { get; set; }
    }
}
