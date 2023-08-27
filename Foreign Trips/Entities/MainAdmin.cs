namespace Foreign_Trips.Entities
{
    public class MainAdmin
    {
        public int SupervisorId { get; set; }

        public int? AdminId { get; set; }

        public int? AgentId { get; set; }

        public string SupervisorName { get; set; } = null!;

        public string SupervisorUserName { get; set; } = null!;

        public string Password { get; set; } = null!;

    }
}
