namespace Club_De_Sport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCoachsTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Coaches", "SeanceId", c => c.Int());
            Sql("INSERT INTO dbo.Coaches" +
                "(Cin, Nom, Prenom, Sexe, Adresse, Ville, Tel, TelUrgence)" +
                "VALUES" +
                "(" +
                "'AD230405'," +
                "'LAAREJ'," +
                "'Kamal'," +
                "'Masculin'," +
                "'15 Avenue Annakhil Hay Riad'," +
                "'Rabat'," +
                "'0607080919'," +
                "'0667890212')," +
                "(" +
                "'AD300400'," +
                "'HANAFI'," +
                "'Hajar'," +
                "'Feminin'," +
                "'15 Avenue de France Agdal'," +
                "'Rabat'," +
                "'0620040090'," +
                "'0630000890');"
                );
        }
        
        public override void Down()
        {
            Sql("SELETE FROM dbo.Coaches;");
            AlterColumn("dbo.Coaches", "SeanceId", c => c.Int(nullable: false));
        }
    }
}
