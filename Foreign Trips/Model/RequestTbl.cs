﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Foreign_Trips.Model;

public partial class RequestTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RequestId { get; set; }

    public int? AgentId { get; set; }

    public int? RequestStatusId { get; set; }

    public string RequestName { get; set; } = null!;

    public string NationalCode { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string WorkLocation { get; set; } = null!;

    public string TypeOfEmployment { get; set; } = null!;

    public string TravelDate { get; set; } = null!;

    public string TravelTime { get; set; } = null!;

    public string TravelTopic { get; set; } = null!;

    public string DestinationCountry { get; set; } = null!;

    public string Payer { get; set; } = null!;

    public int TravelCost { get; set; }

    public string RejectDescription { get; set; } = null!;

    public string? ConfirmDate { get; set; }

    public virtual AgentTbl? Agent { get; set; }

    public virtual RequestStatusTbl? RequestStatus { get; set; }
}
