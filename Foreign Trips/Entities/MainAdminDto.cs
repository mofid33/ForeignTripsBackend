using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Foreign_Trips.Entities
{
    public class MainAdminDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MainAdminId { get; set; }

        public string MainAdminName { get; set; } = null!;

        public string MainAdminUserName { get; set; } = null!;

        public string Password { get; set; }

        public string PasswordSalt { get; set; }
    }
}
