using System.ComponentModel.DataAnnotations;

namespace Club_De_Sport.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(255)]
        public string Password { get; set; }

        [Required]
        public byte Role { get; set; }

        // Implement Adherent database entry from this model
        public int? AdherentId { get; set; }
        public Adherent Adherent { get; set; }

        public static readonly byte Admin = 0;
        public static readonly byte NonRegisteredClient = 1;
        public static readonly byte NonPayedClient = 2;
        public static readonly byte Client = 3;
    }

}
