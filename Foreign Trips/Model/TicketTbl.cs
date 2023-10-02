using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foreign_Trips.Model;

public partial class TicketTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TicketId { get; set; }

    public int AgentId { get; set; }

    public int TicketStatusId { get; set; }

    public string TicketNumber { get; set; } = null!;

    public string Subject { get; set; } = null!;

    public string RegisterDate { get; set; } = null!;

    public string RegisterTime { get; set; } = null!;

    public string LatestUpdate { get; set; } = null!;

    public int? InternationalExpertId { get; set; }

    public int? AdminId { get; set; }

    public int? MainAdminId { get; set; }

    public virtual InternationalAdminTbl? Admin { get; set; }

    public virtual AgentTbl Agent { get; set; } = null!;

    public virtual InternationalExpertTbl? InternationalExpert { get; set; }

    public virtual MainAdminTbl? MainAdmin { get; set; }

    public virtual ICollection<TicketDetailsTbl> TicketDetailsTbls { get; set; } = new List<TicketDetailsTbl>();

    public virtual TicketStatusTbl TicketStatus { get; set; } = null!;
}
