using System;
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

    public byte[]? Password { get; set; }

    public byte[]? PasswordSalt { get; set; }

    public string? RegisterDate { get; set; }

    public string? RegisterTime { get; set; }

    public virtual ICollection<LoginTbl> LoginTbls { get; set; } = new List<LoginTbl>();
}
