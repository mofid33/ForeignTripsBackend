using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Foreign_Trips.Model;

public partial class RequestStatusTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RequestStatusId { get; set; }

    public int RequestStatusTitle { get; set; }

    public virtual ICollection<RequestTbl> RequestTbls { get; set; } = new List<RequestTbl>();
}
