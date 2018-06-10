using System.Collections.Generic;
using System.Threading.Tasks;
using FastFoodOnline.Core.Base.Services;
using FastFoodOnline.Models;

namespace FastFoodOnline.Core.Services
{
    public interface IUserService : IBaseService
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
        /// <param name="requestedUserUsername"></param>
        /// <returns>User</returns>
        Task<User> GetUserByUsernameAsync(string username, string requestedUserUsername);
    }
}
