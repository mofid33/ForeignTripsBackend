using Foreign_Trips.DbContexts;
using Foreign_Trips.Model;
using Microsoft.EntityFrameworkCore;

namespace Foreign_Trips.Repositories
{
    public class SupervisorRepository : ISupervisorRepository

    {
        private readonly AgentDbContext _context;
        private readonly IAgentRepository _agentRepository;

        public SupervisorRepository(AgentDbContext context, IAgentRepository agentRepository)

        {
            _context = context ?? throw new ArgumentException(nameof(context));
            _agentRepository = agentRepository ??
        throw new ArgumentNullException(nameof(agentRepository));

        }
        public async Task<IEnumerable<SupervisorTbl?>> GetSupervisor()
        {
            try
            {
                return await _context.SupervisorTbl.ToListAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public async Task<SupervisorTbl?> GetSupervisor(int supervisorId)
        {
            return await _context.SupervisorTbl.Where(c => c.SupervisorId == supervisorId).FirstOrDefaultAsync();
        }

        public async Task<SupervisorTbl?> InsertSupervisor(SupervisorTbl supervisor)
        {
            try
            {

                SupervisorTbl supervisorTbl = new SupervisorTbl();
                supervisorTbl.SupervisorUserName = supervisor.SupervisorUserName;

                var exp = await _context.SupervisorTbl.AddAsync(supervisorTbl);
                await _context.SaveChangesAsync();
                return supervisorTbl;

            }

            catch (System.Exception ex)
            {
                return null;

            }
        }

            public async Task<bool> SupervisorExistsAsync(int supervisorId)
        {
            return await _context.SupervisorTbl.AnyAsync(c => c.SupervisorId == supervisorId);
        }

        public async Task<SupervisorTbl?> UpdateSupervisorAsync(SupervisorTbl supervisor)
        {
            try
            {

                var over = await _context.SupervisorTbl.FindAsync(supervisor.SupervisorId);
                over.SupervisorUserName = supervisor.SupervisorUserName;
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
