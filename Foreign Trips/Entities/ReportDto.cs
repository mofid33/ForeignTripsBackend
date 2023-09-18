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

        public string? RequestDateNumber { get; set; }

        public string? LicenseNumber { get; set; }

        public string? LicenseDate { get; set; }

        public string? Period { get; set; }

        public string? EmailInternalDevice { get; set; }

        public string? EmailExternalDevice { get; set; }

        public string? InternalDevice { get; set; }

        public string? ExternalDevice { get; set; }

        public string? RegisterDate { get; set; }

        public string? RegisterTime { get; set; }
    }
}
