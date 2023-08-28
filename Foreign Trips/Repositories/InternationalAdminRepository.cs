using Foreign_Trips.DbContexts;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Foreign_Trips.Repositories
{
    public class InternationalAdminRepository : IInternationalAdminRepository
    {
        private readonly AgentDbContext _context;
        private readonly IAgentRepository _agentRepository;
        
        public InternationalAdminRepository(AgentDbContext context, IAgentRepository agentRepository)

        {
            _context = context ?? throw new ArgumentException(nameof(context));
            _agentRepository = agentRepository ??
        throw new ArgumentNullException(nameof(agentRepository));

        }

        public async Task<bool> AdminExistsAsync(int adminId)
        {
            return await _context.InternationalAdminTbl.AnyAsync(f => f.AdminId == adminId);
        }

        public async Task<IEnumerable<InternationalAdminTbl?>> GetAdmins()
        {
            return await _context.InternationalAdminTbl.ToListAsync();
        }
    

        public async Task<InternationalAdminTbl?> InsertAdmin(InternationalAdminTbl admin)
        {
            try
            {

                var foreigntrip = await _context.InternationalAdminTbl.AddAsync(admin);
                await _context.SaveChangesAsync();


                return admin;

            }

            catch (System.Exception ex)
            {
                return null;

            }
        }

        public async Task RemoveAdmin(int adminId)
        {
            var data = _context.InternationalAdminTbl.Find(adminId);
            _context.InternationalAdminTbl.Remove(data);

            await _context.SaveChangesAsync();
        }

        public async Task<InternationalAdminTbl?> UpdateAdmin(InternationalAdminTbl admin)
        {
            try
            {

                var adm = await _context.InternationalAdminTbl.FindAsync(admin.AdminId);
                adm.AdminName = admin.AdminName;
                adm.AdminUsername = admin.AdminUsername;
                adm.Password = admin.Password;
                await _context.SaveChangesAsync();


                return admin;

            }

            catch (System.Exception ex)
            {
                return null;

            }
        }
    }
}
