namespace Club_De_Sport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectMultiplicityOfRelationCoachActivity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Coaches", "Activite_CodeActivite", "dbo.Activites");
            DropForeignKey("dbo.Activites", "Coach_CodeCoach", "dbo.Coaches");
            DropForeignKey("dbo.Coaches", "Activite_CodeActivite1", "dbo.Activites");
            DropIndex("dbo.Activites", new[] { "Coach_CodeCoach" });
            DropIndex("dbo.Coaches", new[] { "Activite_CodeActivite" });
            DropIndex("dbo.Coaches", new[] { "Activite_CodeActivite1" });
            CreateTable(
                "dbo.CoachActivites",
                c => new
                    {
                        Coach_CodeCoach = c.Int(nullable: false),
                        Activite_CodeActivite = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => new { t.Coach_CodeCoach, t.Activite_CodeActivite })
                .ForeignKey("dbo.Coaches", t => t.Coach_CodeCoach, cascadeDelete: true)
                .ForeignKey("dbo.Activites", t => t.Activite_CodeActivite, cascadeDelete: true)
                .Index(t => t.Coach_CodeCoach)
                .Index(t => t.Activite_CodeActivite);
            
            DropColumn("dbo.Activites", "Coach_CodeCoach");
            DropColumn("dbo.Coaches", "Activite_CodeActivite");
            DropColumn("dbo.Coaches", "Activite_CodeActivite1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Coaches", "Activite_CodeActivite1", c => c.Byte());
            AddColumn("dbo.Coaches", "Activite_CodeActivite", c => c.Byte());
            AddColumn("dbo.Activites", "Coach_CodeCoach", c => c.Int());
            DropForeignKey("dbo.CoachActivites", "Activite_CodeActivite", "dbo.Activites");
            DropForeignKey("dbo.CoachActivites", "Coach_CodeCoach", "dbo.Coaches");
            DropIndex("dbo.CoachActivites", new[] { "Activite_CodeActivite" });
            DropIndex("dbo.CoachActivites", new[] { "Coach_CodeCoach" });
            DropTable("dbo.CoachActivites");
            CreateIndex("dbo.Coaches", "Activite_CodeActivite1");
            CreateIndex("dbo.Coaches", "Activite_CodeActivite");
            CreateIndex("dbo.Activites", "Coach_CodeCoach");
            AddForeignKey("dbo.Coaches", "Activite_CodeActivite1", "dbo.Activites", "CodeActivite");
            AddForeignKey("dbo.Activites", "Coach_CodeCoach", "dbo.Coaches", "CodeCoach");
            AddForeignKey("dbo.Coaches", "Activite_CodeActivite", "dbo.Activites", "CodeActivite");
        }
    }
}
