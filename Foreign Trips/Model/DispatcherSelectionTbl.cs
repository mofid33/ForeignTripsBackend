using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class DispatcherSelectionTbl
{
    public int DispatcherSelectionId { get; set; }

    public string DispatcherSelectionType { get; set; } = null!;

    public virtual ICollection<MessageTbl> MessageTbls { get; set; } = new List<MessageTbl>();
}
