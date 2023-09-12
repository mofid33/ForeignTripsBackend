using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foreign_Trips.Model;

public partial class FileTypeTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FileTypeId { get; set; }

    public string? FileTypeTitle { get; set; }

    public virtual ICollection<FileDetailsTbl> FileDetailsTbls { get; set; } = new List<FileDetailsTbl>();
}
