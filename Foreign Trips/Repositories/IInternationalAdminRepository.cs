using Foreign_Trips.Entities;
using Foreign_Trips.Model;

namespace Foreign_Trips.Repositories
{
    public interface IInternationalAdminRepository
    {
        Task<bool> AdminExistsAsync(int adminId);
        Task<IEnumerable<InternationalAdminTbl?>> GetAdmins();
        Task<InternationalAdminDto> InsertAdmin(InternationalAdminDto admin);
        Task<InternationalAdminTbl?> UpdateAdmin(InternationalAdminTbl admin);
        Task RemoveAdmin(int adminId);
        Task<string> GetExcelAgent();
        //Task<string> GetExcelLogin(LoginTbl id);
        //Task<string> GetExcelRequest();
    

    }

}
