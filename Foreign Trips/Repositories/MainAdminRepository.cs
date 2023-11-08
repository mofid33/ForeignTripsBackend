using Foreign_Trips.DbContexts;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Foreign_Trips.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics.Eventing.Reader;
using System.Xml.Linq;
using static NPOI.HSSF.Util.HSSFColor;

namespace Foreign_Trips.Repositories
{
    public class MainAdminRepository : IMainAdminRepository
    {
        private readonly AgentDbContext _context;
        private readonly IAgentRepository _agentRepository;
        private readonly IInternationalExpertRepository _internationalexpertRepository;
        private readonly IInternationalAdminRepository _internationaladminRepository;
        private readonly ISupervisorRepository _supervisorRepository;
        public MainAdminRepository(AgentDbContext context, IAgentRepository agentRepository,IInternationalExpertRepository internationalexpertRepository, IInternationalAdminRepository internationaladminRepository, ISupervisorRepository supervisorRepository)

        {
            _context = context ?? throw new ArgumentException(nameof(context));
            _agentRepository = agentRepository ?? throw new ArgumentNullException(nameof(agentRepository));
            _internationalexpertRepository = internationalexpertRepository ?? throw new ArgumentNullException(nameof(internationalexpertRepository));
            _internationaladminRepository = internationaladminRepository ?? throw new ArgumentNullException(nameof(internationaladminRepository));
            _supervisorRepository = supervisorRepository ?? throw new ArgumentNullException(nameof(supervisorRepository));
        }


        public async Task<MainAdminPageDto> GetMainAdmin(int page, int pageSize, string search)
        {
            try
            {
                var mainadmin = await _context.MainAdminTbl
                .Where(t => (search != "" && search != null) ? (t.MainAdminName.Contains(search) || t.MainAdminUserName.Contains(search)) : t.MainAdminName != null)


                    .ToListAsync();

                var ss = await PaginatedList<MainAdminTbl>.CreateAsync(mainadmin, page, pageSize);
                return new MainAdminPageDto
                {
                    Count = mainadmin.Count(),
                    Data = ss

                };
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }


        public async Task<MainAdminTbl?> GetMainAdminAsync(int mainadminId)
        {
            try
            {
                return await _context.MainAdminTbl.Where(c => c.MainAdminId == mainadminId).FirstOrDefaultAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<AllListManagetDto?>> GetAllManagerList()
        {
            try
            {
               List<AllListManagetDto> list = new List<AllListManagetDto>();
                var Intexp = await _context.InternationalExpertTbl.ToListAsync();

                foreach (var allList in Intexp)
                {
                    AllListManagetDto list2 = new AllListManagetDto();

                    list2.Name = allList.InternationalExpertName + " "+allList.InternationalExpertFamily;
                    list2.Role = "InternationalExpert";
                    list2.InternationalExpertId = allList.InternationalExpertId;
                    list2.Username = allList.InternationalExpertUserName;
                    list.Add(list2);
               
                }


                var Intadm = await _context.InternationalAdminTbl.ToListAsync();
                foreach (var allList in Intadm)
                {
                    AllListManagetDto list3 = new AllListManagetDto();
                    list3.Name = allList.AdminName;
                    list3.Role = "InternationalAdmin";
                    list3.AdminId = allList.AdminId;
                    list3.Username = allList.AdminUsername;
                    list.Add(list3);
                }


                var Sup = await _context.SupervisorTbl.ToListAsync();
                foreach (var allList in Sup)
                {
                    AllListManagetDto list4 = new AllListManagetDto();
                    list4.Name = allList.SupervisorName + " " + allList.SupervisorFamily;
                    list4.Role = "Supervisor";
                    list4.SupervisorId = allList.SupervisorId;
                    list4.Username = allList.SupervisorName;
                    list.Add(list4);
                }
                return list;
            }

            catch (System.Exception ex)
            {
                return null;
            }

        }

        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }


        public async Task<MainAdminDto> InsertMainAdmin(MainAdminDto mainadmin)
        {
            try
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(mainadmin.Password.ToString(), out passwordHash, out passwordSalt);
                MainAdminTbl mainadminTbl = new MainAdminTbl();
                mainadminTbl.MainAdminName = mainadmin.MainAdminName;
                mainadminTbl.MainAdminUserName = mainadmin.MainAdminUserName;
                mainadminTbl.Password = passwordHash;
                mainadminTbl.PasswordSalt = passwordSalt;

                await _context.MainAdminTbl.AddAsync(mainadminTbl);
                await _context.SaveChangesAsync();
                return mainadmin;

            }

            catch (System.Exception ex)
            {
                return null;

            }
        }

        public async Task<MainAdminTbl?> UpdateMainAdminAsync(MainAdminTbl mainadmin)
        {
            try
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(mainadmin.Password.ToString(), out passwordHash, out passwordSalt);
                var main = await _context.MainAdminTbl.FindAsync(mainadmin.MainAdminId);
                main.MainAdminName = mainadmin.MainAdminName;
                main.MainAdminUserName = mainadmin.MainAdminUserName;
                main.Password = passwordHash;
                main.PasswordSalt = passwordSalt;
                await _context.SaveChangesAsync();


                return main;

            }

            catch (System.Exception ex)
            {
                return null;

            };
        }

