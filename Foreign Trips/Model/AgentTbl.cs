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

    public int SupervisorId { get; set; }

    public int TypeOfEmploymentId { get; set; }

    public int PositionId { get; set; }

    public int AgentStatusId { get; set; }

    public string AgentName { get; set; } = null!;

    public string AgentFamily { get; set; } = null!;

    public string NationalCode { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public byte[]? Photo { get; set; }

    public string RegisterDate { get; set; } = null!;

    public string RegisterTime { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public virtual CityTbl City { get; set; } = null!;

    public virtual ICollection<LoginTbl> LoginTbls { get; set; } = new List<LoginTbl>();

    public virtual PositionTbl Position { get; set; } = null!;

    public virtual SupervisorTbl Supervisor { get; set; } = null!;

    public virtual TypeOfEmploymentTbl TypeOfEmployment { get; set; } = null!;

    public virtual TypeOfMissionTbl TypeOfMission { get; set; } = null!;
}
