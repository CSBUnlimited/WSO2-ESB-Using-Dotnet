using System.Collections.Generic;
using System.Threading.Tasks;
using FastFoodOnline.Core.Base.Services;
using FastFoodOnline.Resources.ViewModels;

namespace FastFoodOnline.Core.Services
{
    public interface IUserService : IBaseService
    {
        /// <summary>
        /// Get All UserViewModel - Async
        /// </summary>
        /// <returns>IEnumerable of UserViewModel</returns>
        Task<IEnumerable<UserViewModel>> GetAllUserViewModelsAsync();

        /// <summary>
        /// Get UserViewModel By Id - Async
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>UserViewModel</returns>
        Task<UserViewModel> GetUserViewModelByIdAsync(int id);

        /// <summary>
        /// Get UserViewModel By Username - Async
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>UserViewModel</returns>
        Task<UserViewModel> GetUserViewModelByUsernameAsync(string username);
    }
}
