using Foreign_Trips.DbContexts;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Foreign_Trips.Repositories
{
    public class MainAdminRepository : IMainAdminRepository
    {
        private readonly AgentDbContext _context;
        private readonly IAgentRepository _agentRepository;

        public MainAdminRepository(AgentDbContext context, IAgentRepository agentRepository)

        {
            _context = context ?? throw new ArgumentException(nameof(context));
            _agentRepository = agentRepository ??
        throw new ArgumentNullException(nameof(agentRepository));

        }

        public async Task<IEnumerable<MainAdminTbl?>> GetMainAdmin()
        {
            try
            {
                return await _context.MainAdminTbl.ToListAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public async Task<MainAdminTbl?> GetMainAdminAsync(int mainadminId)
        {
            return await _context.MainAdminTbl.Where(c => c.MainAdminId == mainadminId).FirstOrDefaultAsync();
        }


        public async Task<MainAdminTbl?> InsertMainAdmin(MainAdminTbl mainadmin)
        {
            try
            {

                MainAdminTbl mainadminTbl = new MainAdminTbl();
                mainadminTbl.MainAdminName = mainadmin.MainAdminName;
                mainadminTbl.MainAdminUserName = mainadmin.MainAdminUserName;
                mainadminTbl.Password = mainadmin.Password;
                var exp = await _context.MainAdminTbl.AddAsync(mainadminTbl);
                await _context.SaveChangesAsync();
                return mainadminTbl;

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

                var main = await _context.MainAdminTbl.FindAsync(mainadmin.MainAdminId);
                main.MainAdminName = mainadmin.MainAdminName;
                main.MainAdminUserName = mainadmin.MainAdminUserName;
                main.Password = mainadmin.Password;
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
           
             return await _context.AgentTbl
            .Include(c => c.AgentName)
            .Include(x => x.AgentFamily)
            .Include(c => c.NationalCode)
            .Include(x => x.Position)
            .Include(c => c.Mobile)


            .Where(c => c.AgentId == agentId).FirstOrDefaultAsync();

        }

        public async Task<AgentTbl> InsertAgent(AgentTbl agent)
        {
            try
            {
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
                data.Password = agent.Password;



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
                data.Password = agent.Password;



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



        public async Task<bool> SaveChangesAsync()
            {
                return (await _context.SaveChangesAsync() > 0);
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

     
    }
}
