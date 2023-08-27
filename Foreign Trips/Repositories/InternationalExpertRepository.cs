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
            try
            {
                return await _context.InternationalExpertTbl.ToListAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public async Task<InternationalExpertTbl?> GetInternationalExpertAsync(int internationalExpertId)
        {
            return await _context.InternationalExpertTbl.Where(c => c.InternationalExpertId == internationalExpertId).FirstOrDefaultAsync();
        }

        public async Task<InternationalExpertTbl?> InsertInternationalExpert(InternationalExpertTbl internationalexpert)
        {
            try
            {

                InternationalExpertTbl Intexpert = new InternationalExpertTbl();
                Intexpert.InternationalExpertName = internationalexpert.InternationalExpertName;
                Intexpert.InternationalExpertFamily = internationalexpert.InternationalExpertFamily;
                Intexpert.InternationalExpertUserName = internationalexpert.InternationalExpertUserName;
                Intexpert.Password = internationalexpert.Password;



                await _context.InternationalExpertTbl.AddAsync(Intexpert);
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
                var Intexpert = await GetInternationalExpertAsync(internationalexpert.InternationalExpertId);
                Intexpert.InternationalExpertName = internationalexpert.InternationalExpertName;
                Intexpert.InternationalExpertFamily = internationalexpert.InternationalExpertFamily;
                Intexpert.InternationalExpertUserName = internationalexpert.InternationalExpertUserName;
                Intexpert.Password = internationalexpert.Password;


                await _context.SaveChangesAsync();
                return Intexpert;

            }
            catch (System.Exception e)
            {
                return null;
            }
        }
    }
    
}
