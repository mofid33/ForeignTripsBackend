using Foreign_Trips.Entities;
using Foreign_Trips.Model;

namespace Foreign_Trips.Repositories
{
    public interface IAdminRepository
    {
        Task<bool> AdminExistsAsync(int adminId);
        Task<IEnumerable<AdminTbl?>> GetAdmins();
        Task<AdminTbl?> InsertAdmin(AdminTbl admin);
        Task<AdminTbl?> UpdateAdmin(AdminTbl admin);
        Task<IEnumerable<LoginRegDto?>> GetUser();
        Task<LoginTbl?> GetUserLog(LoginTbl id);
        Task RemoveAdmin(int adminId);

    }

}
