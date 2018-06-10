using System;
using System.Linq;
using System.Threading.Tasks;
using FastFoodOnline.Base.Repositories;
using FastFoodOnline.Core.DataAccess.Repositories;
using FastFoodOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace FastFoodOnline.DataAccess.Repositories
{
    public class AuthorizationRepository : BaseRepository, IAuthorizationRepository
    {
        /// <summary>
        /// Register User - Async
        /// </summary>
        /// <param name="user">User to Register</param>
        public async Task RegisterUserAsync(User user)
        {
            await DbContext.Users.AddAsync(user);
        }

        /// <summary>
        /// Get User Credentials By Username - Async
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>User Credential Data</returns>
        public async Task<User> GetUserCredentialsByUsername(string username)
        {
            return await DbContext.Users
                .Select(u => new User
                {
                    Id = u.Id,
                    Username = u.Username,
                    PasswordHash = u.PasswordHash,
                    PasswordSalt = u.PasswordSalt,
                    IsActive = u.IsActive
                })
                .SingleOrDefaultAsync(u => u.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase) && u.IsActive == true);
        }

        /// <summary>
        /// Check user is exists or not - Async
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>If user exists then True, otherwise False</returns>
        public async Task<bool> IsUserExistsAsync(string username)
        {
            return await DbContext.Users.AnyAsync(u => u.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase) && u.IsActive == true);
        }
    }
}
