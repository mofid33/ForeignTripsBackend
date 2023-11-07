using Foreign_Trips.Entities;
using Foreign_Trips.Model;

namespace Foreign_Trips.Repositories
{
    public interface IInternationalExpertRepository
    {
        Task<bool> InternationalExpertExistsAsync(int internationalexpertId);
        Task<InternationalExpertPageDto> GetInternationalExpert(int page, int pageSize, string search);
        Task<InternationalExpertTbl?> GetInternationalExpertAsync(int internationalExpertId);
        Task<InternationalExpertDto> InsertInternationalExpert(InternationalExpertDto internationalexpert);
        Task<InternationalExpertTbl?> UpdateInternationalExpert(InternationalExpertTbl internationalexpert);
        Task<string> RemoveInternationalExpert(int internationalexpertId);
        Task PostFileAsync(FileUploadModel fileData);
        Task PostMultiFileAsync(List<FileUploadModel> fileData);
        Task DownloadFileById(int fileName);


    }
}
