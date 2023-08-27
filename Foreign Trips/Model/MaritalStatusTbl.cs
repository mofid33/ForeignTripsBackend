using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class MaritalStatusTbl
{
    public int MaritalStatusId { get; set; }

    public string? MaritalStatusTitle { get; set; }

    public virtual ICollection<AgentTbl> AgentTbls { get; set; } = new List<AgentTbl>();
}
