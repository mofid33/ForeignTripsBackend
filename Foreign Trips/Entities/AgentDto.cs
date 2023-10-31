using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Foreign_Trips.Entities
{
    public class AgentDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AgentId { get; set; }
        public int TotalPages { get; set; }

        public int? CityId { get; set; }

        public int? TypeOfMissionId { get; set; }

        public int SubCategoryId { get; set; }

        public int TypeOfEmploymentId { get; set; }

        public int? AgentStatusId { get; set; }

        public int PositionId { get; set; }

        public string AgentName { get; set; } = null!;

        public string AgentFamily { get; set; } = null!;

        public string? AgentFatherName { get; set; }

        public string NationalCode { get; set; } = null!;

        public string DateOfBirth { get; set; } = null!;

        public string Mobile { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string? CompanyName { get; set; }

        public string Email { get; set; } = null!;

        public string Subset { get; set; } = null!;

        public byte[]? Photo { get; set; }

        public string RegisterDate { get; set; } = null!;

        public string RegisterTime { get; set; } = null!;

        public string PostalCode { get; set; } = null!;

        public string? BirthCertificateNumber { get; set; }

        public string? BirthCertificateDate { get; set; }

        public int? GenderId { get; set; }

        public string PasswordSalt { get; set; }

        public string Password { get; set; }

    }
}
