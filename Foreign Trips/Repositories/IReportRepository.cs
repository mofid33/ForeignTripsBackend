using Foreign_Trips.Entities;
using Foreign_Trips.Model;

namespace Foreign_Trips.Repositories
{
    public interface IReportRepository
    {
        Task<bool> ReportExistsAsync(int reportId);
        Task<IEnumerable<Report?>> GetReport();
        Task<Report?> GetReportAsync(int reportId);
        Task<Report?> InsertReport(Report report);
        Task<Report?> UpdateReport(Report report);
        Task RemoveReport(int reportId);


        //Task PostFileAsync(FileUploadModel fileData);
        //Task PostMultiFileAsync(List<FileUploadModel> fileData);
        //Task DownloadFileById(int fileName);
    }
}
