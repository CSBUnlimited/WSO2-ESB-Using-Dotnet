using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using FastFoodOnline.Core.Services;
using FastFoodOnline.Models;
using FastFoodOnline.Resources.DTOs.User;
using FastFoodOnline.Resources.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodOnline.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        #region Private Properties

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpContextAccessor">HttpContextAccessor to Get Token details</param>
        /// <param name="userService">UserService</param>
        /// <param name="mapper">Automapper</param>
        public UserController(IHttpContextAccessor httpContextAccessor, IUserService userService, IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All Users - Async
        /// </summary>
        /// <returns>UserResponse</returns>
        [HttpGet(Name = "GetAllUsersAsync")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            UserResponse userResponse = new UserResponse();

            try
            {
                userResponse.UserViewModels = _mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(await _userService.GetAllUsersAsync());
                userResponse.Status = (int)HttpStatusCode.OK;
                userResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                userResponse.Message = ex.Message;
                userResponse.MessageDetails = ex.ToString();
                userResponse.Status = userResponse.Status > 0 ? userResponse.Status : (int)HttpStatusCode.Conflict;
            }

            return StatusCode(userResponse.Status, userResponse);
        }

        /// <summary>
        /// Get User By Username - Async
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>UserResponse</returns>
        [HttpGet("{username}", Name = "GetUserByUsernameAsync")]
        public async Task<IActionResult> GetUserByUsernameAsync(string username)
        {
            UserResponse userResponse = new UserResponse();

            try
            {
                string usernameByToken = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

                if (!usernameByToken.Equals(username, StringComparison.InvariantCultureIgnoreCase))
                {
                    //need change
                }

                User user = await _userService.GetUserByUsernameAsync(username);

                if (user == null || user.Id <= 0)
                {
                    userResponse.Status = (int)HttpStatusCode.NoContent;
                }
                else
                {
                    userResponse.UserViewModels = new List<UserViewModel>()
                    {
                        _mapper.Map<User, UserViewModel>(user)
                    };

                    userResponse.Status = (int)HttpStatusCode.OK;
                }

                userResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                userResponse.Message = ex.Message;
                userResponse.MessageDetails = ex.ToString();
                userResponse.Status = userResponse.Status > 0 ? userResponse.Status : (int)HttpStatusCode.Conflict;
            }

            return StatusCode(userResponse.Status, userResponse);
        }
    }
}