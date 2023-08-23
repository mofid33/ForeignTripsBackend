using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class Report
{
    public int ReportId { get; set; }

    public int? FileId { get; set; }

    public int RequestId { get; set; }

    public string SubjectOfTravel { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual RequestTbl Request { get; set; } = null!;
}
