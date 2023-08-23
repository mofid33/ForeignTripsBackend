﻿using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class AdminTbl
{
    public int AdminId { get; set; }

    public string AdminName { get; set; } = null!;

    public string AdminUsername { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<SupervisorTbl> SupervisorTbls { get; set; } = new List<SupervisorTbl>();

    public virtual ICollection<TicketTbl> TicketTbls { get; set; } = new List<TicketTbl>();
}
