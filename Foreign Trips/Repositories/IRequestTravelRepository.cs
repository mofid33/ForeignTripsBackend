using Foreign_Trips.Entities;
using Foreign_Trips.Model;

namespace Foreign_Trips.Repositories
{
    public interface IRequestTravelRepository
    {
        Task<IEnumerable<RequestTravelTbl?>> GetRequestTravel();
        Task<RequestTbl?> GetRequestTravelAsync(int RequesttravelId);
        Task<bool> RequestTravelExistsAsync(long requesttravelId);
        Task<RequestTravelTbl?> InsertRequestTravelAsync(RequestTravelTbl requesttravel);
        Task<RequestTravelDto?> UpdateRequestTravelAsync(RequestTravelDto request);
        Task<RequestTravelDto?> RejectRequest(RequestTravelDto request);
        Task RemoveRequestTravelAsync(int requesttravelId);
        Task<bool> SaveChangesAsync();
    }
}
