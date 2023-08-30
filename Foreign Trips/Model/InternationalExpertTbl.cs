using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Foreign_Trips.Model;

public partial class InternationalExpertTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int InternationalExpertId { get; set; }

    public string InternationalExpertName { get; set; } = null!;

    public string InternationalExpertFamily { get; set; } = null!;

    public string InternationalExpertUserName { get; set; } = null!;

    public string Password { get; set; } = null!;
}
