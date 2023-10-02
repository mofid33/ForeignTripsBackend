using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foreign_Trips.Model;

public partial class RequestTbl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RequestId { get; set; }

    public int? AgentId { get; set; }

    public int? RequestStatusId { get; set; }

    public string ExecutiveDeviceName { get; set; } = null!;

    public string InternetAddressOfTheExecutiveDevice { get; set; } = null!;

    public string DestinationCity { get; set; } = null!;

    public string? DestinationCountry { get; set; }

    public string FlightPath { get; set; } = null!;

    public string TravelDateStart { get; set; } = null!;

    public string TravelTime { get; set; } = null!;

    public string TravelTopic { get; set; } = null!;

    public int TravelGoalId { get; set; }

    public int JobGoalId { get; set; }

    public int ParticipantId { get; set; }

    public int PassportTypeId { get; set; }

    public bool GetVisa { get; set; }

    public bool JointTrip { get; set; }

    public string DateLetter { get; set; } = null!;

    public string? PayerCitizenShip { get; set; }

    public string? AmountOfCost { get; set; }

    public string? PayerFood { get; set; }

    public string? CostOfFood { get; set; }

    public string? TickerTypeId { get; set; }

    public string? AirlineCompany { get; set; }

    public string? TicketCost { get; set; }

    public string? TheCostOfTicket { get; set; }

    public int? RightOfMissionId { get; set; }

    public string? ManagerRightOfMission { get; set; }

    public string? ExpertRightOfMission { get; set; }

    public string? RightToEducationCost { get; set; }

    public int? RightToEducationId { get; set; }

    public string? RightOfCommutingCost { get; set; }

    public int? RightOfCommutingId { get; set; }

    public string? VisaCost { get; set; }

    public string? TollAmountCost { get; set; }

    public int? TollAmountId { get; set; }

    public string? PaymentFromBank { get; set; }

    public string? ImportantTravel { get; set; }

    public string? MissionAchievementRecords { get; set; }

    public string? SummaryInvitation { get; set; }

    public string? ForeignTravelSummary { get; set; }

    public bool? ReferenceDeviceAgreement { get; set; }

    public bool? ResistanceEconomyTravel { get; set; }

    public string? RejectRequest { get; set; }

    public string? DateOfLasteChange { get; set; }

    public string? OperationId { get; set; }

    public int? TravelTypeId { get; set; }

    public string? ApprovedBy { get; set; }

    public string? EmployeeStatus { get; set; }

    public bool? IsFinal { get; set; }

    public int? AdminId { get; set; }

    public int? InternationalExpertId { get; set; }

    public int? MainAdminId { get; set; }

    public string? TravalEndDate { get; set; }

    public string? DeviceName { get; set; }

    public string? RegisterTime { get; set; }

    public string? RegisterDate { get; set; }

    public string? GeneralManagerRightOfMission { get; set; }

    public int? TypeAccommodationId { get; set; }

    public virtual InternationalAdminTbl? Admin { get; set; }

    public virtual AgentTbl? Agent { get; set; }

    public virtual ICollection<FileDetailsTbl> FileDetailsTbls { get; set; } = new List<FileDetailsTbl>();

    public virtual InternationalExpertTbl? InternationalExpert { get; set; }

    public virtual JobGoalsTypeTbl JobGoal { get; set; } = null!;

    public virtual MainAdminTbl? MainAdmin { get; set; }

    public virtual ParticipantTbl Participant { get; set; } = null!;

    public virtual PassportTypeTbl PassportType { get; set; } = null!;

    public virtual ICollection<ReportTbl> ReportTbls { get; set; } = new List<ReportTbl>();

    public virtual RequestStatusTbl? RequestStatus { get; set; }

    public virtual RightOfCommutingTypeTbl? RightOfCommuting { get; set; }

    public virtual RightOfMissionTbl? RightOfMission { get; set; }

    public virtual RightToEducationTbl? RightToEducation { get; set; }

    public virtual TollAmountTypeTbl? TollAmount { get; set; }

    public virtual TravelGoalsTypeTbl TravelGoal { get; set; } = null!;

    public virtual TravelTypeTbl? TravelType { get; set; }

    public virtual TypeAccommodationTbl? TypeAccommodation { get; set; }
}
