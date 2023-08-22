using Foreign_Trips.Model;

namespace Foreign_Trips.Entities
{
    public class ForeignDelegrationDto
    {
        public int ForeignDelegationId { get; set; }

        public int CityId { get; set; }

        public string Sex { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string SurName { get; set; } = null!;

        public string FatherSName { get; set; } = null!;

        public string DateOfBirth { get; set; } = null!;

        public string PlaceOfBirth { get; set; } = null!;

        public string Nationality { get; set; } = null!;

        public int PassportNo { get; set; }

        public string TypeOfPassport { get; set; } = null!;

        public string DateOfIssue { get; set; } = null!;

        public string PlaceOfIssue { get; set; } = null!;

        public string ExpiryDate { get; set; } = null!;

        public string Occupation { get; set; } = null!;

        public string Organization { get; set; } = null!;

        public string PlaceVisaToBeIssued { get; set; } = null!;

        public string DurationOfStayInIran { get; set; } = null!;

        public string ThePreviouseDateOfEntryToIran { get; set; } = null!;

        public string EmailAddress { get; set; } = null!;

        public string LandlineNumber { get; set; } = null!;

        public string MobileNumber { get; set; } = null!;

        public string HostName { get; set; } = null!;

        public string HostLandlineNumber { get; set; } = null!;

        public string HostMobileNumber { get; set; } = null!;

    }
}
