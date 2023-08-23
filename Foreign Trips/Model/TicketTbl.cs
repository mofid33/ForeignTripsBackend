using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class TicketTbl
{
    public int TicketId { get; set; }

    public int? AdminId { get; set; }

    public int? AgentId { get; set; }

    public int TicketStatusId { get; set; }

    public string Subject { get; set; } = null!;

    public string RegisterDate { get; set; } = null!;

    public string RegisterTime { get; set; } = null!;

    public virtual AdminTbl? Admin { get; set; }

    public virtual ICollection<TicketDetailsTbl> TicketDetailsTbls { get; set; } = new List<TicketDetailsTbl>();

    public virtual TicketStatusTbl TicketStatus { get; set; } = null!;
}
