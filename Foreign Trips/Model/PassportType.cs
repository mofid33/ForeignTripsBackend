using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class PassportType
{
    public int PassportTypeId { get; set; }

    public string PassportType1 { get; set; } = null!;

    public virtual ICollection<RequestTbl> RequestTbls { get; set; } = new List<RequestTbl>();
}
