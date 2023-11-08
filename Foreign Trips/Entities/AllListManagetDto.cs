namespace Foreign_Trips.Entities
{
    public class AllListManagetDto
    {
        public int InternationalExpertId { get; set; }

        public int AdminId { get; set; }

        public int SupervisorId { get; set; }

        public string Name { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string Role{ get; set; } = null!;

    }
}
