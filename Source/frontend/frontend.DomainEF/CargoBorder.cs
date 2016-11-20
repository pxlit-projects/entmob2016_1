using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.DomainEF
{
    [Table("cargo_borders")]
    public class CargoBorder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("cargo_border_id")]
        public int Cargo_border_id { get; set; }

        [Column("value")]
        public float Value { get; set; }

        [Column("cargo")]
        public Cargo Cargo { get; set; }

        [ForeignKey("Variable")]
        [Column("variable_id")]
        public int Variable_id { get; set; }
        
        public virtual Variable Variable { get; set; }
    }
}
