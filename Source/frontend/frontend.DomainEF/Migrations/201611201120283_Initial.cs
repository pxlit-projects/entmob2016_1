namespace frontend.DomainEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.cargo_borders",
                c => new
                    {
                        cargo_border_id = c.Int(nullable: false, identity: true),
                        value = c.Single(nullable: false),
                        variable_id = c.Int(nullable: false),
                        Cargo_Cargo_id = c.Int(),
                    })
                .PrimaryKey(t => t.cargo_border_id)
                .ForeignKey("dbo.cargos", t => t.Cargo_Cargo_id)
                .ForeignKey("dbo.variables", t => t.variable_id, cascadeDelete: true)
                .Index(t => t.variable_id)
                .Index(t => t.Cargo_Cargo_id);
            
            CreateTable(
                "dbo.cargos",
                c => new
                    {
                        cargo_id = c.Int(nullable: false, identity: true),
                        sensor_id = c.Int(nullable: false),
                        weight = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.cargo_id);
            
            CreateTable(
                "dbo.exceeding_per_cargo",
                c => new
                    {
                        exceeding_per_cargo_id = c.Int(nullable: false, identity: true),
                        cargo_id = c.Int(nullable: false),
                        variable_id = c.Int(nullable: false),
                        value = c.Single(nullable: false),
                        time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.exceeding_per_cargo_id)
                .ForeignKey("dbo.cargos", t => t.cargo_id, cascadeDelete: true)
                .ForeignKey("dbo.variables", t => t.variable_id, cascadeDelete: true)
                .Index(t => t.cargo_id)
                .Index(t => t.variable_id);
            
            CreateTable(
                "dbo.variables",
                c => new
                    {
                        variable_id = c.Int(nullable: false, identity: true),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.variable_id);
            
            CreateTable(
                "dbo.employees",
                c => new
                    {
                        employee_id = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        password = c.String(),
                        salt = c.String(),
                        surName = c.String(),
                        name = c.String(),
                        status = c.Boolean(nullable: false),
                        clearance = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.employee_id);
            
            CreateTable(
                "dbo.logs",
                c => new
                    {
                        log_id = c.Int(nullable: false, identity: true),
                        time = c.DateTime(nullable: false),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.log_id);
            
            CreateTable(
                "dbo.sensor_data",
                c => new
                    {
                        sensor_data_id = c.Int(nullable: false, identity: true),
                        time = c.DateTime(nullable: false),
                        temperature = c.Single(nullable: false),
                        humidity = c.Single(nullable: false),
                        pressure = c.Single(nullable: false),
                        acceleration = c.Single(nullable: false),
                        magnetism = c.Single(nullable: false),
                        gyroscope = c.Single(nullable: false),
                        light = c.Single(nullable: false),
                        sensor_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.sensor_data_id)
                .ForeignKey("dbo.sensors", t => t.sensor_id, cascadeDelete: true)
                .Index(t => t.sensor_id);
            
            CreateTable(
                "dbo.sensors",
                c => new
                    {
                        sensor_id = c.Int(nullable: false, identity: true),
                        sensor_name = c.String(),
                        status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.sensor_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.sensor_data", "sensor_id", "dbo.sensors");
            DropForeignKey("dbo.cargo_borders", "variable_id", "dbo.variables");
            DropForeignKey("dbo.exceeding_per_cargo", "variable_id", "dbo.variables");
            DropForeignKey("dbo.exceeding_per_cargo", "cargo_id", "dbo.cargos");
            DropForeignKey("dbo.cargo_borders", "Cargo_Cargo_id", "dbo.cargos");
            DropIndex("dbo.sensor_data", new[] { "sensor_id" });
            DropIndex("dbo.exceeding_per_cargo", new[] { "variable_id" });
            DropIndex("dbo.exceeding_per_cargo", new[] { "cargo_id" });
            DropIndex("dbo.cargo_borders", new[] { "Cargo_Cargo_id" });
            DropIndex("dbo.cargo_borders", new[] { "variable_id" });
            DropTable("dbo.sensors");
            DropTable("dbo.sensor_data");
            DropTable("dbo.logs");
            DropTable("dbo.employees");
            DropTable("dbo.variables");
            DropTable("dbo.exceeding_per_cargo");
            DropTable("dbo.cargos");
            DropTable("dbo.cargo_borders");
        }
    }
}
