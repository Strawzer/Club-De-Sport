using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Club_De_Sport.Models
{
    public class Activite
    {
        [Key]
        public byte CodeActivite { get; set; }

        public string Nom { get; set; }

        public decimal Prix { get; set; }

        // Implementation de la relation many to many
        public virtual ICollection<Coach> Coachs { get; set; }
        
        // Implementation de l'association Concerne 1,1 (One To Many)
        public int? SeanceId { get; set; }
        public Seance Seance { get; set; }

        public int? SalleId { get; set; }
        public Salle Salle { get; set; }

        public Activite()
        {
            Coachs = new HashSet<Coach>();
        }
    }
}
