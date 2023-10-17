using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foreign_Trips.Model;

public partial class TicketStatusTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TicketStatusId { get; set; }

    public string TicketStatusTitle { get; set; } = null!;

    public virtual ICollection<TicketTbl> TicketTbls { get; set; } = new List<TicketTbl>();
}
