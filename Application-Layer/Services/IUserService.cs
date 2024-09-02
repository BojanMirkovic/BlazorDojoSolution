

using Domain_Layer.Models.User;

namespace Application_Layer.Services
{
    public interface IUserService
    {
        Task<UserModel> RegisterUserAsync(UserModel newUser);
        Task<IEnumerable<UserModel>> GetAllUsersAsync();
        Task<UserModel> GetUserByEmailAsync(string email);
        Task<UserModel> GetUserByIdAsync(string userId);
        Task<UserModel> UpdateUserAsync(UserModel userToUpdate);
        Task<bool> DeleteUserByIdAsync(string userId);
        Task<string> GenerateJwtTokenAsync(UserModel user);
    }
}
