using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class InternationalAdminTbl
{
    public int AdminId { get; set; }

    public string AdminName { get; set; } = null!;

    public string AdminUsername { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<MainAdminTbl> MainAdminTbls { get; set; } = new List<MainAdminTbl>();
}
