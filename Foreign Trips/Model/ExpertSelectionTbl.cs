using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class ExpertSelectionTbl
{
    public int ExpertSelectionId { get; set; }

    public string ExpertSelectionType { get; set; } = null!;

    public virtual ICollection<MessageTbl> MessageTbls { get; set; } = new List<MessageTbl>();
}
