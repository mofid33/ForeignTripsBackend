using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Foreign_Trips.Model;

public partial class ReportTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ReportId { get; set; }

    public int? RequestId { get; set; }

    public int? ReportStatusId { get; set; }

    public string? RequestDateNumber { get; set; }

    public string? LicenseNumber { get; set; }

    public string? LicenseDate { get; set; }

    public string? Period { get; set; }

    public string? EmailInternalDevice { get; set; }

    public string? EmailExternalDevice { get; set; }

    public string? InternalDevice { get; set; }

    public string? ExternalDevice { get; set; }

    public string? LatestUpdate { get; set; }

    public string ReportAchievement { get; set; } = null!;

    public string? RegisterDate { get; set; }

    public string? RegisterTime { get; set; }

    public virtual ICollection<FileDetailsTbl> FileDetailsTbls { get; set; } = new List<FileDetailsTbl>();

    public virtual ReportStatusTbl? ReportStatus { get; set; }

    public virtual RequestTbl? Request { get; set; }
}
