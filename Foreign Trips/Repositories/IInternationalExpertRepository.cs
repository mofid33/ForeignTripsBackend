using Foreign_Trips.Entities;
using Foreign_Trips.Model;

namespace Foreign_Trips.Repositories
{
    public interface IInternationalExpertRepository
    {
        Task<bool> InternationalExpertExistsAsync(int internationalexpertId);
        Task<IEnumerable<InternationalExpertTbl?>> GetInternationalExpert();
        Task<InternationalExpertTbl?> GetInternationalExpertAsync(int internationalExpertId);
        Task<InternationalExpertTbl?> InsertInternationalExpert(InternationalExpertTbl internationalexpert);
        Task<InternationalExpertTbl?> UpdateInternationalExpert(InternationalExpertTbl internationalexpert);
        Task RemoveInternationalExpert(int internationalexpertId);

    }
}
