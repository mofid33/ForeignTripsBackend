using Foreign_Trips.Entities;
using Foreign_Trips.Model;

namespace Foreign_Trips.Repositories
{
    public interface IRequestRepository
    {
        Task<IEnumerable<RequestTbl?>> GetRequest();
        Task<RequestTbl?> GetRequestAsync(int RequestId);
        Task<bool> RequestExistsAsync(int RequestId);
        Task<RequestTbl?> InsertRequestAsync(RequestTbl request);
        Task<RequestDto?> UpdateRequestAsync(RequestDto request);
        Task<RequestDto?> RejectRequest(RequestDto request);
        Task RemoveRequestAsync(int requestId);
        Task<IEnumerable<RequestStatusTbl>> GetRequestStatusAsync();
        Task<IEnumerable<RuleTbl?>> GetRule();
        //Task<RuleTbl?> GetRuleAsync(int RuleId);
        Task<bool> SaveChangesAsync();

    }
}
