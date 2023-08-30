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

    public int CityId { get; set; }

    public int TypeOfMissionId { get; set; }

    public int MainAdminId { get; set; }

    public int SubCategoryId { get; set; }

    public int TypeOfEmploymentId { get; set; }

    public int AgentStatusId { get; set; }

    public int PositionId { get; set; }

    public string AgentName { get; set; } = null!;

    public string AgentFamily { get; set; } = null!;

    public string AgentFatherName { get; set; } = null!;

    public string NationalCode { get; set; } = null!;

    public string DateOfBirth { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Subset { get; set; } = null!;

    public byte[]? Photo { get; set; }

    public string RegisterDate { get; set; } = null!;

    public string RegisterTime { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string BirthCertificateNumber { get; set; } = null!;

    public string BirthCertificateDate { get; set; } = null!;

    public int GenderId { get; set; }

    public int MaritalStatusId { get; set; }

    public string Degree { get; set; } = null!;

    public string FieldOfStudy { get; set; } = null!;

    public int LanguageId { get; set; }

    public string WorkExperience { get; set; } = null!;

    public string Joblocation { get; set; } = null!;

    public string Position { get; set; } = null!;

    public virtual AgentStatusTbl AgentStatus { get; set; } = null!;

    public virtual CityTbl City { get; set; } = null!;

    public virtual LanguageType Language { get; set; } = null!;

    public virtual MainAdminTbl MainAdmin { get; set; } = null!;

    public virtual MaritalStatusTbl MaritalStatus { get; set; } = null!;

    public virtual ICollection<MessageTbl> MessageTbls { get; set; } = new List<MessageTbl>();

    public virtual PositionTypeTbl PositionNavigation { get; set; } = null!;

    public virtual ICollection<RequestTbl> RequestTbls { get; set; } = new List<RequestTbl>();

    public virtual SubCategoryTbl SubCategory { get; set; } = null!;

    public virtual ICollection<TicketTbl> TicketTbls { get; set; } = new List<TicketTbl>();

    public virtual TypeOfEmploymentTbl TypeOfEmployment { get; set; } = null!;

    public virtual TypeOfMissionTbl TypeOfMission { get; set; } = null!;
}
