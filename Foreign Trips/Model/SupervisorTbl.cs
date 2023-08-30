﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Foreign_Trips.Model;

public partial class SupervisorTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SupervisorId { get; set; }

    public string SupervisorName { get; set; } = null!;

    public string SupervisorFamily { get; set; } = null!;

    public string SupervisorUserName { get; set; } = null!;

    public string Password { get; set; } = null!;
}
