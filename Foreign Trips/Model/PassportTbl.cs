using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class PassportTbl
{
    public int PassportId { get; set; }

    public int? AgentId { get; set; }

    public string FarsiName { get; set; } = null!;

    public string FarsiFamily { get; set; } = null!;

    public string LatinName { get; set; } = null!;

    public string LatinFamily { get; set; } = null!;

    public string FarsiFatherName { get; set; } = null!;

    public string LatinFatherName { get; set; } = null!;

    public string MissionLocation { get; set; } = null!;

    public string TypeOfMission { get; set; } = null!;

    public string DegreeOfEducation { get; set; } = null!;

    public string MaritalStatus { get; set; } = null!;

    public string DispatchingAgency { get; set; } = null!;
}
