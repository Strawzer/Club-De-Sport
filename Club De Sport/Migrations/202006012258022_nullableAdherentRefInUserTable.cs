namespace Club_De_Sport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullableAdherentRefInUserTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "AdherentId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "AdherentId", c => c.Int(nullable: false));
        }
    }
}
