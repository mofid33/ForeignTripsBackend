using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class InternationalExpertTbl
{
    public int InternationalExpertId { get; set; }

    public string InternationalExpertName { get; set; } = null!;

    public string InternationalExpertFamily { get; set; } = null!;

    public string InternationalExpertUserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<LoginTbl> LoginTbls { get; set; } = new List<LoginTbl>();

    public virtual ICollection<RequestTbl> RequestTbls { get; set; } = new List<RequestTbl>();
}
