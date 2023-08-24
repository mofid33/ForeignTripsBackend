using Foreign_Trips.Model;

namespace Foreign_Trips.Repositories
{
    public interface IOverseerRepository
    {
        Task<bool> OverseerExistsAsync(int overseerId);
        Task<IEnumerable<OverseerTbl?>> GetOverseer();
        Task<OverseerTbl?> GetOverseer(int overseerId);
        Task<OverseerTbl?> InsertOverseer(OverseerTbl overseer);
        Task<OverseerTbl?> UpdateOverseerAsync(OverseerTbl overseer);
    }
}
