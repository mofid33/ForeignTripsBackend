using Foreign_Trips.DbContexts;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Foreign_Trips.Repositories
{
    public class AgentRepository : IAgentRepository
    {
        private readonly AgentDbContext _context;

        public AgentRepository(AgentDbContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
        }

        public async Task<bool> AgentExistsAsync(long agentId)
        {
            return await _context.AgentTbl.AnyAsync(f => f.AgentId == agentId);
        }

        public async Task<AgentTbl?> GetAgentAsync(long agentId)
        {
            return await _context.AgentTbl.Include(x => x.LoginTbls).Where(f => f.AgentId == agentId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<AgentTbl>> GetAgent()
        {
            try
            {

            return await _context.AgentTbl.ToListAsync();
            }
            catch(System.Exception ex)
            {
                return null;
            }
        }

        public async Task<AgentTbl?> InsertAgentAsync(AgentTbl agent)
        {
            try
            {
                await _context.AgentTbl.AddAsync(agent);
                await _context.SaveChangesAsync();
                return agent;

            }

            catch (System.Exception ex)
            {
                return null;

            }
        }

        public async Task<AgentDto?> UpdateAgentAsync(AgentDto agent, long agentId)
        {
            try
            {
                var data = await GetAgentAsync(agentId);
                data.AgentName = agent.AgentName;
                data.NationalCode = agent.NationalCode;
                data.Mobile = agent.Mobile;
                data.RegisterDate = agent.RegisterDate;
                data.ProvinceCertificateId = agent.ProvinceCertificateID;
                data.CittyCertificateId = agent.CityCertificateID;
                data.ProviceBirthCertificateIssuingPlace = agent.ProvinceBirthCertificateIssuingPlace;
                data.CityBirthCertificateIssuingPlace = agent.CityCertificateIssuingPlace;
                data.BirthCertificateId = agent.BirthCertificateID;
        

                await _context.SaveChangesAsync();
                return agent;

            }
            catch (System.Exception e)
            {
                return null;
            }
        }


        public async Task UpdatePassAgentAsync(AgentDto agent, long agentId)
        {
            try
            {
                var data = await GetAgentAsync(agentId);
                data.Password = agent.Password;


                await _context.SaveChangesAsync();


            }
            catch (System.Exception e)
            {
            }
        }
  

        public async Task RemoveAgentAsync(int agentId)
        {
            var data = _context.AgentTbl.Find(agentId);
            _context.AgentTbl.Remove(data);

            await _context.SaveChangesAsync();
        }

        
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task<IEnumerable<RequestStatusTbl>> GetRequestStatusAsync()
        {
            return await _context.RequestStatusTbl.ToListAsync();
        }

        public async Task<IEnumerable<ProvinceTbl>> GetProvincesAcync()
        {
            return await _context.ProvinceTbl.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<CityTbl>> GetCitiesAcync(int? provinceId)
        {
            return await _context.CityTbl
             .AsNoTracking()
             .Where(c => c.ProvinceId == provinceId).ToListAsync();
        }

    }
}
