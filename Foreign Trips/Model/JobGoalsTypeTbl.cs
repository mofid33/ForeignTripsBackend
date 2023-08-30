using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class JobGoalsTypeTbl
{
    public int JobGoalsId { get; set; }

    public string JobGoalsType { get; set; } = null!;

    public virtual ICollection<RequestTbl> RequestTbls { get; set; } = new List<RequestTbl>();
}
