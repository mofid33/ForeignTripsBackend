using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Foreign_Trips.Model;

public partial class MainAdminTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MainAdminId { get; set; }

    public string MainAdminName { get; set; } = null!;

    public string MainAdminUserName { get; set; } = null!;

    public byte[]? Password { get; set; }

    public byte[]? PasswordSalt { get; set; }

    public string? RegisterTime { get; set; }

    public string? RegisterDate { get; set; }

    public virtual ICollection<LoginTbl> LoginTbls { get; set; } = new List<LoginTbl>();

    public virtual ICollection<RequestTbl> RequestTbls { get; set; } = new List<RequestTbl>();
}
