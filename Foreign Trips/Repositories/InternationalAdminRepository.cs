using Foreign_Trips.DbContexts;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Runtime.Intrinsics.Arm;

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

        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }


        public async Task<InternationalAdminDto> InsertAdmin(InternationalAdminDto admin)
        {
            try
            {
                    byte[] passwordHash, passwordSalt;
                    CreatePasswordHash(admin.Password.ToString(), out passwordHash, out passwordSalt);
                    InternationalAdminTbl adm = new InternationalAdminTbl();
                    adm.AdminName = admin.AdminName;
                    adm.AdminUsername = admin.AdminUsername;
                    adm.Password = passwordHash;
                    adm.PasswordSalt = passwordSalt;



                    await _context.InternationalAdminTbl.AddAsync(adm);
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
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(admin.Password.ToString(), out passwordHash, out passwordSalt);
                var adm = await _context.InternationalAdminTbl.FindAsync(admin.AdminId);
                adm.AdminName = admin.AdminName;
                adm.AdminUsername = admin.AdminUsername;
                adm.Password = passwordHash;
                adm.PasswordSalt = passwordSalt;
                DateTime dt = new DateTime();
                PersianDateTime persianDateTime = new PersianDateTime(DateTime.Now);
                string date = persianDateTime.ToString().Substring(0, 10);

                adm.RegisterTime = DateTime.Now.ToShortTimeString();
                adm.RegisterDate = date;

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
