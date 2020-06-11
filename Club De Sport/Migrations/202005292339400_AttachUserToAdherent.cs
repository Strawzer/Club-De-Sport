namespace Club_De_Sport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AttachUserToAdherent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adherents", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Adherents", "UserId");
            AddForeignKey("dbo.Adherents", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Adherents", "UserId", "dbo.Users");
            DropIndex("dbo.Adherents", new[] { "UserId" });
            DropColumn("dbo.Adherents", "UserId");
        }
    }
}
