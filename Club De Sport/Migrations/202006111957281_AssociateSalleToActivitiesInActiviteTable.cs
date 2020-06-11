namespace Club_De_Sport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssociateSalleToActivitiesInActiviteTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activites", "SalleId", c => c.Int());
            AddColumn("dbo.Activites", "Salle_CodeSalle", c => c.Byte());
            CreateIndex("dbo.Activites", "Salle_CodeSalle");
            AddForeignKey("dbo.Activites", "Salle_CodeSalle", "dbo.Salles", "CodeSalle");

            Sql("UPDATE dbo.Activites SET SalleId = 2 WHERE CodeActivite = 1;");
            Sql("UPDATE dbo.Activites SET SalleId = 2 WHERE CodeActivite = 2;");
            Sql("UPDATE dbo.Activites SET SalleId = 2 WHERE CodeActivite = 3;");
            Sql("UPDATE dbo.Activites SET SalleId = 2 WHERE CodeActivite = 4;");
            Sql("UPDATE dbo.Activites SET SalleId = 3 WHERE CodeActivite = 5;");
            Sql("UPDATE dbo.Activites SET SalleId = 3 WHERE CodeActivite = 6;");
            Sql("UPDATE dbo.Activites SET SalleId = 3 WHERE CodeActivite = 7;");
            Sql("UPDATE dbo.Activites SET SalleId = 3 WHERE CodeActivite = 8;");
            Sql("UPDATE dbo.Activites SET SalleId = 3 WHERE CodeActivite = 9;");
            Sql("UPDATE dbo.Activites SET SalleId = 4 WHERE CodeActivite = 10;");
            Sql("UPDATE dbo.Activites SET SalleId = 4 WHERE CodeActivite = 11;");
            Sql("UPDATE dbo.Activites SET SalleId = 4 WHERE CodeActivite = 12;");
            Sql("UPDATE dbo.Activites SET SalleId = 4 WHERE CodeActivite = 13;");
            Sql("UPDATE dbo.Activites SET SalleId = 1 WHERE CodeActivite = 14;");
            Sql("UPDATE dbo.Activites SET SalleId = 1 WHERE CodeActivite = 15;");
            Sql("UPDATE dbo.Activites SET SalleId = 5 WHERE CodeActivite = 16;");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activites", "Salle_CodeSalle", "dbo.Salles");
            DropIndex("dbo.Activites", new[] { "Salle_CodeSalle" });
            DropColumn("dbo.Activites", "Salle_CodeSalle");
            DropColumn("dbo.Activites", "SalleId");
        }
    }
}
