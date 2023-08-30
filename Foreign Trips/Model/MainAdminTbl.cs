using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class MainAdminTbl
{
    public int MainAdminId { get; set; }

    public int? AdminId { get; set; }

    public int? AgentId { get; set; }

    public string MainAdminName { get; set; } = null!;

    public string MainAdminUserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual InternationalAdminTbl? Admin { get; set; }

    public virtual ICollection<AgentTbl> AgentTbls { get; set; } = new List<AgentTbl>();
}
