using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Foreign_Trips.Model;

public partial class JobGoalsTypeTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int JobGoalsId { get; set; }

    public string JobGoalsType { get; set; } = null!;

    public virtual ICollection<RequestTbl> RequestTbls { get; set; } = new List<RequestTbl>();
}
