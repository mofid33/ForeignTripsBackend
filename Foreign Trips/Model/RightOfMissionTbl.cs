using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foreign_Trips.Model;

public partial class RightOfMissionTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RightOfMissionId { get; set; }

    public string RightOfMissionType { get; set; } = null!;
<<<<<<< HEAD

    public virtual ICollection<RequestTbl> RequestTbls { get; set; } = new List<RequestTbl>();
=======
>>>>>>> 32077c253bedb6fdb201b174a194390bf5cac703
}
