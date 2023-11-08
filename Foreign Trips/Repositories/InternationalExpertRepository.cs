using Foreign_Trips.DbContexts;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Foreign_Trips.Utility;
using Microsoft.EntityFrameworkCore;
using ShenaseMeliBac.Profiles;

namespace Foreign_Trips.Repositories
{
    public class InternationalExpertRepository : IInternationalExpertRepository
    {
        private readonly AgentDbContext _context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public InternationalExpertRepository(AgentDbContext context, IAgentRepository agentRepository, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)

        {
            _context = context ?? throw new ArgumentException(nameof(context));
            _hostingEnvironment = hostingEnvironment ??
             throw new ArgumentNullException(nameof(hostingEnvironment));
        }
        public async Task<InternationalExpertPageDto> GetInternationalExpert(int page, int pageSize, string search)
        {
            try
            {
                var Intexp = await _context.InternationalExpertTbl
                .Where(t => (search != "" && search != null) ? (t.InternationalExpertName == search || t.InternationalExpertFamily == search) : t.InternationalExpertName != null).ToListAsync();

                 var ss = await PaginatedList<InternationalExpertTbl>.CreateAsync(Intexp, page, pageSize);
                return new InternationalExpertPageDto
                {
                    Count = Intexp.Count(),
                    Data = ss

                };
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


        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<InternationalExpertDto> InsertInternationalExpert(InternationalExpertDto internationalexpert)
        {
            try
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(internationalexpert.Password.ToString(), out passwordHash, out passwordSalt);
                InternationalExpertTbl Intexpert = new InternationalExpertTbl();
                Intexpert.InternationalExpertName = internationalexpert.InternationalExpertName;
                Intexpert.InternationalExpertFamily = internationalexpert.InternationalExpertFamily;
                Intexpert.InternationalExpertUserName = internationalexpert.InternationalExpertUserName;
                Intexpert.Password = passwordHash;
                Intexpert.PasswordSalt = passwordSalt;
                DateTime dt = new DateTime();
                PersianDateTime persianDateTime = new PersianDateTime(DateTime.Now);
                string date = persianDateTime.ToString().Substring(0, 10);

                Intexpert.RegisterTime = DateTime.Now.ToShortTimeString();
                Intexpert.RegisterDate = date;


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

        public async Task<string> RemoveInternationalExpert(int internationalexpertId)
        {
            try 
            {
                var data = _context.InternationalExpertTbl.Find(internationalexpertId);
                _context.InternationalExpertTbl.Remove(data);

                await _context.SaveChangesAsync();
                return "ok";
            }

            catch (System.Exception ex)
            {
                return null;

            }



        }

        public async Task<InternationalExpertTbl?> UpdateInternationalExpert(InternationalExpertTbl internationalexpert)
        {
            try
            {

                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(internationalexpert.Password.ToString(), out passwordHash, out passwordSalt);
                var Intexpert = await GetInternationalExpertAsync(internationalexpert.InternationalExpertId);
                Intexpert.InternationalExpertName = internationalexpert.InternationalExpertName;
                Intexpert.InternationalExpertFamily = internationalexpert.InternationalExpertFamily;
                Intexpert.InternationalExpertUserName = internationalexpert.InternationalExpertUserName;
                Intexpert.Password = passwordHash;
                Intexpert.PasswordSalt = passwordSalt;


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