        public async Task<bool> MainAdminExistsAsync(int mainadminId)
        {
            return await _context.MainAdminTbl.AnyAsync(c => c.MainAdminId == mainadminId);
        }



        public async Task<AgentTbl?> GetAgent(int agentId)
        {
            try
            {

                return await _context.AgentTbl
               .Include(c => c.AgentName)
               .Include(x => x.AgentFamily)
               .Include(c => c.NationalCode)
               .Include(x => x.Position)
               .Include(c => c.Mobile)


               .Where(c => c.AgentId == agentId).FirstOrDefaultAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }

        }

        public async Task<AgentTbl> InsertAgent(AgentTbl agent)
        {
            try
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(agent.Password.ToString(), out passwordHash, out passwordSalt);
                AgentTbl data = new AgentTbl();
                data.NationalCode = agent.NationalCode;
                data.DateOfBirth = agent.DateOfBirth;
                data.AgentName = agent.AgentName;
                data.AgentFamily = agent.AgentFamily;
                data.AgentStatusId = agent.AgentStatusId;
                data.AgentName = agent.AgentName;
                data.AgentFamily = agent.AgentFamily;
                data.Mobile = agent.Mobile;
                data.Mobile = agent.Mobile;
                data.Phone = agent.Phone;
                data.Email = agent.Email;
                data.PostalCode= agent.PostalCode;
                data.Address = agent.Address;
                data.SubCategoryId = agent.SubCategoryId;
                data.Subset = agent.Subset;
                data.TypeOfEmploymentId = agent.TypeOfEmploymentId;
                data.Position = agent.Position;
                data.Password = passwordHash;
                data.PasswordSalt = passwordSalt;
                DateTime dt = new DateTime();
                PersianDateTime persianDateTime = new PersianDateTime(DateTime.Now);
                string date = persianDateTime.ToString().Substring(0, 10);

                data.RegisterTime = DateTime.Now.ToShortTimeString();
                data.RegisterDate = date;



                await _context.SaveChangesAsync();
                return agent;

            }

            catch (System.Exception ex)
            {
                return null;

            }
        }


        public async Task<AgentTbl?> DeleteAgent(int agentId)
        {

            try
            {
                var data = await _agentRepository.GetAgentAsync(agentId);
                _context.AgentTbl.Remove(data);

                await _context.SaveChangesAsync();
                return data;

            }

            catch (System.Exception ex)
            {
                return null;

            }

        }

        public async Task<AgentTbl?> UpdateAgent(AgentTbl agent)
        {
            try
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(agent.Password.ToString(), out passwordHash, out passwordSalt);
                AgentTbl data = new AgentTbl();
                data.NationalCode = agent.NationalCode;
                data.DateOfBirth = agent.DateOfBirth;
                data.AgentName = agent.AgentName;
                data.AgentFamily = agent.AgentFamily;
                data.AgentStatusId = agent.AgentStatusId;
                data.AgentName = agent.AgentName;
                data.AgentFamily = agent.AgentFamily;
                data.Mobile = agent.Mobile;
                data.Mobile = agent.Mobile;
                data.Phone = agent.Phone;
                data.Email = agent.Email;
                data.PostalCode = agent.PostalCode;
                data.Address = agent.Address;
                data.SubCategoryId = agent.SubCategoryId;
                data.Subset = agent.Subset;
                data.TypeOfEmploymentId = agent.TypeOfEmploymentId;
                data.Position = agent.Position;
                data.Password = passwordHash;
                data.PasswordSalt = passwordSalt;



                await _context.SaveChangesAsync();
                return agent;

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
            try
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
            catch (System.Exception ex)
            {
                return null;
            }
        }


            public async Task UpdatePassAgentAsync(int agentId)
            {
                try
                {
                    var data = await GetAgent(agentId);
                    //data.Password = organization.Password;
                    await _context.SaveChangesAsync();


                }
                catch (System.Exception e)
                {
                }
            }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
