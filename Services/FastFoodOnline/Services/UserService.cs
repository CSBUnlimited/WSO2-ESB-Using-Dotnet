using System.Collections.Generic;
using System.Threading.Tasks;
using FastFoodOnline.Base.Services;
using FastFoodOnline.Core.DataAccess;
using FastFoodOnline.Core.Services;
using FastFoodOnline.Models;

namespace FastFoodOnline.Services
{
    public class UserService : BaseService, IUserService
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork Dependancy</param>
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }

        /// <summary>
        /// Get All Users - Async
        /// </summary>
        /// <returns>IEnumerable of User</returns>
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await UnitOfWork.UserRepository.GetAllUsersAsync();
        }

        /// <summary>
        /// Get User By Id - Async
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>User</returns>
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await UnitOfWork.UserRepository.GetUserByIdAsync(id);
        }

        /// <summary>
        /// Get User By Username - Async
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>User</returns>
        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await UnitOfWork.UserRepository.GetUserByUsernameAsync(username);
        }
    }
}
