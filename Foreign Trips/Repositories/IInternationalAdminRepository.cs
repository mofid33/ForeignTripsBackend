using Foreign_Trips.Entities;
using Foreign_Trips.Model;

namespace Foreign_Trips.Repositories
{
    public interface IInternationalAdminRepository
    {
        Task<bool> AdminExistsAsync(int adminId);
        Task<IEnumerable<InternationalAdminTbl?>> GetAdmins();
        Task<InternationalAdminTbl?> InsertAdmin(InternationalAdminTbl admin);
        Task<InternationalAdminTbl?> UpdateAdmin(InternationalAdminTbl admin);
        Task RemoveAdmin(int adminId);

    }

}
