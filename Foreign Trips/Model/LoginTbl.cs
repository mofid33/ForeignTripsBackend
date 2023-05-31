using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Foreign_Trips.Model;

public partial class LoginTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LoginId { get; set; }

    public int? AgentId { get; set; }

    public string Date { get; set; } = null!;

    public string Time { get; set; } = null!;

    public virtual AgentTbl? Agent { get; set; }
}
