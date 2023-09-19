using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Foreign_Trips.Entities
{
    public class InternationalAdminDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdminId { get; set; }

        public string AdminName { get; set; } = null!;

        public string AdminUsername { get; set; } = null!;

        public string? RegisterTime { get; set; }

        public string? RegisterDate { get; set; }

        public string Password { get; set; }

        public string PasswordSalt { get; set; }
    }
}
