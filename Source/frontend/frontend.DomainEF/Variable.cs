using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace frontend.DomainEF
{
    [Table("variables")]
    public class Variable
    {
        // Fluent API -->
        public int Variable_id { get; set; }

        [Column("description")]
        public string Description { get; set; }

        public ICollection<ExceedingPerCargo> Exceedings { get; set; }

        public ICollection<CargoBorder> Borders { get; set; }
    }
}
