using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foreign_Trips.Model;

public partial class ReciverMessageTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ReciverMessageId { get; set; }

    public string ReciverMessageType { get; set; } = null!;

    public virtual ICollection<MessageTbl> MessageTbls { get; set; } = new List<MessageTbl>();
}
