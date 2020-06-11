using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Club_De_Sport.Models
{
    public class Seance
    {
        [Key]
        public int CodeSeance { get; set; }

        public byte MaxAdh { get; set; }

        public byte MinAdh { get; set; }

        public DateTime DebutSeance { get; set; }

        // Implementation de l'association Concerne 0,N (One To Many)
        public ICollection<Activite> Activites { get; set; }

        // Implementation de l'association Attribuee a 1,1
        public int? SalleId { get; set; }
        public Salle Salle { get; set; }

        // Implementation de l'association Animee par 1,N (One To Many)
        public int? CoachId { get; set; }
        public Coach Coach { get; set; }

        // Implementation de l'association Reserver 1,N (Many To Many)
        public virtual ICollection<Adherent> Adherents { get; set; }

        public Seance()
        {
            // Many To Many Convention
            this.Adherents = new HashSet<Adherent>();
        }
    }
}
