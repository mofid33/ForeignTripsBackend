using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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

    public virtual Report? Report { get; set; }

    public virtual RequestTbl? Request { get; set; }
}
