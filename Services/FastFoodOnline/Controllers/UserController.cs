using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using FastFoodOnline.Core.Services;
using FastFoodOnline.Models;
using FastFoodOnline.Resources.DTOs.Login;
using FastFoodOnline.Resources.DTOs.User;
using FastFoodOnline.Resources.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodOnline.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        #region Private Properties

        private readonly IUserService _userService;
        private readonly IAuthenticateService _authenticateService;
        private readonly IMapper _mapper;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userService">UserService</param>
        /// <param name="authenticateService">AuthenticateService</param>
        /// <param name="mapper">Automapper</param>
        public UserController(IUserService userService, IAuthenticateService authenticateService, IMapper mapper)
        {
            _userService = userService;
            _authenticateService = authenticateService;
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

        /// <summary>
        /// Authenticate User Login - Async
        /// </summary>
        /// <param name="loginRequest">FromBody - LoginRequest</param>
        /// <returns>UserResponse</returns>
        [HttpPost(Name = "AuthenticateUserLoginAsync")]
        public async Task<IActionResult> AuthenticateUserLoginAsync([FromBody]LoginRequest loginRequest)
        {
            UserResponse userResponse = new UserResponse();

            try
            {
                if (ModelState.IsValid)
                {
                    // Can do better than this but for this assignment this is enough
                    User user = await _authenticateService.AuthenticateUsernamePasswordAsync(loginRequest.Username, loginRequest.Password);

                    if (user == null || user.Id <= 0)
                    {
                        userResponse.Status = (int)HttpStatusCode.Unauthorized;
                        throw new Exception("Invalid username or password");
                    }

                    userResponse.UserViewModels = new List<UserViewModel>(1)
                    {
                        _mapper.Map<User, UserViewModel>(user)
                    };

                    userResponse.IsSuccess = true;
                    userResponse.Status = (int)HttpStatusCode.OK;
                }
                else
                {
                    userResponse.Message = $"Model Error Count - { ModelState.ErrorCount }";
                    userResponse.MessageDetails = ModelState.ToString();
                    userResponse.Status = (int)HttpStatusCode.BadRequest;
                }
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