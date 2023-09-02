using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class SupervisorTbl
{
    public int SupervisorId { get; set; }

    public string SupervisorName { get; set; } = null!;

    public string SupervisorFamily { get; set; } = null!;

    public string SupervisorUserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<LoginTbl> LoginTbls { get; set; } = new List<LoginTbl>();
}
