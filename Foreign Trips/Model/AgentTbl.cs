using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class AgentTbl
{
    public int AgentId { get; set; }

    public int? CityId { get; set; }

    public int? TypeOfMissionId { get; set; }

    public int? SupervisorId { get; set; }

    public int? TypeOfEmploymentId { get; set; }

    public int? PositionId { get; set; }

    public int? AgentStatusId { get; set; }

    public string? AgentName { get; set; }

    public string? AgentFamily { get; set; }

    public string? NationalCode { get; set; }

    public string? Mobile { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? CompanyName { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public byte[]? Photo { get; set; }

    public string? RegisterDate { get; set; }

    public string? RegisterTime { get; set; }

    public string? PostalCode { get; set; }

    public string? BirthCertificateNumber { get; set; }

    public string? BirthCertificateDate { get; set; }

    public int? GenderId { get; set; }

    public int? MaritalStatusId { get; set; }

    public string? Degree { get; set; }

    public string? FieldOfStudy { get; set; }

    public string? LanguageId { get; set; }

    public string? Servicelocation { get; set; }

    public virtual AgentStatusTbl? AgentStatus { get; set; }

    public virtual CityTbl? City { get; set; }

    public virtual GenderTypeTbl? Gender { get; set; }

    public virtual MaritalStatusTbl? MaritalStatus { get; set; }

    public virtual PositionTypeTbl? Position { get; set; }

    public virtual ICollection<RequestTbl> RequestTbls { get; set; } = new List<RequestTbl>();

    public virtual SupervisoerTbl? Supervisor { get; set; }

    public virtual TypeOfEmploymentTbl? TypeOfEmployment { get; set; }

    public virtual TypeOfMissionTbl? TypeOfMission { get; set; }
}
