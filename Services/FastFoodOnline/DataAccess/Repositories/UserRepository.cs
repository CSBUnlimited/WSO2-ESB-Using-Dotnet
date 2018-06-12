using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastFoodOnline.Base.Repositories;
using FastFoodOnline.Core.DataAccess.Repositories;
using FastFoodOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace FastFoodOnline.DataAccess.Repositories
{
    /// <summary>
    /// User related data
    /// </summary>
    public class UserRepository : BaseRepository, IUserRepository
    {
        /// <summary>
        /// Get All Users - Async
        /// </summary>
        /// <returns>IEnumerable of User</returns>
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await DbContext.Users
                .Where(u => u.IsActive == true)
                .ToListAsync();
        }

        /// <summary>
        /// Get User Id by Username - Async
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>User Id</returns>
        public async Task<int> GetUserIdByUsernameAsync(string username)
        {
            User user = await DbContext.Users
                .Select(u => new User()
                {
                    Id = u.Id,
                    Username = u.Username,
                    IsActive = u.IsActive
                })
                .SingleOrDefaultAsync(u =>
                    u.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase) && u.IsActive == true);

            return user?.Id ?? 0;
        }

        /// <summary>
        /// Get Just User By Id - Async
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>User</returns>
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await DbContext.Users.SingleOrDefaultAsync(u => u.Id == id && u.IsActive == true);
        }

        /// <summary>
        /// Get User and Details By Id - Async
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>User</returns>
        public async Task<User> GetUserDetailsByIdAsync(int id)
        {
            return await DbContext.Users
                .Include(u => u.Payments)
                .Include(u => u.SentMessages)
                .Include(u => u.SentEmails)
                .SingleOrDefaultAsync(u => u.Id == id && u.IsActive == true);
        }

        /// <summary>
        /// Get Just User By Username - Async
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>User</returns>
        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await DbContext.Users
                .SingleOrDefaultAsync(u => u.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase) && u.IsActive == true);
        }

        /// <summary>
        /// Get User By Username - Async
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>User</returns>
        public async Task<User> GetUserDetailsByUsernameAsync(string username)
        {
            return await DbContext.Users
                .Include(u => u.Payments)
                .Include(u => u.SentMessages)
                .Include(u => u.SentEmails)
                .SingleOrDefaultAsync(u => u.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase) && u.IsActive == true);
        }
    }
}
