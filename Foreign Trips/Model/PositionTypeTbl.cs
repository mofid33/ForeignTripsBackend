using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class PositionTypeTbl
{
    public int PositionId { get; set; }

    public string PositionType { get; set; } = null!;

    public virtual ICollection<AgentTbl> AgentTbls { get; set; } = new List<AgentTbl>();

    public virtual ICollection<RequestEmployeeTbl> RequestEmployeeTbls { get; set; } = new List<RequestEmployeeTbl>();
}
