using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class OperationTypeTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OperationId { get; set; }

    public string OperationType { get; set; } = null!;
}
