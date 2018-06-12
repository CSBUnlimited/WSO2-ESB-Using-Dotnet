using System.Threading.Tasks;
using FastFoodOnline.Core.Base.Services;
using FastFoodOnline.Resources.ViewModels;

namespace FastFoodOnline.Core.Services
{
    /// <summary>
    /// Authentication related Services - Interface
    /// </summary>
    public interface IAuthenticationService : IBaseService
    {
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
        /// <returns>TokenViewModel</returns>
        Task<TokenViewModel> LoginUserByUsernameAndPassword(string username, string password);

        /// <summary>
        /// Register User - Async
        /// </summary>
        /// <param name="userViewModel">UserViewModel</param>
        /// <param name="password">Password</param>
        /// <returns>Is user registered or not</returns>
        Task<bool> RegisterUserAsync(UserViewModel userViewModel, string password);
    }
}
