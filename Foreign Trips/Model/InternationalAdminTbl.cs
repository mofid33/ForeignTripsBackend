using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Foreign_Trips.Model;

public partial class InternationalAdminTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AdminId { get; set; }

    public string AdminName { get; set; } = null!;

    public string AdminUsername { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<LoginTbl> LoginTbls { get; set; } = new List<LoginTbl>();

    public virtual ICollection<RequestTbl> RequestTbls { get; set; } = new List<RequestTbl>();
}
