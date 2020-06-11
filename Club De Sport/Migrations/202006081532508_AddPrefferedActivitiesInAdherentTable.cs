namespace Club_De_Sport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPrefferedActivitiesInAdherentTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activites", "Adherent_CodeAdh", c => c.Int());
            CreateIndex("dbo.Activites", "Adherent_CodeAdh");
            AddForeignKey("dbo.Activites", "Adherent_CodeAdh", "dbo.Adherents", "CodeAdh");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activites", "Adherent_CodeAdh", "dbo.Adherents");
            DropIndex("dbo.Activites", new[] { "Adherent_CodeAdh" });
            DropColumn("dbo.Activites", "Adherent_CodeAdh");
        }
    }
}
