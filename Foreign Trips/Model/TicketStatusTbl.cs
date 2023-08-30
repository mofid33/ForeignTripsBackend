using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class TicketStatusTbl
{
    public int TicketStatusId { get; set; }

    public string TicketStatusTitle { get; set; } = null!;

    public virtual ICollection<TicketTbl> TicketTbls { get; set; } = new List<TicketTbl>();
}
