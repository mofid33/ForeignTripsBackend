using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Foreign_Trips.Entities
{
    public class AgentDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AgentId { get; set; }
        public int ProvinceId { get; set; } 
        public int CityId { get; set; } 
        public string AgentName { get; set; } = null!;
        public string NationalCode { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string RegisterDate { get; set; } = null!;
        public string RegisterTime { get; set; } = null!;
        public string? ProvinceCertificateID { get; set; } 
        public string? CityCertificateID { get; set; } 
        public string? ProvinceBirthCertificateIssuingPlace { get; set; } 
        public string? CityCertificateIssuingPlace { get; set;} 
        public int? BirthCertificateID { get; set; } 





    }
}
