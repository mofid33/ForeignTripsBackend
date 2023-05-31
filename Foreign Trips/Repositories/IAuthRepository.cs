using Foreign_Trips.Entities;

namespace Foreign_Trips.Repositories
{
    public interface IAuthRepository
    {
        LoginDto Login(LoginDto model);
        int GetIDFromToken(string token);

        Task<LoginDto> ValidateUserCredentials(string username, string password);

    }
}
