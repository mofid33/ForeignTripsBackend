using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Foreign_Trips.Model;

public partial class ProvinceTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProvinceId { get; set; }

    public string? ProvinceName { get; set; }

    public virtual ICollection<CityTbl> CityTbls { get; set; } = new List<CityTbl>();
}
