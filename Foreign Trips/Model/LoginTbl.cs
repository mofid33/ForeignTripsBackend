using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foreign_Trips.Model;

public partial class LoginTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LoginId { get; set; }

    public int? AgentId { get; set; }

    public string Date { get; set; } = null!;

    public string Time { get; set; } = null!;

    public int? SupervisorId { get; set; }

    public int? AdminId { get; set; }

    public int? InternationalExpertId { get; set; }

    public int? MainAdminId { get; set; }

    public virtual InternationalAdminTbl? Admin { get; set; }

    public virtual AgentTbl? Agent { get; set; }

    public virtual InternationalExpertTbl? InternationalExpert { get; set; }

    public virtual MainAdminTbl? MainAdmin { get; set; }

    public virtual SupervisorTbl? Supervisor { get; set; }
}
