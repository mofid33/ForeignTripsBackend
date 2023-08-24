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
        Task<IEnumerable<LoginRegDto?>> GetUser();
        Task<LoginTbl?> GetUserLog(LoginTbl id);
        Task RemoveAdmin(int adminId);

    }

}
