using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Foreign_Trips.Entities
{
    public class SupervisorDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupervisorId { get; set; }

        public string SupervisorName { get; set; } = null!;

        public string SupervisorFamily { get; set; } = null!;

        public string SupervisorUserName { get; set; } = null!;

        public string Password { get; set; } 

        public string PasswordSalt { get; set; }
    }
}
