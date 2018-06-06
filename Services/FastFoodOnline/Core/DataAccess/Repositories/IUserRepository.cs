using System.Collections.Generic;
using System.Threading.Tasks;
using FastFoodOnline.Core.Base.Repositories;
using FastFoodOnline.Models;

namespace FastFoodOnline.Core.DataAccess.Repositories
{
    public interface IUserRepository : IBaseRepository
    {
        /// <summary>
        /// Get All Users - Async
        /// </summary>
        /// <returns>IEnumerable of User</returns>
        Task<IEnumerable<User>> GetAllUsersAsync();

        /// <summary>
        /// Get User By Id - Async
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>User</returns>
        Task<User> GetUserByIdAsync(int id);

        /// <summary>
        /// Get User By Username - Async
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>User</returns>
        Task<User> GetUserByUsernameAsync(string username);

        /// <summary>
        /// Get User B yUsername And Password - Async
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Encrypted Password</param>
        /// <returns>User</returns>
        Task<User> GetUserByUsernameAndPasswordAsync(string username, string password);
    }
}
