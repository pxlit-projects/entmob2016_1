namespace frontend.DomainEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExceedingsPerCargoTableNameFix : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.exceeding_per_cargo", newName: "exceedings_per_cargo");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.exceedings_per_cargo", newName: "exceeding_per_cargo");
        }
    }
}
