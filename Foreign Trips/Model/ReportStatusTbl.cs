using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Foreign_Trips.Model;

public partial class ReportStatusTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ReportStatusId { get; set; }

    public string ReportStatusType { get; set; } = null!;

    public virtual ICollection<ReportTbl> ReportTbls { get; set; } = new List<ReportTbl>();
}
