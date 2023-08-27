using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class RequestStatusTbl
{
    public int RequestStatusId { get; set; }

    public string RequestStatusTitle { get; set; } = null!;

    public virtual ICollection<RequestTbl> RequestTbls { get; set; } = new List<RequestTbl>();
}
