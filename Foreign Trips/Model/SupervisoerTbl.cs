using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class SupervisoerTbl
{
    public int SupervisorId { get; set; }

    public int? AdminId { get; set; }

    public int? AgentId { get; set; }

    public string SupervisorName { get; set; } = null!;

    public string SupervisorUserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual AdminTbl? Admin { get; set; }

    public virtual ICollection<AgentTbl> AgentTbls { get; set; } = new List<AgentTbl>();
}
