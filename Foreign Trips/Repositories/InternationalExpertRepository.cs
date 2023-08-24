using Foreign_Trips.DbContexts;
using Foreign_Trips.Model;
using Microsoft.EntityFrameworkCore;

namespace Foreign_Trips.Repositories
{
    public class InternationalExpertRepository : IInternationalExpertRepository
    {
        private readonly AgentDbContext _context;
        private readonly IAgentRepository _agentRepository;

        public InternationalExpertRepository(AgentDbContext context, IAgentRepository agentRepository)

        {
            _context = context ?? throw new ArgumentException(nameof(context));
            _agentRepository = agentRepository ??
        throw new ArgumentNullException(nameof(agentRepository));

        }
        public async Task<IEnumerable<InternationalExpertTbl?>> GetInternationalExpert()
        {
            return await _context.InternationalExpertTbl.ToListAsync();
        }

        public Task<InternationalExpertTbl?> GetInternationalExpert(int internationalExpertId)
        {
            throw new NotImplementedException();
        }

        public async Task<InternationalExpertTbl?> InsertInternationalExpert(InternationalExpertTbl internationalexpert)
        {
            try
            {

                var inter = await _context.InternationalExpertTbl.AddAsync(internationalexpert);
                await _context.SaveChangesAsync();


                return internationalexpert;

            }

            catch (System.Exception ex)
            {
                return null;

            }
        }
    

        public async Task<bool> InternationalExpertExistsAsync(int internationalexpertId)
        {

            return await _context.InternationalExpertTbl.AnyAsync(f => f.InternationalExpertId == internationalexpertId);
        }

        public async Task RemoveInternationalExpert(int internationalexpertId)
        {
            var data = _context.InternationalAdminTbl.Find(internationalexpertId);
            _context.InternationalAdminTbl.Remove(data);

            await _context.SaveChangesAsync();
        }

        public async Task<InternationalExpertTbl?> UpdateInternationalExpert(InternationalExpertTbl internationalexpert)
        {
            try
            {

                var Intexpert = await _context.InternationalExpertTbl.FindAsync(internationalexpert.InternationalExpertId);
                Intexpert.InternationalExpertUserName = internationalexpert.InternationalExpertUserName;
                await _context.SaveChangesAsync();


                return Intexpert;

            }

            catch (System.Exception ex)
            {
                return null;

            }
        }
    }
    
}
