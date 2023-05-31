using Foreign_Trips.Entities;
using Foreign_Trips.Model;

namespace Foreign_Trips.Repositories
{
    public interface IAgentRepository
    {
        Task<IEnumerable<AgentTbl>> GetAgent();
        Task<bool> AgentExistsAsync(long agentId);
        Task<AgentTbl?> GetAgentAsync(long agentId);
        Task<AgentTbl?> InsertAgentAsync(AgentTbl agent);
        Task<AgentDto?> UpdateAgentAsync(AgentDto agent, long agentId);
        Task UpdatePassAgentAsync(AgentDto agent, long oagentId);
        Task RemoveAgentAsync(int agentId);
        Task<IEnumerable<RequestStatusTbl>> GetRequestStatusAsync();
        Task<IEnumerable<ProvinceTbl>> GetProvincesAcync();
        Task<IEnumerable<CityTbl>> GetCitiesAcync(int? provinceId);
        Task<bool> SaveChangesAsync();
       
    }
}
