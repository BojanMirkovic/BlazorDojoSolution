

using System.Net.Http.Json;
using System.Runtime.InteropServices;
using Domain_Layer.Models.User;

namespace Application_Layer.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        public UserService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public async Task<bool> DeleteUserByIdAsync(string userId)
        {
            var data = await _httpClient.DeleteAsync($"api/User/deleteUser/{userId}");
            var response = await data.Content.ReadFromJsonAsync<bool>();
            return response;
        }

        public Task<string> GenerateJwtTokenAsync(UserModel user)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<UserModel>>("api/User/GetAllUsers");
        }

        public async Task<UserModel> GetUserByEmailAsync(string email)
        {
            return await _httpClient.GetFromJsonAsync<UserModel>($"api/User/by-email/{email}");
        }

        public async Task<UserModel> GetUserByIdAsync(string userId)
        {
            return await _httpClient.GetFromJsonAsync<UserModel>($"api/User/{userId}");
        }

        public async Task<UserModel> RegisterUserAsync(UserModel newUser)
        {
            var data = await _httpClient.PostAsJsonAsync("api/User/register", newUser);
            var response = await data.Content.ReadFromJsonAsync<UserModel>();
            return response;
        }

        public async Task<UserModel> UpdateUserAsync(UserModel userToUpdate)
        {
            var data = await _httpClient.PutAsJsonAsync("api/User/updateUser", userToUpdate);
            var response = await data.Content.ReadFromJsonAsync<UserModel>();
            return response;
        }
    }
}
