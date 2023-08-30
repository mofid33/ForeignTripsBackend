using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Foreign_Trips.Model;

public partial class TravelTypeTbl

{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TravelTypeId { get; set; }

    public string TravelType { get; set; } = null!;

    public virtual ICollection<RequestTbl> RequestTbls { get; set; } = new List<RequestTbl>();
}
