namespace Club_De_Sport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AttachUserToAdherent1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Adherents", "UserId", "dbo.Users");
            DropIndex("dbo.Adherents", new[] { "UserId" });
            AddColumn("dbo.Users", "AdherentId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Adherent_CodeAdh", c => c.Int());
            CreateIndex("dbo.Users", "Adherent_CodeAdh");
            AddForeignKey("dbo.Users", "Adherent_CodeAdh", "dbo.Adherents", "CodeAdh");
            DropColumn("dbo.Adherents", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Adherents", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Users", "Adherent_CodeAdh", "dbo.Adherents");
            DropIndex("dbo.Users", new[] { "Adherent_CodeAdh" });
            DropColumn("dbo.Users", "Adherent_CodeAdh");
            DropColumn("dbo.Users", "AdherentId");
            CreateIndex("dbo.Adherents", "UserId");
            AddForeignKey("dbo.Adherents", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
