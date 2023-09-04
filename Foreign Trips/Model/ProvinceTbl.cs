using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foreign_Trips.Model;

public partial class ProvinceTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProvinceId { get; set; }

    public string? ProvinceName { get; set; }

    public virtual ICollection<CityTbl> CityTbls { get; set; } = new List<CityTbl>();
}
