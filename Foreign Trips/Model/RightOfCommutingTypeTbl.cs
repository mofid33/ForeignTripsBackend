﻿using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class RightOfCommutingTypeTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RightOfCommutingId { get; set; }

    public string RightOfCommutingType { get; set; } = null!;

    public virtual ICollection<RequestTbl> RequestTbls { get; set; } = new List<RequestTbl>();
}
