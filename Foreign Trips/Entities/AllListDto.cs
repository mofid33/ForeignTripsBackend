using Foreign_Trips.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Foreign_Trips.Entities
{
    public class AllListDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestId { get; set; }

        public int? AgentId { get; set; }

        public int? RequestStatusId { get; set; }

        public string ExecutiveDeviceName { get; set; } = null!;

        public string InternetAddressOfTheExecutiveDevice { get; set; } = null!;

        public string FlightPath { get; set; } = null!;

        public string TravelDateStart { get; set; } = null!;

        public string TravelTime { get; set; } = null!;

        public string TravelTopic { get; set; } = null!;

        public string TravelGoalId { get; set; } = null!;

        public string JobGoalId { get; set; } = null!;

        public int ParticipantId { get; set; }

        public string PassportTypeId { get; set; } = null!;

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

        public string? RightOfMissionId { get; set; }

        public string? ManagerRightOfMission { get; set; }

        public string? ExpertRightOfMission { get; set; }

        public string? RightToEducationApplicantCost { get; set; }

        public string? RightToEducationId { get; set; }

        public string? RightOfCommutingInternalDeviceCost { get; set; }

        public string? RightOfCommutingId { get; set; }

        public string? VisaCost { get; set; }

        public string? TollAmountPersonCost { get; set; }

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

        public string? ActivityRecords { get; set; }

        public string? Results { get; set; }

        public string? Discription { get; set; }

        public string? ExternalDeviceNameAndEmail { get; set; }

        public string? DelayReason { get; set; }

        public int? CityId { get; set; }

        public string? RightToEducationInternalDeviceCost { get; set; }

        public string? RightOfCommutingPersonCost { get; set; }

        public string? RightOfCommutingExternalCost { get; set; }

        public string? TollAmountDeviceCost { get; set; }


    }
}
