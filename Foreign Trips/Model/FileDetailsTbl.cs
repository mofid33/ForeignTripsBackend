using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foreign_Trips.Model;

public partial class FileDetailsTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FileId { get; set; }

    public string FileName { get; set; } = null!;

    public int? RequestId { get; set; }

    public int? FileTypeId { get; set; }

    public int? ReportId { get; set; }

    public string? Date { get; set; }

    public virtual FileTypeTbl? FileType { get; set; }

    public virtual ReportTbl? Report { get; set; }

    public virtual RequestTbl? Request { get; set; }
}
