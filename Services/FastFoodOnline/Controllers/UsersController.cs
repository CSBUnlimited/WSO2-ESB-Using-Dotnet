using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FastFoodOnline.Core.Services;
using FastFoodOnline.Resources.DTOs.User;
using FastFoodOnline.Resources.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodOnline.Controllers
{
    /// <summary>
    /// Provide User realated End Points
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UsersController : ControllerBase
    {
        #region Private Properties
        
        private readonly IUserService _userService;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpContextAccessor">HttpContextAccessor to Get Token details</param>
        /// <param name="userService">UserService</param>
        public UsersController(IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _userService = userService;
            _userService.HttpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Get All Users - Async
        /// </summary>
        /// <returns>UserResponse</returns>
        /// <response code="200">OK. Return UserResponse</response>
        /// <response code="400">Bad request by client</response>
        /// <response code="401">Request unauthorized</response>
        [HttpGet(Name = "GetAllUsersAsync")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            UserResponse userResponse = new UserResponse();

            try
            {
                userResponse.UserViewModels = await _userService.GetAllUserViewModelsAsync();
                userResponse.Status = (int)HttpStatusCode.OK;
                userResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                userResponse.Message = ex.Message;
                userResponse.MessageDetails = ex.ToString();
                userResponse.Status = userResponse.Status > 0 ? userResponse.Status : (int)HttpStatusCode.BadRequest;
            }

            return StatusCode(userResponse.Status, userResponse);
        }

        /// <summary>
        /// Get User By Username - Async
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>UserResponse</returns>
        /// <response code="200">OK. Return UserResponse</response>
        /// <response code="400">Bad request by client</response>
        /// <response code="401">Request unauthorized</response>
        [HttpGet("{username}", Name = "GetUserByUsernameAsync")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetUserByUsernameAsync(string username)
        {
            UserResponse userResponse = new UserResponse();

            try
            {
                userResponse.UserViewModels = new List<UserViewModel>()
                {
                    await _userService.GetUserViewModelByUsernameAsync(username)
                };

                userResponse.Status = (int)HttpStatusCode.OK;
                userResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                userResponse.Message = ex.Message;
                userResponse.MessageDetails = ex.ToString();
                userResponse.Status = userResponse.Status > 0 ? userResponse.Status : (int)HttpStatusCode.BadRequest;
            }

            return StatusCode(userResponse.Status, userResponse);
        }
    }
}