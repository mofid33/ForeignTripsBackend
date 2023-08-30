using System;
using System.Collections.Generic;

namespace Foreign_Trips.Model;

public partial class RequestTbl
{
    public int RequestId { get; set; }

    public int AgentId { get; set; }

    public int RequestStatusId { get; set; }

    public string ExecutiveDeviceName { get; set; } = null!;

    public string InternetAddressOfTheExecutiveDevice { get; set; } = null!;

    public string DestinationCity { get; set; } = null!;

    public string DestinationCountry { get; set; } = null!;

    public string FlightPath { get; set; } = null!;

    public string TravelDate { get; set; } = null!;

    public string TravelTime { get; set; } = null!;

    public string TravelTopic { get; set; } = null!;

    public int TravelGoalId { get; set; }

    public int JobGoalId { get; set; }

    public int DeviceNameId { get; set; }

    public int PassportTypeId { get; set; }

    public bool GetVisa { get; set; }

    public bool JointTrip { get; set; }

    public bool DateLetter { get; set; }

    public string PayerCitizenShip { get; set; } = null!;

    public string AmountOfCost { get; set; } = null!;

    public string PayerFood { get; set; } = null!;

    public string CostOfFood { get; set; } = null!;

    public string TickerTypeId { get; set; } = null!;

    public string AirlineCompany { get; set; } = null!;

    public string TicketCost { get; set; } = null!;

    public string TheCostOfTicket { get; set; } = null!;

    public int RightOfMissionId { get; set; }

    public string LevelRightOfMission { get; set; } = null!;

    public string ExpertRightOfMission { get; set; } = null!;

    public string RightToEducationCost { get; set; } = null!;

    public int RightToEducationId { get; set; }

    public string RightOfCommutingCost { get; set; } = null!;

    public int RightOfCommutingId { get; set; }

    public string VisaCost { get; set; } = null!;

    public string TollAmountCost { get; set; } = null!;

    public int TollAmountId { get; set; }

    public string PaymentFromBank { get; set; } = null!;

    public string ImportantTravel { get; set; } = null!;

    public string MissionAchievementRecords { get; set; } = null!;

    public string SummaryInvitation { get; set; } = null!;

    public string ForeignTravelSummary { get; set; } = null!;

    public bool ReferenceDeviceAgreement { get; set; }

    public bool ResistanceEconomyTravel { get; set; }

    public string RejectRequest { get; set; } = null!;

    public string DateOfLasteChange { get; set; } = null!;

    public string OperationId { get; set; } = null!;

    public int TravelTypeId { get; set; }

    public string ApprovedBy { get; set; } = null!;

    public string EmployeeStatus { get; set; } = null!;

    public bool IsFinal { get; set; }

    public virtual AgentTbl Agent { get; set; } = null!;

    public virtual DeviceNameItypeTbl DeviceName { get; set; } = null!;

    public virtual ICollection<FileDetailsTbl> FileDetailsTbls { get; set; } = new List<FileDetailsTbl>();

    public virtual JobGoalsTypeTbl JobGoal { get; set; } = null!;

    public virtual PassportType PassportType { get; set; } = null!;

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual RequestStatusTbl RequestStatus { get; set; } = null!;

    public virtual RightOfCommutingTypeTbl RightOfCommuting { get; set; } = null!;

    public virtual RightOfMissionTbl RightOfMission { get; set; } = null!;

    public virtual RightToEducationTbl RightToEducation { get; set; } = null!;

    public virtual TollAmountTypeTbl TollAmount { get; set; } = null!;

    public virtual TravelGoalsTypeTbl TravelGoal { get; set; } = null!;

    public virtual TravelTypeTbl TravelType { get; set; } = null!;
}
