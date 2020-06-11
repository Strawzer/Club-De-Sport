namespace Club_De_Sport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeAllForeighKeysNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Activites", "CoachId", c => c.Int());
            AlterColumn("dbo.Activites", "SeanceId", c => c.Int());
            AlterColumn("dbo.Salles", "SeanceId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Salles", "SeanceId", c => c.Int(nullable: false));
            AlterColumn("dbo.Activites", "SeanceId", c => c.Int(nullable: false));
            AlterColumn("dbo.Activites", "CoachId", c => c.Int(nullable: false));
        }
    }
}
