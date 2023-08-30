using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class TypeOfEmploymentTbl
{
    public int TypeOfEmploymentId { get; set; }

    public string TypeOfEmploymentTitle { get; set; } = null!;

    public virtual ICollection<AgentTbl> AgentTbls { get; set; } = new List<AgentTbl>();
}
