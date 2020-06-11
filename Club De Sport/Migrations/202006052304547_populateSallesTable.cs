namespace Club_De_Sport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateSallesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.Salles (CodeSalle, Discipline) VALUES" +
                "(1, 'Musculation et Cardio')," +
                "(2, 'Danse')," +
                "(3, 'Aerobic')," +
                "(4, 'Arts Martiaux')," +
                "(5, 'Piscine');" );
        }
        
        public override void Down()
        {
            Sql("SELETE FROM dbo.Salles;");
        }
    }
}
