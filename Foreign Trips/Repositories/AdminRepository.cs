using Foreign_Trips.DbContexts;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;

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


        public async Task<LoginTbl?> GetUserLog(LoginTbl admin)
        {
            try
            {

                var adm = await _context.LoginTbl.Where(t => t.AgentId == admin.AgentId
                ).Include(t => t.AgentId)
                .OrderBy(t => t.LoginId).LastOrDefaultAsync();



                return adm;

            }

            catch (System.Exception ex)
            {
                return null;

            }
        }

        public async Task<IEnumerable<LoginRegDto?>> GetUser()
        {
            var agent = await _context.AgentTbl.ToListAsync();
            List<LoginRegDto> log = new List<LoginRegDto>();
            for (int i = 0; i < agent.Count; i++)
            {
                log.Add(new LoginRegDto
                {

                    Name = agent[i].AgentName,
                    AgentID = agent[i].AgentId,
                    Role = "Agent",
                    Mobile = agent[i].Mobile,
                    NationalCode = agent[i].NationalCode,
                    EditInfo = false,
                    CreateAgent = false
                });
            }
            return (IEnumerable<LoginRegDto>)log;
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

        public async Task RemoveAdmin(int adminId)
        {
            var data = _context.AdminTbl.Find(adminId);
            _context.AdminTbl.Remove(data);

            await _context.SaveChangesAsync();
        }

        public async Task<AdminTbl?> UpdateAdmin(AdminTbl admin)
        {
            try
            {

                var adm = await _context.AdminTbl.FindAsync(admin.AdminId);
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
