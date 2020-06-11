namespace Club_De_Sport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class errorcorrectionInActivities : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Coaches", "ActiviteId", c => c.Int());
            AddColumn("dbo.Coaches", "Activite_CodeActivite", c => c.Byte());
            AddColumn("dbo.Coaches", "Activite_CodeActivite1", c => c.Byte());
            CreateIndex("dbo.Coaches", "Activite_CodeActivite");
            CreateIndex("dbo.Coaches", "Activite_CodeActivite1");
            AddForeignKey("dbo.Coaches", "Activite_CodeActivite", "dbo.Activites", "CodeActivite");
            AddForeignKey("dbo.Coaches", "Activite_CodeActivite1", "dbo.Activites", "CodeActivite");
            DropColumn("dbo.Activites", "CoachId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Activites", "CoachId", c => c.Int());
            DropForeignKey("dbo.Coaches", "Activite_CodeActivite1", "dbo.Activites");
            DropForeignKey("dbo.Coaches", "Activite_CodeActivite", "dbo.Activites");
            DropIndex("dbo.Coaches", new[] { "Activite_CodeActivite1" });
            DropIndex("dbo.Coaches", new[] { "Activite_CodeActivite" });
            DropColumn("dbo.Coaches", "Activite_CodeActivite1");
            DropColumn("dbo.Coaches", "Activite_CodeActivite");
            DropColumn("dbo.Coaches", "ActiviteId");
        }
    }
}
