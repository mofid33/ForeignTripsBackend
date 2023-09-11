using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foreign_Trips.Model;

public partial class MessageTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MessageId { get; set; }

    public int AgentId { get; set; }

    public string MessageTopic { get; set; } = null!;

    public string MessageText { get; set; } = null!;

    public int ReciverMessageId { get; set; }

    public string SubmitTime { get; set; } = null!;

    public int DispatcherSelectionId { get; set; }

    public int ExpertSelectionId { get; set; }

    public string RegisterDate { get; set; } = null!;

    public string RegisterTime { get; set; } = null!;

    public virtual AgentTbl Agent { get; set; } = null!;

    public virtual DispatcherSelectionTbl DispatcherSelection { get; set; } = null!;

    public virtual ExpertSelectionTbl ExpertSelection { get; set; } = null!;

    public virtual ReciverMessageTbl ReciverMessage { get; set; } = null!;
}
