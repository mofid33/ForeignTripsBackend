using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foreign_Trips.Model;

public partial class RightOfCommutingTypeTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RightOfCommutingId { get; set; }

    public string RightOfCommutingType { get; set; } = null!;
}
