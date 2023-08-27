using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class TollAmountTypeTbl
{
    public int TollAmountId { get; set; }

    public string TollAmountType { get; set; } = null!;

    public virtual ICollection<RequestTbl> RequestTbls { get; set; } = new List<RequestTbl>();
}
