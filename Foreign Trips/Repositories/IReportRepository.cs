using Foreign_Trips.Entities;
using Foreign_Trips.Model;

namespace Foreign_Trips.Repositories
{
    public interface IReportRepository
    {
        Task<bool> ReportExistsAsync(int reportId);
        Task<IEnumerable<ReportTbl?>> GetReport();
        Task<ReportTbl?> GetReportByRequest(int requestId);
        Task<ReportTbl?> GetReportAsync(int reportId);
        Task<ReportTbl?> InsertReport(ReportTbl report);
        Task<ReportTbl?> UpdateReport(ReportTbl report);
        Task<string> RemoveReport(int reportId);


        //Task PostFileAsync(FileUploadModel fileData);
        //Task PostMultiFileAsync(List<FileUploadModel> fileData);
        //Task DownloadFileById(int fileName);
    }
}
