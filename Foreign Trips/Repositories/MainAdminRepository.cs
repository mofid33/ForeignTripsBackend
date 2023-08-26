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

        public async Task<MainAdminTbl?> GetMainAdmin(int mainadminId)
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
            try
            {
                var data = await _agentRepository.GetAgentAsync(agentId);

                await _context.SaveChangesAsync();
                return data;

            }
            catch (System.Exception e)
            {
                return null;
            }
        }

        public async Task<AgentTbl> InsertAgent(AgentTbl agent)
        {
            try
            {
                AgentTbl data = new AgentTbl();
                data.CityId = agent.CityId;
                data.TypeOfMissionId = agent.TypeOfMissionId;
                data.MainAdminId = agent.MainAdminId;
                data.PositionId = agent.PositionId;
                data.AgentStatusId = agent.AgentStatusId;
                data.AgentName = agent.AgentName;
                data.AgentFamily = agent.AgentFamily;
                data.NationalCode = agent.NationalCode;
                data.Mobile = agent.Mobile;
                data.Phone = agent.Phone;
                data.Address = agent.Address;
                data.Password = agent.Password;
                data.CompanyName = agent.CompanyName;
                data.TypeOfEmployment = agent.TypeOfEmployment;
                data.Email = agent.Email;
                data.PostalCode = agent.PostalCode;
                data.RegisterDate = agent.RegisterDate;
                data.RegisterTime = agent.RegisterTime;



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
                var data = await GetAgent(agent.AgentId);
                data.CityId = agent.CityId;
                data.TypeOfMissionId = agent.TypeOfMissionId;
                data.MainAdminId = agent.MainAdminId;
                data.PositionId = agent.PositionId;
                data.AgentStatusId = agent.AgentStatusId;
                data.AgentName = agent.AgentName;
                data.AgentFamily = agent.AgentFamily;
                data.NationalCode = agent.NationalCode;
                data.Mobile = agent.Mobile;
                data.Phone = agent.Phone;
                data.Address = agent.Address;
                data.Password = agent.Password;
                data.CompanyName = agent.CompanyName;
                data.TypeOfEmployment = agent.TypeOfEmployment;
                data.Email = agent.Email;
                data.PostalCode = agent.PostalCode;
                data.RegisterDate = agent.RegisterDate;
                data.RegisterTime = agent.RegisterTime;


                await _context.SaveChangesAsync();
                return agent;

            }
            catch (System.Exception e)
            {
                return null;
            }
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
