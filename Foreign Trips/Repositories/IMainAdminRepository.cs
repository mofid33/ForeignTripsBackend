using Foreign_Trips.Entities;
using Foreign_Trips.Model;

namespace Foreign_Trips.Repositories
{
    public interface IMainAdminRepository
    {
        Task<bool> MainAdminExistsAsync(int mainadminId);
        Task<IEnumerable<MainAdminTbl?>> GetMainAdmin();
        Task<MainAdminTbl?> GetMainAdminAsync(int  mainadminId);
        Task<MainAdminTbl?> InsertMainAdmin(MainAdminTbl mainadmin);
        Task<MainAdminTbl?> UpdateMainAdminAsync(MainAdminTbl mainadmin);
        Task UpdatePassAgentAsync(int agentId);
        Task<AgentTbl?> GetAgent(int agentId);
        Task<AgentTbl?> InsertAgent(AgentTbl agent);
        Task<AgentTbl?> UpdateAgent(AgentTbl agent);
        Task<AgentTbl?> DeleteAgent(int agentId);
        Task<IEnumerable<LoginRegDto?>> GetUser();
        Task<LoginTbl?> GetUserLog(LoginTbl id);
        Task<bool> SaveChangesAsync();
    }
}
