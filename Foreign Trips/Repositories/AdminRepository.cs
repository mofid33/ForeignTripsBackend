using Foreign_Trips.DbContexts;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Foreign_Trips.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AgentDbContext _context;
        private readonly IAgentRepository _agentRepository;
        
        public AdminRepository(AgentDbContext context, IAgentRepository agentRepository)

        {
            _context = context ?? throw new ArgumentException(nameof(context));
            _agentRepository = agentRepository ??
        throw new ArgumentNullException(nameof(agentRepository));

        }

        public async Task<bool> AdminExistsAsync(int adminId)
        {
            return await _context.AdminTbl.AnyAsync(f => f.AdminId == adminId);
        }

        public async Task<IEnumerable<AdminTbl?>> GetAdmins()
        {
            return await _context.AdminTbl.ToListAsync();
        }

        public async Task<IEnumerable<AgentTbl>> GetAgent()
        {
            try
            {

                return await _context.AgentTbl.ToListAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public async Task<LoginTbl?> GetUserLog(LoginTbl admin)
        {
            try
            {

                var adm = await _context.LoginTbl.Where(t => t.AgentId == admin.AgentId
                ).Include(t => t.Agent)
                .OrderBy(t => t.LoginId).LastOrDefaultAsync();



                return adm;

            }

            catch (System.Exception ex)
            {
                return null;

            }
        }
   

        public async Task<AdminTbl?> InsertAdmin(AdminTbl admin)
        {
            try
            {

                var foreigntrip = await _context.AdminTbl.AddAsync(admin);
                await _context.SaveChangesAsync();


                return admin;

            }

            catch (System.Exception ex)
            {
                return null;

            }
        }

       // public async Task RemoveAdmin(int adminId)
       // {
       //    var data = _context.AdminTbl.Find(adminId);
       //     _context.AdminTbl.Remove(data);

       //     await _context.SaveChangesAsync();
       //}

        public async Task<AdminTbl?> UpdateAdmin(AdminTbl admin)
        {
            try
            {

                var adm = await _context.AdminTbl.FindAsync(admin.AdminId);
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
