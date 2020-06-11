namespace Club_De_Sport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixingAssociationsInSeanceTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Coaches", "Seance_CodeSeance", "dbo.Seances");
            DropForeignKey("dbo.Salles", "Seance_CodeSeance", "dbo.Seances");
            DropIndex("dbo.Coaches", new[] { "Seance_CodeSeance" });
            DropIndex("dbo.Salles", new[] { "Seance_CodeSeance" });
            AddColumn("dbo.Seances", "SalleId", c => c.Int());
            AddColumn("dbo.Seances", "CoachId", c => c.Int());
            AddColumn("dbo.Seances", "Coach_CodeCoach", c => c.Int());
            AddColumn("dbo.Seances", "Salle_CodeSalle", c => c.Byte());
            CreateIndex("dbo.Seances", "Coach_CodeCoach");
            CreateIndex("dbo.Seances", "Salle_CodeSalle");
            AddForeignKey("dbo.Seances", "Coach_CodeCoach", "dbo.Coaches", "CodeCoach");
            AddForeignKey("dbo.Seances", "Salle_CodeSalle", "dbo.Salles", "CodeSalle");
            DropColumn("dbo.Coaches", "SeanceId");
            DropColumn("dbo.Coaches", "Seance_CodeSeance");
            DropColumn("dbo.Salles", "SeanceId");
            DropColumn("dbo.Salles", "Seance_CodeSeance");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Salles", "Seance_CodeSeance", c => c.Int());
            AddColumn("dbo.Salles", "SeanceId", c => c.Int());
            AddColumn("dbo.Coaches", "Seance_CodeSeance", c => c.Int());
            AddColumn("dbo.Coaches", "SeanceId", c => c.Int());
            DropForeignKey("dbo.Seances", "Salle_CodeSalle", "dbo.Salles");
            DropForeignKey("dbo.Seances", "Coach_CodeCoach", "dbo.Coaches");
            DropIndex("dbo.Seances", new[] { "Salle_CodeSalle" });
            DropIndex("dbo.Seances", new[] { "Coach_CodeCoach" });
            DropColumn("dbo.Seances", "Salle_CodeSalle");
            DropColumn("dbo.Seances", "Coach_CodeCoach");
            DropColumn("dbo.Seances", "CoachId");
            DropColumn("dbo.Seances", "SalleId");
            CreateIndex("dbo.Salles", "Seance_CodeSeance");
            CreateIndex("dbo.Coaches", "Seance_CodeSeance");
            AddForeignKey("dbo.Salles", "Seance_CodeSeance", "dbo.Seances", "CodeSeance");
            AddForeignKey("dbo.Coaches", "Seance_CodeSeance", "dbo.Seances", "CodeSeance");
        }
    }
}
