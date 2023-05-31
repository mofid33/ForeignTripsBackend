using Foreign_Trips.Model;
using Microsoft.EntityFrameworkCore;

namespace Foreign_Trips.DbContexts
{
    public class AgentDbContext : DbContext
    {
        public AgentDbContext
            (DbContextOptions<AgentDbContext> options)
            : base(options)
        {

        }
        public DbSet<AdminTbl> AdminTbl { get; set; } = null!;
        public DbSet<AgentTbl> AgentTbl { get; set; } = null!;
        public DbSet<LoginTbl> LoginTbl { get; set; } = null!;
        public DbSet<RequestStatusTbl> RequestStatusTbl { get; set; } = null!;
        public DbSet<RequestTbl> RequestTbl { get; set; } = null!;
        public DbSet<RequestTravelTbl> RequestTravelTbl { get; set; } = null!;
        public DbSet<ProvinceTbl> ProvinceTbl { get; set; } = null!;
        public DbSet<CityTbl> CityTbl { get; set; } = null!;

    }
}
