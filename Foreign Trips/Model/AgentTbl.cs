using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Foreign_Trips.Model;

public partial class AgentTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AgentId { get; set; }

    public int? CityId { get; set; }

    public string AgentName { get; set; } = null!;

    public string NationalCode { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string RegisterDate { get; set; } = null!;

    public string RegisterTime { get; set; } = null!;

    public string? ProvinceCertificateId { get; set; }

    public string? CittyCertificateId { get; set; }

    public string? ProviceBirthCertificateIssuingPlace { get; set; }

    public string? CityBirthCertificateIssuingPlace { get; set; }

    public int? BirthCertificateId { get; set; }

    public byte[]? PasswordSalt { get; set; }

    public string? RejectDescription { get; set; }

    public virtual CityTbl? City { get; set; }

    public virtual ICollection<LoginTbl> LoginTbls { get; set; } = new List<LoginTbl>();

    public virtual ICollection<RequestTbl> RequestTbls { get; set; } = new List<RequestTbl>();
}
