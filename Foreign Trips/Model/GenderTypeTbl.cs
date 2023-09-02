using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class GenderTypeTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int GenderId { get; set; }

    public string GenderType { get; set; } = null!;

    public virtual ICollection<RequestEmployeeTbl> RequestEmployeeTbls { get; set; } = new List<RequestEmployeeTbl>();
}
