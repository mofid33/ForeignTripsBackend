﻿using Foreign_Trips.Entities;
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
        Task<IEnumerable<AgentStatusTbl>> GetAgentStatusAsync();
        Task<IEnumerable<TypeOfMissionTbl>> GetTypeOfMissionTblAsync();
        Task<IEnumerable<TypeOfEmploymentTbl>> TypeOfEmploymentTblAsync();
        Task<IEnumerable<PositionTypeTbl>> PositionTypeTblAsync();
        Task<string> GetAddress(AgentTbl postCode);
        Task PostFileAsync(FileUploadModel fileData);
        Task PostMultiFileAsync(List<FileUploadModel> fileData);
        Task DownloadFileById(int fileName);
        Task UpdatePassAgentAsync(AgentTbl agent, long agentId);
        Task<bool> SaveChangesAsync();
    }
}
