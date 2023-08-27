using Azure.Core;
using Foreign_Trips.DbContexts;
using Foreign_Trips.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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
                supervisorTbl.SupervisorName = supervisor.SupervisorName;
                supervisorTbl.SupervisorFamily= supervisor.SupervisorFamily;
                supervisorTbl.SupervisorUserName = supervisor.SupervisorUserName;
                supervisorTbl.Password = supervisor.Password;

                
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

                SupervisorTbl supervisorTbl = new SupervisorTbl();
                supervisorTbl.SupervisorName = supervisor.SupervisorName;
                supervisorTbl.SupervisorFamily = supervisor.SupervisorFamily;
                supervisorTbl.SupervisorUserName = supervisor.SupervisorUserName;
                supervisorTbl.Password = supervisor.Password;

                
                await _context.SaveChangesAsync();
                return supervisorTbl;

            }

            catch (System.Exception ex)
            {
                return null;

            }
        }

        public async Task<AgentTbl?> GetAgentAsync(int agentId)
        {

            return await _context.AgentTbl
             .Include(c => c.AgentName)
             .Include(x => x.AgentFamily)
             .Include(x => x.Position)
             .Include(c => c.SubCategory)
             .Include(c => c.CompanyName)


             .Where(c => c.AgentId == agentId).FirstOrDefaultAsync();


        }


        public async Task<Report?> GetReportAsync(int reportId)
        {
            return await _context.Report
             .Include(c => c.Request.Agent.AgentName)
             .Include(x => x.Request.Agent.AgentFamily)
             .Include(x => x.Request.TravelTopic)
             .Include(c => c.Request.Agent.Joblocation)
             .Include(c => c.LatestUpdate)
             .Include(c => c.ReportStatusId)


             .Where(c => c.ReportId == reportId).FirstOrDefaultAsync();

        }

        public async Task RemoveSupervisorAsync(int supervisorId)
        {
            var rsup = _context.SupervisorTbl.Find(supervisorId);
            _context.RequestTbl.Remove(rsup);

            await _context.SaveChangesAsync();
        }
    }
}
