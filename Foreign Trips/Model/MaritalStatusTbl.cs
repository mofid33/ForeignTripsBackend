using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foreign_Trips.Model;

public partial class MaritalStatusTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MaritalStatusId { get; set; }

    public string? MaritalStatusTitle { get; set; }

    public virtual ICollection<RequestEmployeeTbl> RequestEmployeeTbls { get; set; } = new List<RequestEmployeeTbl>();
}
