using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Foreign_Trips.Model;

public partial class RequestTravelTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RequestTravelId { get; set; }

    public string NameAgent { get; set; } = null!;

    public string NationalCode { get; set; } = null!;

    public string TravelDate { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string TravelTime { get; set; } = null!;

    public string TravelTopic { get; set; } = null!;

    public string TypeOfEmployment { get; set; } = null!;

    public string DestinationCountry { get; set; } = null!;

    public string PersonUpName { get; set; } = null!;

    public string TravelExpensePayer { get; set; } = null!;

    public bool IsFinal { get; set; }
}
