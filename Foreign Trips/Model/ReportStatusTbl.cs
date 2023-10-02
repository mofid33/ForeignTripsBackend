using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foreign_Trips.Model;

public partial class ReportStatusTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ReportStatusId { get; set; }

    public string ReportStatusType { get; set; } = null!;

    public virtual ICollection<ReportTbl> ReportTbls { get; set; } = new List<ReportTbl>();
}
