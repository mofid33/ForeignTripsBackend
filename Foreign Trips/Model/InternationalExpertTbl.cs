using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foreign_Trips.Model;

public partial class InternationalExpertTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int InternationalExpertId { get; set; }

    public string InternationalExpertName { get; set; } = null!;

    public string InternationalExpertFamily { get; set; } = null!;

    public string InternationalExpertUserName { get; set; } = null!;

    public byte[]? Password { get; set; }

    public byte[]? PasswordSalt { get; set; }

    public string? RegisterDate { get; set; }

    public string? RegisterTime { get; set; }

    public virtual ICollection<LoginTbl> LoginTbls { get; set; } = new List<LoginTbl>();

    public virtual ICollection<RequestTbl> RequestTbls { get; set; } = new List<RequestTbl>();

    public virtual ICollection<TicketTbl> TicketTbls { get; set; } = new List<TicketTbl>();
}
