using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Foreign_Trips.Entities
{
    public class ReportDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReportId { get; set; }
        public int? FileId { get; set; }
        public int RequestId { get; set; }
        public string SubjectOfTravel { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
