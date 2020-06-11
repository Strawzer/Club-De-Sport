using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Club_De_Sport.Models
{
    public class Coach
    {
        [Key]
        public int CodeCoach { get; set; }

        public string Cin { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string Sexe { get; set; }

        public string Adresse { get; set; }

        public string Ville { get; set; }

        public string Tel { get; set; }

        public string TelUrgence { get; set; }

        // Implementation de l'association Réalise 1,2 (One To Many)
        public virtual ICollection<Activite> Activites { get; set; }

        // Implementation de l'association Animee par 1,1 (One To Many)
        public ICollection<Seance> Seances { get; set; }

        // Implementation de l'association Réalise 1,1 (One To Many)
        public int? ActiviteId { get; set; }

        public Coach()
        {
            Activites = new HashSet<Activite>();
        }
    }
}
