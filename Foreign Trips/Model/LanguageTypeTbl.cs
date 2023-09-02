using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class LanguageTypeTbl
{
    public int LanguageId { get; set; }

    public string LanguageType { get; set; } = null!;

    public virtual ICollection<RequestEmployeeTbl> RequestEmployeeTbls { get; set; } = new List<RequestEmployeeTbl>();
}
