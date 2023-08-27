using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class RightToEducationTbl
{
    public int RightToEducationId { get; set; }

    public string RightToEducationType { get; set; } = null!;

    public virtual ICollection<RequestTbl> RequestTbls { get; set; } = new List<RequestTbl>();
}
