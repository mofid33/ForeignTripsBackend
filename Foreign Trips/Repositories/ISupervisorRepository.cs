using Foreign_Trips.Entities;
using Foreign_Trips.Model;

namespace Foreign_Trips.Repositories
{
    public interface ISupervisorRepository
    {
        Task<bool> SupervisorExistsAsync(int supervisorId);
        Task<SupervisorPageDto> GetSupervisor(int page, int pageSize, string search);
        Task<SupervisorTbl?> GetSupervisorAsync(int supervisorId);
        Task<SupervisorDto> InsertSupervisor(SupervisorDto supervisor);
        Task<SupervisorTbl?> UpdateSupervisorAsync(SupervisorTbl supervisor);
        Task RemoveSupervisorAsync(int supervisorId);
        
       
    }
}
