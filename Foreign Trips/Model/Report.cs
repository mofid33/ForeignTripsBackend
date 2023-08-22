using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Foreign_Trips.Model;

public partial class Report
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ReportId { get; set; }

    public int? FileId { get; set; }

    public int RequestId { get; set; }

    public string SubjectOfTravel { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual RequestTbl Request { get; set; } = null!;
}
