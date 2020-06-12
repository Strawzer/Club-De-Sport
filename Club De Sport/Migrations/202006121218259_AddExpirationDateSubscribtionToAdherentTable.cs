namespace Club_De_Sport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExpirationDateSubscribtionToAdherentTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adherents", "ExpirationDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Adherents", "ExpirationDate");
        }
    }
}
