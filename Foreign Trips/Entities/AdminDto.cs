using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Foreign_Trips.Entities
{
    public class AdminDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdminId { get; set; }
        public string AdminName { get; set; } = null!;
        public string AdminUsername { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
