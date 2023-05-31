namespace Foreign_Trips.Entities
{
    public class RequestDto
    {
        public int RequestId { get; set; }
        public int RequestStatusID { get; set; }
        public string RequestName { get; set; } = null!;
        public string NationalCode { get; set; } = null!;
        public string Role { get; set;} = null!;
        public string WorkLocation { get; set; } = null!;
        public string TypeOfEmployment { get; set; } = null!;
        public string TravelDate { get; set; } = null!;
        public string TravelTime { get; set; } = null!;
        public string TravelTopic { get; set; } = null!;
        public string DestinationCountry { get; set; } = null!;
        public string Payer { get; set; } = null!;
        public int TravelCost { get; set; } 
        public string RejectDescription { get; set; } = null!;
        public int AgentID { get; set; }
    }
    
}
