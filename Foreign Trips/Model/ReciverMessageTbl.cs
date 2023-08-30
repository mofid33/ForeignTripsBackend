﻿using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class ReciverMessageTbl
{
    public int ReciverMessageId { get; set; }

    public string ReciverMessageType { get; set; } = null!;

    public virtual ICollection<MessageTbl> MessageTbls { get; set; } = new List<MessageTbl>();
}
