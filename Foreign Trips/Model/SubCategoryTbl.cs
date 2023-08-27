using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class SubCategoryTbl
{
    public int SubCategoryId { get; set; }

    public string SubCategoryType { get; set; } = null!;

    public virtual ICollection<AgentTbl> AgentTbls { get; set; } = new List<AgentTbl>();
}
