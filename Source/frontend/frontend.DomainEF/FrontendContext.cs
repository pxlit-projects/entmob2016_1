using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.DomainEF
{
    public class FrontendContext : DbContext
    {
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<CargoBorder> CargoBorders { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ExceedingPerCargo> ExceedingsPerCargo { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<SensorData> SensorDatas { get; set; }
        public DbSet<Variable> Variables { get; set; }

        public FrontendContext() : base("name=FrontendDBConnectionString")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cargo>()
                .HasKey<int>(c => c.Cargo_id)
                .Property(c => c.Cargo_id)
                .HasColumnName("cargo_id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Employee>()
                .HasKey<int>(e => e.Employee_id)
                .Property(e => e.Employee_id)
                .HasColumnName("employee_id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Sensor>()
                .HasKey<int>(s => s.Sensor_id)
                .Property(s => s.Sensor_id)
                .HasColumnName("sensor_id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Variable>()
                .HasKey<int>(v => v.Variable_id)
                .Property(v => v.Variable_id)
                .HasColumnName("variable_id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
