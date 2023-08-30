using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Foreign_Trips.Model;

public partial class ExpertSelectionTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ExpertSelectionId { get; set; }

    public string ExpertSelectionType { get; set; } = null!;

    public virtual ICollection<MessageTbl> MessageTbls { get; set; } = new List<MessageTbl>();
}
