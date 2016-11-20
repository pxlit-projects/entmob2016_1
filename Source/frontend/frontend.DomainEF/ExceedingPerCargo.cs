using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace frontend.DomainEF
{
    [Table("exceedings_per_cargo")]
    public class ExceedingPerCargo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("exceeding_per_cargo_id")]
        public int Exceeding_per_cargo_id { get; set; }

        [ForeignKey("Cargo")]
        [Column("cargo_id")]
        public int Cargo_id { get; set; }

        public virtual Cargo Cargo { get; set; }

        [ForeignKey("Variable")]
        [Column("variable_id")]
        public int Variable_id { get; set; }

        public virtual Variable Variable { get; set; }

        [Column("value")]
        public float Value { get; set; }

        [Column("time")]
        public DateTime Time { get; set; }
    }
}
