using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class RightOfMissionTbl
{
    public int RightOfMissionId { get; set; }

    public string RightOfMissionType { get; set; } = null!;

    public virtual ICollection<RequestTbl> RequestTbls { get; set; } = new List<RequestTbl>();
}
