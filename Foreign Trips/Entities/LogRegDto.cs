namespace Foreign_Trips.Entities
{
    public class LogRegDto
    {
        public int ExpertID { get; set; }
        public long OrganizationID { get; set; }
        public string Role { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string NationalCode { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public bool? EditInfo { get; set; }
        public bool? CreateOrganization { get; set; }
    }
}
