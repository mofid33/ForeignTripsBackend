using Foreign_Trips.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Foreign_Trips.Entities
{
    public class TicketDetailsDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TicketId { get; set; }

        public bool IsAdmin { get; set; }

        public string Message { get; set; } = null!;

        public string RegisterDate { get; set; } = null!;

        public string RegisterTime { get; set; } = null!;

        public int TicketDetailId { get; set; }

        public int InternationalExpertId { get; set; }

        public int AdminId { get; set; }
    }
}
