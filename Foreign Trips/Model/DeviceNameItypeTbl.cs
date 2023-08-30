using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class DeviceNameItypeTbl
{
    public int DeviceNameId { get; set; }

    public string DeviceNameType { get; set; } = null!;

    public virtual ICollection<RequestTbl> RequestTbls { get; set; } = new List<RequestTbl>();
}
