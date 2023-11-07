using API.Database;
using API.DTOs;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class UserService : IUserService
    {
        private readonly CrmContext _context;

        public async Task CreateUserAsync(UserDTO user)
        {
            await _context.AddAsync(new User
            {
                UserName = user.UserName,
                Email = user.Email,  
            });

            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(UserDTO user)
        {
            var storedUser = _context.Set<User>().Where(x => x.Id == user.Id && x.isDeleted).Single();
            if (user != null)
            {
                storedUser.FirstName = user.FirstName;
                storedUser.LastName = user.LastName;
                storedUser.Email = user.Email;
                storedUser.LinkedInProfile = user.LinkedInProfile;
      
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteUserAsync(int id)
        {
            var user = _context.Set<User>().Where(x => x.Id == id && x.isDeleted).SingleOrDefault();
            if (user != null)
            {
                user.isDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IList<UserDTO>> GeAllUsersAsync()
        {
            var query = _context.Set<User>()
                .Select(x => new UserDTO()
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    LinkedInProfile = x.LinkedInProfile,
                    isDeleted = x.isDeleted
                }).ToListAsync();

            return await query;
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = await _context.Set<User>().SingleAsync(x => x.Id == id);
            var mappedUser = new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                LinkedInProfile = user.LinkedInProfile,
            };

            return mappedUser;
        }
    }
}
