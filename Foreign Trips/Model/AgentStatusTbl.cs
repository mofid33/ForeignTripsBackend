using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class AgentStatusTbl
{
    public int AgentStatusId { get; set; }

    public string AgentStatusType { get; set; } = null!;

    public virtual ICollection<AgentTbl> AgentTbls { get; set; } = new List<AgentTbl>();
}
