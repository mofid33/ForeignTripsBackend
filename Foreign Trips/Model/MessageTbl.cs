using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class MessageTbl
{
    public int MessageId { get; set; }

    public string MessageTopic { get; set; } = null!;

    public string MessageText { get; set; } = null!;

    public string ReciverMessageId { get; set; } = null!;

    public string SubmitTime { get; set; } = null!;

    public string RegisterDate { get; set; } = null!;

    public string RegisterTime { get; set; } = null!;
}
