using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Foreign_Trips.Utility;

namespace Foreign_Trips.Repositories
{
    public interface IAgentRepository
    {
        Task<AgentPageDto> GetAgent(int page,int pageSize,String search);
        Task<IEnumerable<SubCategoryTbl>> GetSubCategory();
        Task<IEnumerable<PositionTypeTbl>> GetPosition();
        Task<IEnumerable<TypeOfEmploymentTbl>> GetTypeEmployment();
        Task<bool> AgentExistsAsync(long agentId);
        Task<AgentTbl?> GetAgentAsync(long agentId);
        Task<AgentDto> InsertAgentAsync(AgentDto agent);
        Task<AgentTbl?> UpdateAgentAsync(AgentTbl agentId);
        Task DeleteAgent(int agentId);
        Task<IEnumerable<CountryTbl>> GetCountriesAcync();
        Task<IEnumerable<CityTbl>> GetCitiesAcync(int? countryId);
        Task<IEnumerable<AgentStatusTbl>> GetAgentStatusAsync();
        Task<IEnumerable<TypeOfMissionTbl>> GetTypeOfMissionTblAsync();
        Task<IEnumerable<TypeOfEmploymentTbl>> TypeOfEmploymentTblAsync();
        Task<IEnumerable<PositionTypeTbl>> PositionTypeTblAsync();
        Task<IEnumerable<MaritalStatusTbl>> MaritalStatusTblAsync();
        Task<IEnumerable<LanguageTypeTbl>> LanguageTypeAsync();
        Task<string> GetAddress(AgentTbl postCode);
        Task UpdatePassAgentAsync(AgentTbl agent, long agentId);
        Task SuspendAgentAsync(long agentId);
        Task<bool> SaveChangesAsync();
    }
}
