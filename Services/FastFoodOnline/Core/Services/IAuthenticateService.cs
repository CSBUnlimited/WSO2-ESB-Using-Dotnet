using System.Threading.Tasks;
using FastFoodOnline.Core.Base.Services;
using FastFoodOnline.Models;

namespace FastFoodOnline.Core.Services
{
    public interface IAuthenticateService : IBaseService
    {
        /// <summary>
        /// Authenticate Username - Async
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>User</returns>
        Task<User> AuthenticateUsernameAsync(string username);

        /// <summary>
        /// Authenticate Username and Password - Async
        /// For Login
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Plain text password</param>
        /// <returns>User</returns>
        Task<User> AuthenticateUsernamePasswordAsync(string username, string password);
    }
}
