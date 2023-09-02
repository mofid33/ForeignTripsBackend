using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class MainAdminTbl
{
    public int MainAdminId { get; set; }

    public string MainAdminName { get; set; } = null!;

    public string MainAdminUserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<LoginTbl> LoginTbls { get; set; } = new List<LoginTbl>();

    public virtual ICollection<RequestTbl> RequestTbls { get; set; } = new List<RequestTbl>();
}
