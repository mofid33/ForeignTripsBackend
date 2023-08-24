using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class LoginTbl
{
    public int LoginId { get; set; }

    public int? AgentId { get; set; }

    public string Date { get; set; } = null!;

    public string Time { get; set; } = null!;
}
