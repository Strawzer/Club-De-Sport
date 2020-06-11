namespace Club_De_Sport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activites",
                c => new
                    {
                        CodeActivite = c.Byte(nullable: false),
                        Nom = c.String(),
                        Prix = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CoachId = c.Int(nullable: false),
                        SeanceId = c.Int(nullable: false),
                        Coach_CodeCoach = c.Int(),
                        Seance_CodeSeance = c.Int(),
                    })
                .PrimaryKey(t => t.CodeActivite)
                .ForeignKey("dbo.Coaches", t => t.Coach_CodeCoach)
                .ForeignKey("dbo.Seances", t => t.Seance_CodeSeance)
                .Index(t => t.Coach_CodeCoach)
                .Index(t => t.Seance_CodeSeance);
            
            CreateTable(
                "dbo.Coaches",
                c => new
                    {
                        CodeCoach = c.Int(nullable: false, identity: true),
                        Cin = c.String(),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Sexe = c.String(),
                        Adresse = c.String(),
                        Ville = c.String(),
                        Tel = c.String(),
                        TelUrgence = c.String(),
                        SeanceId = c.Int(nullable: false),
                        Seance_CodeSeance = c.Int(),
                    })
                .PrimaryKey(t => t.CodeCoach)
                .ForeignKey("dbo.Seances", t => t.Seance_CodeSeance)
                .Index(t => t.Seance_CodeSeance);
            
            CreateTable(
                "dbo.Seances",
                c => new
                    {
                        CodeSeance = c.Int(nullable: false, identity: true),
                        NombreAdh = c.Byte(nullable: false),
                        DebutSeance = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CodeSeance);
            
            CreateTable(
                "dbo.Adherents",
                c => new
                    {
                        CodeAdh = c.Int(nullable: false, identity: true),
                        Cin = c.String(),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Sexe = c.String(),
                        Adresse = c.String(),
                        Ville = c.String(),
                        Tel = c.String(nullable: false),
                        CNE = c.String(),
                        TelUrgence = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CodeAdh);
            
            CreateTable(
                "dbo.Salles",
                c => new
                    {
                        CodeSalle = c.Byte(nullable: false),
                        Discipline = c.String(),
                        SeanceId = c.Int(nullable: false),
                        Seance_CodeSeance = c.Int(),
                    })
                .PrimaryKey(t => t.CodeSalle)
                .ForeignKey("dbo.Seances", t => t.Seance_CodeSeance)
                .Index(t => t.Seance_CodeSeance);
            
            CreateTable(
                "dbo.AdherentSeances",
                c => new
                    {
                        Adherent_CodeAdh = c.Int(nullable: false),
                        Seance_CodeSeance = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Adherent_CodeAdh, t.Seance_CodeSeance })
                .ForeignKey("dbo.Adherents", t => t.Adherent_CodeAdh, cascadeDelete: true)
                .ForeignKey("dbo.Seances", t => t.Seance_CodeSeance, cascadeDelete: true)
                .Index(t => t.Adherent_CodeAdh)
                .Index(t => t.Seance_CodeSeance);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Salles", "Seance_CodeSeance", "dbo.Seances");
            DropForeignKey("dbo.Coaches", "Seance_CodeSeance", "dbo.Seances");
            DropForeignKey("dbo.AdherentSeances", "Seance_CodeSeance", "dbo.Seances");
            DropForeignKey("dbo.AdherentSeances", "Adherent_CodeAdh", "dbo.Adherents");
            DropForeignKey("dbo.Activites", "Seance_CodeSeance", "dbo.Seances");
            DropForeignKey("dbo.Activites", "Coach_CodeCoach", "dbo.Coaches");
            DropIndex("dbo.AdherentSeances", new[] { "Seance_CodeSeance" });
            DropIndex("dbo.AdherentSeances", new[] { "Adherent_CodeAdh" });
            DropIndex("dbo.Salles", new[] { "Seance_CodeSeance" });
            DropIndex("dbo.Coaches", new[] { "Seance_CodeSeance" });
            DropIndex("dbo.Activites", new[] { "Seance_CodeSeance" });
            DropIndex("dbo.Activites", new[] { "Coach_CodeCoach" });
            DropTable("dbo.AdherentSeances");
            DropTable("dbo.Salles");
            DropTable("dbo.Adherents");
            DropTable("dbo.Seances");
            DropTable("dbo.Coaches");
            DropTable("dbo.Activites");
        }
    }
}
