using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Foreign_Trips.Model;

public partial class LanguageTypeTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LanguageId { get; set; }

    public string LanguageType { get; set; } = null!;

    public virtual ICollection<RequestEmployeeTbl> RequestEmployeeTbls { get; set; } = new List<RequestEmployeeTbl>();
}
