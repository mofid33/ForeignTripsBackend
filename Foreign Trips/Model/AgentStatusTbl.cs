﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Foreign_Trips.Model;

public partial class AgentStatusTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AgentStatusId { get; set; }

    public string AgentStatusType { get; set; } = null!;

    public virtual ICollection<AgentTbl> AgentTbls { get; set; } = new List<AgentTbl>();
}
