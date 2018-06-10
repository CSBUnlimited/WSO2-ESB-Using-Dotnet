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
    public class UserRepository : BaseRepository, IUserRepository
    {
        /// <summary>
        /// Get All Users - Async
        /// </summary>
        /// <returns>IEnumerable of User</returns>
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await DbContext.Users
                .Select(u => new User
                {
                    Id = u.Id,
                    Username = u.Username,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Gender = u.Gender,
                    Email = u.Email,
                    Mobile = u.Mobile,
                    LoyaltyPoints = u.LoyaltyPoints,
                    RegisteredDate = u.RegisteredDate,
                    IsActive = u.IsActive
                })
                .Where(u => u.IsActive == true)
                .ToListAsync();
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
                .Select(u => new User
                {
                    Id = u.Id,
                    Username = u.Username,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Gender = u.Gender,
                    Email = u.Email,
                    Mobile = u.Mobile,
                    LoyaltyPoints = u.LoyaltyPoints,
                    RegisteredDate = u.RegisteredDate,
                    Payments = u.Payments,
                    SentMessages = u.SentMessages,
                    SentEmails = u.SentEmails,
                    IsActive = u.IsActive
                })
                .SingleOrDefaultAsync(u => u.Id == id && u.IsActive == true);
        }

        /// <summary>
        /// Get User By Username - Async
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>User</returns>
        public async Task<User> GetUserByUsernameAsync(string username)
        {
            User user = await DbContext.Users
                .Include(u => u.Payments)
                .Include(u => u.SentMessages)
                .Include(u => u.SentEmails)
                .Select(u => new User
                {
                    Id = u.Id,
                    Username = u.Username,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Gender = u.Gender,
                    Email = u.Email,
                    Mobile = u.Mobile,
                    LoyaltyPoints = u.LoyaltyPoints,
                    RegisteredDate = u.RegisteredDate,
                    Payments = u.Payments,
                    SentMessages = u.SentMessages,
                    SentEmails = u.SentEmails,
                    IsActive = u.IsActive
                })
                .SingleOrDefaultAsync(u => u.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase) && u.IsActive == true);

            return user;
        }
    }
}
