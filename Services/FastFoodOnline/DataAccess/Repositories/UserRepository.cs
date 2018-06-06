using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FastFoodOnline.Base.Repositories;
using FastFoodOnline.Core.DataAccess.Repositories;
using FastFoodOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace FastFoodOnline.DataAccess.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        /// <summary>
        /// Get All Users - Async
        /// </summary>
        /// <returns>IEnumerable of User</returns>
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await DbContext.Users.ToListAsync();
        }

        /// <summary>
        /// Get User By Id - Async
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>User</returns>
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await DbContext.Users
                .Include(u => u.Payments)
                .Include(u => u.SentMessages)
                .Include(u => u.SentEmails)
                .SingleOrDefaultAsync(u => u.Id == id && u.IsActive == true);
        }

        /// <summary>
        /// Get User By Username - Async
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>User</returns>
        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await DbContext.Users
                .Include(u => u.Payments)
                .Include(u => u.SentMessages)
                .Include(u => u.SentEmails)
                .SingleOrDefaultAsync(u => u.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase) && u.IsActive == true);
        }

        /// <summary>
        /// Get User B yUsername And Password - Async
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Encrypted Password</param>
        /// <returns>User</returns>
        public async Task<User> GetUserByUsernameAndPasswordAsync(string username, string password)
        {
            return await DbContext.Users
                .Include(u => u.Payments)
                .Include(u => u.SentMessages)
                .Include(u => u.SentEmails)
                .SingleOrDefaultAsync
                (
                    u => u.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase) &&
                         u.Password.Equals(password) &&
                         u.IsActive == true
                );
        }
    }
}
