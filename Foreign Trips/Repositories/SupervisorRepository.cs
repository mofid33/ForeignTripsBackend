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

        public async Task<AgentTbl> InsertAgent(AgentTbl agent)
        {
            try
            {
                AgentTbl data = new AgentTbl();
                data.CityId = agent.CityId;
                data.AgentName = agent.AgentName;
                data.NationalCode = agent.NationalCode;
                data.Mobile = agent.Mobile;
                data.Phone = agent.Phone;
                data.CompanyName = agent.CompanyName;
                data.TypeOfEmployment = agent.TypeOfEmployment; 
                data.Email = agent.Email;

                await _context.SaveChangesAsync();
                return agent;

            }

            catch (System.Exception ex)
            {
                return null;

            }
        }

        public async Task<SupervisorTbl?> InsertSuperviser(SupervisorTbl supervisor)
        {
            try
            {


                var foreigntrip = await _context.SupervisorTbl.AddAsync(supervisor);
                await _context.SaveChangesAsync();


                return supervisor;

                //SupervisorAdminTbl supervisoradminTbl = new SupervisorAdminTbl();
                //supervisoradminTbl.SupervisorName = supervisor.SupervisorName;
                //supervisoradminTbl.SupervisorUserName = supervisor.SupervisorUserName;
                //supervisoradminTbl.Password = supervisor.Password;
                //var exp = await _context.SupervisorAdminTbl.AddAsync(supervisoradminTbl);
                //await _context.SaveChangesAsync();
                //return supervisoradminTbl;

            }

            catch (System.Exception ex)
            {
                return null;

            }
        }

        public async Task<bool> SupervisorExistsAsync(int SupervisorId)
        {
            return await _context.SupervisorTbl.AnyAsync(c => c.SupervisorId == SupervisorId);
        }

        public async Task<AgentTbl?> UpdateAgent(AgentTbl agent)
        {
            try
            {
                var data = await _agentRepository.GetAgentAsync(agent.AgentId);
                data.AgentName = agent.AgentName;
                data.NationalCode = agent.NationalCode;
                data.Mobile = agent.Mobile;


                await _context.SaveChangesAsync();
                return agent;

            }
            catch (System.Exception e)
            {
                return null;
            }
        }

        //public async Task UpdatePassAgentAsync(AgentTbl agent, long agentId)
        //{
        //    try
        //    {
        //        var data = await GetAgentAsync(agentId);
        //        //data.Password = organization.Password;
        //        await _context.SaveChangesAsync();


        //    }
        //    catch (System.Exception e)
        //    {
        //    }
        //}

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task<SupervisorTbl?> UpdateSuperviserAsync(SupervisorTbl supervisoradmin)
        {
            try
            {

                var sup = await _context.SupervisorTbl.FindAsync(supervisoradmin.SupervisorId);
                sup.SupervisorName = supervisoradmin.SupervisorName;
                sup.SupervisorUserName = supervisoradmin.SupervisorUserName;
                sup.Password = supervisoradmin.Password;
                await _context.SaveChangesAsync();


                return supervisoradmin;

            }

            catch (System.Exception ex)
            {
                return null;

            };
        }

    }
}
