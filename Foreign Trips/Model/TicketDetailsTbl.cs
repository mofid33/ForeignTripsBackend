using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class TicketDetailsTbl
{
    public int TicketDetailId { get; set; }

    public int TicketId { get; set; }

    public bool IsAdmin { get; set; }

    public string Message { get; set; } = null!;

    public string RegisterDate { get; set; } = null!;

    public string RegisterTime { get; set; } = null!;

    public virtual TicketTbl Ticket { get; set; } = null!;
}
