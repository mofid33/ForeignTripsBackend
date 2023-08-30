using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Foreign_Trips.Model;

public partial class SubCategoryTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SubCategoryId { get; set; }

    public string SubCategoryType { get; set; } = null!;

    public virtual ICollection<AgentTbl> AgentTbls { get; set; } = new List<AgentTbl>();
}
