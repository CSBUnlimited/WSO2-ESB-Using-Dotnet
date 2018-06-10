using System.Threading.Tasks;
using FastFoodOnline.Core.Base.Repositories;
using FastFoodOnline.Models;

namespace FastFoodOnline.Core.DataAccess.Repositories
{
    public interface IAuthorizationRepository : IBaseRepository
    {
        /// <summary>
        /// Register User - Async
        /// </summary>
        /// <param name="user">User to Register</param>
        Task RegisterUserAsync(User user);

        /// <summary>
        /// Get User Credentials By Username - Async
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>User Credential Data</returns>
        Task<User> GetUserCredentialsByUsername(string username);

        /// <summary>
        /// Check user is exists or not - Async
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>If user exists then True, otherwise False</returns>
        Task<bool> IsUserExistsAsync(string username);
    }
}
