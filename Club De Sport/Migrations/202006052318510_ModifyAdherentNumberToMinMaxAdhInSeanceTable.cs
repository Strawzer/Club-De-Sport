namespace Club_De_Sport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyAdherentNumberToMinMaxAdhInSeanceTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Seances", "MaxAdh", c => c.Byte(nullable: false));
            AddColumn("dbo.Seances", "MinAdh", c => c.Byte(nullable: false));
            DropColumn("dbo.Seances", "NombreAdh");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Seances", "NombreAdh", c => c.Byte(nullable: false));
            DropColumn("dbo.Seances", "MinAdh");
            DropColumn("dbo.Seances", "MaxAdh");
        }
    }
}
