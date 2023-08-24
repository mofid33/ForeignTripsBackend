using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class Report
{
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

    public virtual FileDetailsTbl? File { get; set; }

    public virtual RequestTbl Request { get; set; } = null!;
}
