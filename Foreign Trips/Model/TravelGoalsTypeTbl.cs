using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class TravelGoalsTypeTbl
{
    public int TravelGoalsId { get; set; }

    public string TravelGoalsType { get; set; } = null!;

    public virtual ICollection<RequestTbl> RequestTbls { get; set; } = new List<RequestTbl>();
}
