using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class ProvinceTbl
{
    public int ProvinceId { get; set; }

    public string? ProvinceName { get; set; }

    public virtual ICollection<CityTbl> CityTbls { get; set; } = new List<CityTbl>();
}
