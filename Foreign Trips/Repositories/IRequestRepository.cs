using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using System.Net;

namespace Foreign_Trips.Repositories
{
    public interface IRequestRepository
    {
        Task<RequestPageDto> GetRequest(int page, int pageSize, string search);
        Task<IEnumerable<AllListDto?>> GetAllList(int page, int pageSize, string search);
        Task<RequestPageDto> GetRequestsExpert(int page, int pageSize, string search,int ExpertId);
        Task<RequestPageDto> GetRequestsAdmin(int page, int pageSize, string search,int AdminId);
        Task<RequestPageDto> GetRequestsMainAdmin(int page, int pageSize, string search,int MainAdminId);
        Task<RequestTbl?> GetRequestAsync(int requestId);
        Task<RequestPageDto> GetRequestsAgent(int page, int pageSize, string search, int agentId);
        Task<IEnumerable<RequestEmployeeTbl?>> GetRequestEmployeeAsync(int requestId);
        Task<bool> RequestExistsAsync(int RequestId);
        Task<RequestTbl?> InsertRequestAsync(RequestTbl request);
        Task<RequestEmployeeTbl?> InsertRequestEmployeeAsync(RequestEmployeeTbl requestemployee);
        Task<RequestTbl?> UpdateRequest3Async(RequestTbl request);
        Task<RequestTbl?> UpdateRequest4Async(RequestTbl request);
        Task<RequestTbl?> UpdateRequest5Async(RequestTbl request);
        Task<RequestTbl?> GetNewRequest(int requestId);
        Task<RequestTbl?> AcceptRequestExpert(RequestTbl request);
        Task<RequestTbl?> RejectRequestExpert(RequestTbl request);
        Task<RequestTbl?> AcceptReportExpert(RequestTbl request);
        Task<RequestTbl?> RejectReportExpert(RequestTbl request);
        Task<RequestTbl?> AcceptRequestAdmin(RequestTbl request);
        Task<RequestTbl?> RejectRequestAdmin(RequestTbl request);
        Task<RequestTbl?> AcceptRequestMainAdmin(RequestTbl request);
        Task<RequestTbl?> RejectRequestMainAdmin(RequestTbl request);
        Task<string> RemoveRequestAsync(int requestId);
        Task<string> RemoveRequestEmployeeAsync(int employeeId);
        Task<IEnumerable<RequestStatusTbl>> RequestStatusAsync();
        Task<IEnumerable<TravelGoalsTypeTbl>> TravelGoalsTypeAsync();
        Task<IEnumerable<JobGoalsTypeTbl>> JobGoalsTypeAsync();
        //Task<IEnumerable<DeviceNameItypeTbl>> DeviceNametypeAsync();
        Task<IEnumerable<PassportTbl>> PassportTypeAsync();
        Task<IEnumerable<RightOfMissionTbl>> RightOfMissionAsync();
        Task<IEnumerable<RightOfCommutingTypeTbl>> RightOfCommutingTypeAsync();
        Task<IEnumerable<RightToEducationTbl>> RightToEducationAsync();
        Task<IEnumerable<TollAmountTypeTbl>> TollAmountTypeAsync();
        Task<IEnumerable<TravelTypeTbl>>TravelTypeAsync();
        //Task SignatureAsync(PhotoUploadModel signature);
        Task<bool> SaveChangesAsync();

    }
}
