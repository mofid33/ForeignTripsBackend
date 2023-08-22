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
        Task<AgentTbl?> UpdateAgentAsync(AgentTbl agentId);
        Task DeleteAgent(int agentId);
        Task<IEnumerable<ProvinceTbl>> GetProvincesAcync();
        Task<IEnumerable<CityTbl>> GetCitiesAcync(int? provinceId);
        Task<string> GetAddress(AgentTbl postCode);
        Task PostFileAsync(FileUploadModel fileData);
        Task PostMultiFileAsync(List<FileUploadModel> fileData);
        Task DownloadFileById(int fileName);
        Task<AgentTbl?> InsertPassPortAsync(AgentTbl agent);
        Task UpdatePassAgentAsync(AgentTbl agent, long agentId);
        Task SuspendAgentAsync(long agentId);
        Task<bool> SaveChangesAsync();
    }
}
