using System.Data.Entity;

namespace Club_De_Sport.Models
{
    public class ClubDbContext : DbContext
    {
        public ClubDbContext() : base("ClubDB")
        {

        }

        public DbSet<Activite> Activites { get; set; }
        public DbSet<Adherent> Adherents { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Salle> Salles { get; set; }
        public DbSet<Seance> Seances { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }
    }
}
