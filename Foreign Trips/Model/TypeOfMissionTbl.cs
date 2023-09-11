using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foreign_Trips.Model;

public partial class TypeOfMissionTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TypeOfMissionId { get; set; }

    public string? TypeOfMissionTitle { get; set; }

    public virtual ICollection<AgentTbl> AgentTbls { get; set; } = new List<AgentTbl>();
}
