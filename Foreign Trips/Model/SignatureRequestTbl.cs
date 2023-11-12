using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Foreign_Trips.Model;

public partial class SignatureRequestTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SignutureId { get; set; }

    public int RequestId { get; set; }

    public string FileName { get; set; } = null!;

    public string Signatory { get; set; } = null!;

    public virtual RequestTbl Request { get; set; } = null!;
}
