using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Foreign_Trips.Model;

public partial class AdminTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AdminId { get; set; }

    public string AdminName { get; set; } = null!;

    public string AdminUsername { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<SupervisorTbl> SupervisorTbls { get; set; } = new List<SupervisorTbl>();

    public virtual ICollection<TicketTbl> TicketTbls { get; set; } = new List<TicketTbl>();
}
