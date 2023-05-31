namespace Foreign_Trips.Entities
{
    public class RequestTravelDto
    {
        public int RequestTravelId { get; set; }
        public int NameAgent { get; set; }
        public string NationalCode { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string TravelDate { get; set; } = null!;
        public string TravelTime { get; set; } = null!;
        public string TravelTopic { get; set; } = null!;
        public string TypeOfEmployment { get; set; } = null!;
        public string DestinationCountry { get; set; } = null!;
        public string PersonUpName { get; set; } = null!;
        public string TravelExpensePayer { get; set; } = null!;
        public bool IsFinal { get; set; } 
    }
}

