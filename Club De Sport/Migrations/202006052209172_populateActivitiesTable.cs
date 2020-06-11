namespace Club_De_Sport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateActivitiesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.Activites(CodeActivite, Nom, Prix) VALUES" +
                "(1, 'Danse oriental' , '399.99')," +
                "(2, 'Latino' , '499.99')," +
                "(3, 'Salsa' , '399.99')," +
                "(4, 'Waltz' , '399.99')," +
                "(5, 'Zumba' , '449.99')," +
                "(6, 'Step' , '499.99')," +
                "(7, 'Stretching' , '399.99')," +
                "(8, 'Pilates' , '599.99')," +
                "(9, 'Yoga' , '599.99')," +
                "(10, 'Karaté' , '299.99')," +
                "(11, 'Kuankido' , '299.99')," +
                "(12, 'Judo' , '349.99')," +
                "(13, 'Kungfu' , '299.99')," +
                "(14, 'Cardio' , '399.99')," +
                "(15, 'Musculation' , '499.99')," +
                "(16, 'Natation' , '599.99');");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM dbo.Activites;");
        }
    }
}
