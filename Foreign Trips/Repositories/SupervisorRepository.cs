using Foreign_Trips.DbContexts;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Foreign_Trips.Repositories
{
    public class SupervisorRepository : ISupervisorRepository
    {
        private readonly AgentDbContext _context;
        private readonly IAgentRepository _agentRepository;

        public SupervisorRepository(AgentDbContext context, IAgentRepository agentRepository)

        {
            _context = context ?? throw new ArgumentException(nameof(context));
            _agentRepository = agentRepository ??
        throw new ArgumentNullException(nameof(agentRepository));

        }

        public async Task<IEnumerable<SupervisorTbl?>> GetSupervisor()
        {
            try
            {
                return await _context.SupervisorTbl.ToListAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public async Task<SupervisorTbl?> GetSupervisor(int supervisorId)
        {
            return await _context.SupervisorTbl.Where(c => c.SupervisorId == supervisorId).FirstOrDefaultAsync();
        }


        public async Task<SupervisorTbl?> InsertSuperviser(SupervisorTbl supervisor)
        {
            try
            {

                SupervisorTbl supervisorTbl = new SupervisorTbl();
                supervisorTbl.SupervisorName = supervisor.SupervisorName;
                supervisorTbl.SupervisorUserName = supervisor.SupervisorUserName;
                supervisorTbl.Password = supervisor.Password;
                var exp = await _context.SupervisorTbl.AddAsync(supervisorTbl);
                await _context.SaveChangesAsync();
                return supervisorTbl;

            }

            catch (System.Exception ex)
            {
                return null;

            }
        }

        public async Task<SupervisorTbl?> UpdateSuperviserAsync(SupervisorTbl supervisor)
        {
            try
            {

                var sup = await _context.SupervisorTbl.FindAsync(supervisor.SupervisorId);
                sup.SupervisorName = supervisor.SupervisorName;
                sup.SupervisorUserName = supervisor.SupervisorUserName;
                sup.Password = supervisor.Password;
                await _context.SaveChangesAsync();


                return sup;

            }

            catch (System.Exception ex)
            {
                return null;

            };
        }

        public async Task<bool> SupervisorExistsAsync(int SupervisorId)
        {
            return await _context.SupervisorTbl.AnyAsync(c => c.SupervisorId == SupervisorId);
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
                data.SupervisorId = agent.SupervisorId;
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
                data.SupervisorId = agent.SupervisorId;
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
