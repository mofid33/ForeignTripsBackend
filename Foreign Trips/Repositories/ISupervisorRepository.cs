using Foreign_Trips.Model;

namespace Foreign_Trips.Repositories
{
    public interface ISupervisorRepository
    {
        Task<bool> SupervisorExistsAsync(int supervisorId);
        Task<IEnumerable<SupervisorTbl?>> GetSupervisor();
        Task<SupervisorTbl?> GetSupervisor(int supervisorId);
        Task<SupervisorTbl?> InsertSupervisor(SupervisorTbl supervisor);
        Task<SupervisorTbl?> UpdateSupervisorAsync(SupervisorTbl supervisor);
    }
}
