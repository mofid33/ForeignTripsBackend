using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class FileDetailsTbl
{
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
