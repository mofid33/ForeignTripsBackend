using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foreign_Trips.Model;

public partial class SubsidiaryOrganizationTypeTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SubsidiaryOrganizationId { get; set; }

    public string SubsidiaryOrganizationType { get; set; } = null!;
}
