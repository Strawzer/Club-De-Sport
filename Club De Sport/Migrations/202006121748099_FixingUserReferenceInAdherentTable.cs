namespace Club_De_Sport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingUserReferenceInAdherentTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Activites", "Adherent_CodeAdh", "dbo.Adherents");
            DropForeignKey("dbo.AdherentSeances", "Adherent_CodeAdh", "dbo.Adherents");
            DropForeignKey("dbo.Users", "Adherent_CodeAdh", "dbo.Adherents");
            DropIndex("dbo.Users", new[] { "Adherent_CodeAdh" });
            DropColumn("dbo.Adherents", "CodeAdh");
            RenameColumn(table: "dbo.Adherents", name: "Adherent_CodeAdh", newName: "CodeAdh");
            DropPrimaryKey("dbo.Adherents");
            AddColumn("dbo.Adherents", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Adherents", "CodeAdh", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Adherents", "CodeAdh");
            CreateIndex("dbo.Adherents", "CodeAdh");
            AddForeignKey("dbo.Activites", "Adherent_CodeAdh", "dbo.Adherents", "CodeAdh");
            AddForeignKey("dbo.AdherentSeances", "Adherent_CodeAdh", "dbo.Adherents", "CodeAdh", cascadeDelete: true);
            DropColumn("dbo.Users", "Adherent_CodeAdh");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Adherent_CodeAdh", c => c.Int());
            DropForeignKey("dbo.AdherentSeances", "Adherent_CodeAdh", "dbo.Adherents");
            DropForeignKey("dbo.Activites", "Adherent_CodeAdh", "dbo.Adherents");
            DropIndex("dbo.Adherents", new[] { "CodeAdh" });
            DropPrimaryKey("dbo.Adherents");
            AlterColumn("dbo.Adherents", "CodeAdh", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Adherents", "UserId");
            AddPrimaryKey("dbo.Adherents", "CodeAdh");
            RenameColumn(table: "dbo.Adherents", name: "CodeAdh", newName: "Adherent_CodeAdh");
            AddColumn("dbo.Adherents", "CodeAdh", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.Users", "Adherent_CodeAdh");
            AddForeignKey("dbo.Users", "Adherent_CodeAdh", "dbo.Adherents", "CodeAdh");
            AddForeignKey("dbo.AdherentSeances", "Adherent_CodeAdh", "dbo.Adherents", "CodeAdh", cascadeDelete: true);
            AddForeignKey("dbo.Activites", "Adherent_CodeAdh", "dbo.Adherents", "CodeAdh");
        }
    }
}
