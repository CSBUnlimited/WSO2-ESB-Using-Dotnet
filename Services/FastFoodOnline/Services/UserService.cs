using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using FastFoodOnline.Base.Services;
using FastFoodOnline.Core.DataAccess;
using FastFoodOnline.Core.Services;
using FastFoodOnline.Models;
using FastFoodOnline.Resources.ViewModels;

namespace FastFoodOnline.Services
{
    public class UserService : BaseService, IUserService
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork Dependancy</param>
        /// <param name="mapper">Auto Mapper Injection</param>
        public UserService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        { }

        /// <summary>
        /// Get All UserViewModel - Async
        /// </summary>
        /// <returns>IEnumerable of UserViewModel</returns>
        public async Task<IEnumerable<UserViewModel>> GetAllUserViewModelsAsync()
        {
            return Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(await UnitOfWork.UserRepository.GetAllUsersAsync());
        }

        /// <summary>
        /// Get UserViewModel By Id - Async
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>UserViewModel</returns>
        public async Task<UserViewModel> GetUserViewModelByIdAsync(int id)
        {
            return Mapper.Map<User, UserViewModel>(await UnitOfWork.UserRepository.GetUserDetailsByIdAsync(id));
        }

        /// <summary>
        /// Get UserViewModel By Username - Async
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>UserViewModel</returns>
        public async Task<UserViewModel> GetUserViewModelByUsernameAsync(string username)
        {
            string requestedUserUsername = HttpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (username.Equals(requestedUserUsername, StringComparison.InvariantCultureIgnoreCase))
            {
                return Mapper.Map<User, UserViewModel>(await UnitOfWork.UserRepository.GetUserDetailsByUsernameAsync(username));
            }
            else
            {
                return Mapper.Map<User, UserViewModel>(await UnitOfWork.UserRepository.GetUserByUsernameAsync(username));
            }
        }
    }
}
