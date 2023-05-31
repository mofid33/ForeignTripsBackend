namespace Foreign_Trips.Entities
{
    public class LoginRegDto
    {
        public long AgentID { get; set; }
        public string Role { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string NationalCode { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public bool? EditInfo { get; set; }
        public bool? CreateAgent { get; set; }


    }
}
