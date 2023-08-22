using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Foreign_Trips.Model;

public partial class SubsidiaryOrganization
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SubsidiaryOrganizationId { get; set; }

    public string SubsidiaryOrganizationType { get; set; } = null!;
}
