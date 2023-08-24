using Foreign_Trips.DbContexts;
using Foreign_Trips.Model;
using Microsoft.EntityFrameworkCore;

namespace Foreign_Trips.Repositories
{
    public class OverseerRepository : IOverseerRepository

    {
        private readonly AgentDbContext _context;
        private readonly IAgentRepository _agentRepository;

        public OverseerRepository(AgentDbContext context, IAgentRepository agentRepository)

        {
            _context = context ?? throw new ArgumentException(nameof(context));
            _agentRepository = agentRepository ??
        throw new ArgumentNullException(nameof(agentRepository));

        }
        public async Task<IEnumerable<OverseerTbl?>> GetOverseer()
        {
            try
            {
                return await _context.OverseerTbl.ToListAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public async Task<OverseerTbl?> GetOverseer(int overseerId)
        {
            return await _context.OverseerTbl.Where(c => c.OverseerId == overseerId).FirstOrDefaultAsync();
        }

        public async Task<OverseerTbl?> InsertOverseer(OverseerTbl overseer)
        {
            try
            {

                OverseerTbl overseerTbl = new OverseerTbl();
                overseerTbl.OverseerUserName = overseer.OverseerUserName;

                var exp = await _context.OverseerTbl.AddAsync(overseerTbl);
                await _context.SaveChangesAsync();
                return overseerTbl;

            }

            catch (System.Exception ex)
            {
                return null;

            }
        }

            public async Task<bool> OverseerExistsAsync(int overseerId)
        {
            return await _context.OverseerTbl.AnyAsync(c => c.OverseerId == overseerId);
        }

        public async Task<OverseerTbl?> UpdateOverseerAsync(OverseerTbl overseer)
        {
            try
            {

                var over = await _context.OverseerTbl.FindAsync(overseer.OverseerId);
                over.OverseerUserName = overseer.OverseerUserName;
                await _context.SaveChangesAsync();


                return over;

            }

            catch (System.Exception ex)
            {
                return null;

            };
        }
    }
}
