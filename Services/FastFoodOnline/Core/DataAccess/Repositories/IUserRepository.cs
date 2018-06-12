using System.Collections.Generic;
using System.Threading.Tasks;
using FastFoodOnline.Core.Base.Repositories;
using FastFoodOnline.Models;

namespace FastFoodOnline.Core.DataAccess.Repositories
{
    /// <summary>
    /// User related data - Interface
    /// </summary>
    public interface IUserRepository : IBaseRepository
    {
        /// <summary>
        /// Get All Users - Async
        /// </summary>
        /// <returns>IEnumerable of User</returns>
        Task<IEnumerable<User>> GetAllUsersAsync();

        /// <summary>
        /// Get User Id by Username - Async
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>User Id</returns>
        Task<int> GetUserIdByUsernameAsync(string username);

        /// <summary>
        /// Get Just User By Id - Async
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>User</returns>
        Task<User> GetUserByIdAsync(int id);

        /// <summary>
        /// Get User and Details By Id - Async
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>User</returns>
        Task<User> GetUserDetailsByIdAsync(int id);

        /// <summary>
        /// Get Just User By Username - Async
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>User</returns>
        Task<User> GetUserByUsernameAsync(string username);

        /// <summary>
        /// Get User and Details By Username - Async
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>User</returns>
        Task<User> GetUserDetailsByUsernameAsync(string username);


    }
}
