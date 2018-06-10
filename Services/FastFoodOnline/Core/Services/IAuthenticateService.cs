using System.Threading.Tasks;
using FastFoodOnline.Core.Base.Services;
using FastFoodOnline.Models;

namespace FastFoodOnline.Core.Services
{
    public interface IAuthenticateService : IBaseService
    {
        /// <summary>
        /// Genarate Token For User
        /// </summary>
        /// <param name="user">User Details</param>
        /// <returns>Token String</returns>
        string GenarateTokenForUser(User user);

        /// <summary>
        /// Check weather given username has reserved by another user - Async
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>If username is avalable then return True</returns>
        Task<bool> AuthenticateUsernameAsync(string username);

        /// <summary>
        /// Authenticate Username and Password - Async
        /// For Login
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Plain text password</param>
        /// <returns>User</returns>
        Task<User> LoginUserByUsernameAndPassword(string username, string password);

        /// <summary>
        /// Re
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<bool> RegisterUserAsync(User user, string password);
    }
}
