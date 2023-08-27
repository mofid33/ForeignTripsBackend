using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class TravelTypeTbl
{
    public int TravelTypeId { get; set; }

    public string TravelType { get; set; } = null!;

    public virtual ICollection<RequestTbl> RequestTbls { get; set; } = new List<RequestTbl>();
}
