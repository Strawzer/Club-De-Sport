using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Club_De_Sport.Models
{
    public class Adherent
    {
        [Key]
        public int CodeAdh { get; set; }

        public string Cin { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string Sexe { get; set; }

        public string Adresse { get; set; }

        public string Ville { get; set; }

        public DateTime? ExpirationDate { get; set; }

        [Required]
        public string Tel { get; set; }

        public string CNE { get; set; }

        [Required]
        public string TelUrgence { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        // Implementation de l'association Reserver 1,10 (Many To Many)
        public virtual ICollection<Seance> Seances { get; set; }

        public virtual ICollection<Activite> PreferredActivities { get; set; }

        public Adherent()
        {
            // Many to many convention
            this.Seances = new HashSet<Seance>();
            this.PreferredActivities = new HashSet<Activite>();
        }
    }
}
