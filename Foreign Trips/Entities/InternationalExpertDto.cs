using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Foreign_Trips.Entities
{
    public class InternationalExpertDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InternationalExpertId { get; set; }

        public string InternationalExpertName { get; set; } = null!;

        public string InternationalExpertFamily { get; set; } = null!;

        public string InternationalExpertUserName { get; set; } = null!;

        public string Password { get; set; }

        public string PasswordSalt { get; set; }
    }
}
