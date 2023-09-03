using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Foreign_Trips.Model;

public partial class PassportTypeTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PassportTypeId { get; set; }

    public string PassportType { get; set; } = null!;

    public virtual ICollection<RequestEmployeeTbl> RequestEmployeeTbls { get; set; } = new List<RequestEmployeeTbl>();

    public virtual ICollection<RequestTbl> RequestTbls { get; set; } = new List<RequestTbl>();
}
