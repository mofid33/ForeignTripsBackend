using Foreign_Trips.Entities;
using Foreign_Trips.Model;

namespace Foreign_Trips.Repositories
{
    public interface ISupervisorRepository
    {
        Task<bool> SupervisorExistsAsync(int supervisorId);
        Task<IEnumerable<SupervisorTbl?>> GetSupervisor();
        Task<SupervisorTbl?> GetSupervisor(int  supervisorId);
        Task<SupervisorTbl?> InsertSuperviser(SupervisorTbl supervisor);
        Task<SupervisorTbl?> UpdateSuperviserAsync(SupervisorTbl supervisor);
        Task UpdatePassAgentAsync(int agentId);
        Task<AgentTbl?> GetAgent(int agentId);
        Task<AgentTbl?> InsertAgent(AgentTbl agent);
        Task<AgentTbl?> UpdateAgent(AgentTbl agent);
        Task<AgentTbl?> DeleteAgent(int agentId);
        Task<bool> SaveChangesAsync();
    }
}
