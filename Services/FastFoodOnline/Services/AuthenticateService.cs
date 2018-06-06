using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastFoodOnline.Base.Services;
using FastFoodOnline.Core.DataAccess;
using FastFoodOnline.Core.Services;
using FastFoodOnline.Models;

namespace FastFoodOnline.Services
{
    public class AuthenticateService : BaseService, IAuthenticateService
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork Dependancy</param>
        public AuthenticateService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }

        /// <summary>
        /// Authenticate Username - Async
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>User</returns>
        public async Task<User> AuthenticateUsernameAsync(string username)
        {
            return await UnitOfWork.UserRepository.GetUserByUsernameAsync(username);
        }

        /// <summary>
        /// Authenticate Username and Password - Async
        /// For Login
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Plain text password</param>
        /// <returns>User</returns>
        public async Task<User> AuthenticateUsernamePasswordAsync(string username, string password)
        {
            return await UnitOfWork.UserRepository.GetUserByUsernameAndPasswordAsync(username, StringEncryptService.GetStringSha256Hash(password));
        }
    }
}
