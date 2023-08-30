using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class FileTypeTbl
{
    public int FileTypeId { get; set; }

    public string? FileTypeTitle { get; set; }

    public virtual ICollection<FileDetailsTbl> FileDetailsTbls { get; set; } = new List<FileDetailsTbl>();
}
