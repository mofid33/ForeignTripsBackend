using Foreign_Trips.Entities;
using Foreign_Trips.Model;

namespace Foreign_Trips.Repositories
{
    public interface IRequestRepository
    {
        Task<IEnumerable<RequestTbl?>> GetRequest();
        Task<RequestTbl?> GetRequestAsync(int RequestId);
        Task<bool> RequestExistsAsync(int RequestId);
        Task<RequestTbl?> InsertRequest1Async(RequestTbl request);
        Task<RequestTbl?> InsertRequest2Async(RequestTbl request);
        Task<RequestTbl?> InsertRequest3Async(RequestTbl request);
        Task<RequestTbl?> InsertRequest4Async(RequestTbl request);
        Task<RequestDto?> UpdateRequestAsync(RequestDto request);
        Task<RequestTbl?> GetNewRequest(int requestId);
        Task<RequestTbl?> AcceptRequest(RequestTbl request);
        Task<RequestTbl?> RejectRequest(RequestTbl request);
        Task RemoveRequestAsync(int requestId);
        Task<IEnumerable<RequestStatusTbl>> GetRequestStatusAsync();
        Task<IEnumerable<RuleTbl?>> GetRule();

        //Task<RuleTbl?> GetRuleAsync(int RuleId);
        Task<IEnumerable<RequestStatusTbl>> RequestStatusAsync();
        Task<IEnumerable<TravelGoalsTypeTbl>> TravelGoalsTypeAsync();
        Task<IEnumerable<JobGoalsTypeTbl>> JobGoalsTypeAsync();
        Task<IEnumerable<DeviceNameItypeTbl>> DeviceNametypeAsync();
        Task<IEnumerable<PassportTbl>> PassportTypeAsync();
        Task<IEnumerable<RightOfMissionTbl>> RightOfMissionAsync();
        Task<IEnumerable<RightOfCommutingTypeTbl>> RightOfCommutingTypeAsync();
        Task<IEnumerable<RightToEducationTbl>> RightToEducationAsync();
        Task<bool> SaveChangesAsync();

    }
}
