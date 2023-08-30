using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Foreign_Trips.Model;

public partial class CityTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CityId { get; set; }

    public string? CityName { get; set; }

    public string? ProvinceName { get; set; }

    public int? ProvinceId { get; set; }

    public virtual ICollection<AgentTbl> AgentTbls { get; set; } = new List<AgentTbl>();

    public virtual ICollection<ForeignDelegrationTbl> ForeignDelegrationTbls { get; set; } = new List<ForeignDelegrationTbl>();

    public virtual ProvinceTbl? Province { get; set; }
}
