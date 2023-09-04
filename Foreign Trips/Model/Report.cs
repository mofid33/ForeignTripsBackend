using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foreign_Trips.Model;

public partial class Report
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ReportId { get; set; }

    public int RequestId { get; set; }

    public int ReportStatusId { get; set; }

    public string RequestDateNumber { get; set; } = null!;

    public string LicenseNumber { get; set; } = null!;

    public string LicenseDate { get; set; } = null!;

    public string Period { get; set; } = null!;

    public string EmailInternalDevice { get; set; } = null!;

    public string EmailExternalDevice { get; set; } = null!;

    public string InternalDevice { get; set; } = null!;

    public string ExternalDevice { get; set; } = null!;

    public string LatestUpdate { get; set; } = null!;

    public virtual ICollection<FileDetailsTbl> FileDetailsTbls { get; set; } = new List<FileDetailsTbl>();

    public virtual ReportStatusTbl ReportStatus { get; set; } = null!;

    public virtual RequestTbl Request { get; set; } = null!;
}
