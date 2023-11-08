using API.DTOs;
using API.Models;

namespace API.Services
{
    public interface IUserService
    {
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<IList<UserDTO>> GeAllUsersAsync();
        Task<bool> CreateUserAsync(CreateUserDTO user);
        Task UpdateUserAsync(UserDTO user);
        Task DeleteUserAsync(int id);
        Task<bool> IsUserNameAvaliableAsync(string userName);
    }
}
