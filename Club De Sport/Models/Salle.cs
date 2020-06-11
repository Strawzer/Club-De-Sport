using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Club_De_Sport.Models
{
    public class Salle
    {
        [Key]
        public byte CodeSalle { get; set; }

        public string Discipline { get; set; }

        public ICollection<Seance> Seances { get; set; }

    }

}
