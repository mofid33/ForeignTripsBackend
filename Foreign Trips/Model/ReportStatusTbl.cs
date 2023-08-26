using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class ReportStatusTbl
{
    public int ReportStatusId { get; set; }

    public string ReportStatusType { get; set; } = null!;

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
}
