using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace frontend.DomainEF
{
    [Table("logs")]
    public class Log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("log_id")]
        public int Log_id { get; set; }

        [Column("time")]
        public DateTime Time { get; set; }

        [Column("Message")]
        public string Message { get; set; }
    }
}
