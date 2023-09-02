using Foreign_Trips.Entities;
using Foreign_Trips.Model;

namespace Foreign_Trips.Repositories
{
    public interface IRequestRepository
    {
        Task<IEnumerable<RequestTbl?>> GetRequest();
        Task<RequestTbl?> GetRequestAsync(int RequestId);
        Task<IEnumerable<RequestEmployeeTbl?>> GetRequestEmployee();
        Task<bool> RequestExistsAsync(int RequestId);
        Task<RequestTbl?> InsertRequestAsync(RequestTbl request);
        Task<RequestEmployeeTbl?> InsertRequestEmployeeAsync(RequestEmployeeTbl requestemployee);
        Task<RequestTbl?> UpdateRequest3Async(RequestTbl request);
        Task<RequestTbl?> UpdateRequest4Async(RequestTbl request);
        Task<RequestTbl?> GetNewRequest(int requestId);
        Task<RequestTbl?> AcceptRequest(RequestTbl request);
        Task<RequestTbl?> RejectRequest(RequestTbl request);
        Task RemoveRequestAsync(int requestId);
        Task<IEnumerable<RequestStatusTbl>> RequestStatusAsync();
        Task<IEnumerable<TravelGoalsTypeTbl>> TravelGoalsTypeAsync();
        Task<IEnumerable<JobGoalsTypeTbl>> JobGoalsTypeAsync();
        Task<IEnumerable<DeviceNameItypeTbl>> DeviceNametypeAsync();
        Task<IEnumerable<PassportTbl>> PassportTypeAsync();
        Task<IEnumerable<RightOfMissionTbl>> RightOfMissionAsync();
        Task<IEnumerable<RightOfCommutingTypeTbl>> RightOfCommutingTypeAsync();
        Task<IEnumerable<RightToEducationTbl>> RightToEducationAsync();
        Task<IEnumerable<TollAmountTypeTbl>> TollAmountTypeAsync();
        Task<IEnumerable<TravelTypeTbl>>TravelTypeAsync();
        Task<bool> SaveChangesAsync();

    }
}
