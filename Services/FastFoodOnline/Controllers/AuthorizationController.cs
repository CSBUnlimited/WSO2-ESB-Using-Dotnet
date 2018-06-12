using System;
using System.Net;
using System.Threading.Tasks;
using FastFoodOnline.Core.Services;
using FastFoodOnline.Resources.DTOs.Authentication;
using FastFoodOnline.Resources.DTOs.Login;
using FastFoodOnline.Resources.DTOs.User;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodOnline.Controllers
{
    /// <summary>
    /// Provide Authorization realated End Points
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthorizationController : ControllerBase
    {
        #region Private Properties

        private readonly IAuthenticationService _authenticationService;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="authenticationService">AuthenticateService</param>
        public AuthorizationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// Check Username is Taken by Another user or not - Async
        /// </summary>
        /// <param name="username">Username that request</param>
        /// <returns>UserResponse</returns>
        /// <response code="200">Username allowed to use</response>
        /// <response code="302">Username already used</response>
        /// <response code="400">Bad request by client</response>
        [HttpGet("{username}", Name = "CheckUsernameAvailableAsync")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Found)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CheckUsernameAvailableAsync(string username)
        {
            AuthenticationResponse userResponse = new AuthenticationResponse();

            try
            {
                if (username.Length > 6)
                {
                    bool isUserExists = await _authenticationService.AuthenticateUsernameAsync(username);

                    if (isUserExists)
                    {
                        userResponse.Status = (int)HttpStatusCode.Found;
                        userResponse.Message = "Username already taken";
                    }
                    else
                    {
                        userResponse.IsSuccess = true;
                        userResponse.Status = (int)HttpStatusCode.OK;
                        userResponse.Message = "Username available";
                    }
                }
                else
                {
                    userResponse.Status = (int)HttpStatusCode.BadRequest;
                    userResponse.Message = "Username must have at least 6 characters";
                }
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
        /// User Login - Async
        /// </summary>
        /// <param name="loginRequest">FromBody - LoginRequest</param>
        /// <returns>UserResponse</returns>
        /// <response code="200">Valid credtials. Returns AuthenticationResponse</response>
        /// <response code="400">Bad request by client</response>
        /// <response code="401">Invalid credentials</response>
        [HttpPost(Name = "UserLoginAsync")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> UserLoginAsync([FromBody]LoginRequest loginRequest)
        {
            AuthenticationResponse authenticationResponse = new AuthenticationResponse();

            try
            {
                if (ModelState.IsValid)
                {
                    authenticationResponse.TokenViewModel = await _authenticationService.LoginUserByUsernameAndPassword(loginRequest.LoginViewModel.Username, loginRequest.LoginViewModel.Password);

                    if (authenticationResponse.TokenViewModel == null)
                    {
                        authenticationResponse.Status = (int)HttpStatusCode.Unauthorized;
                        throw new Exception("Invalid username or password");
                    }

                    authenticationResponse.IsSuccess = true;
                    authenticationResponse.Status = (int)HttpStatusCode.OK;
                }
                else
                {
                    authenticationResponse.Message = $"Model Error Count - { ModelState.ErrorCount }";
                    authenticationResponse.MessageDetails = ModelState.ToString();
                    authenticationResponse.Status = (int)HttpStatusCode.BadRequest;
                }
            }
            catch (Exception ex)
            {
                authenticationResponse.Message = ex.Message;
                authenticationResponse.MessageDetails = ex.ToString();
                authenticationResponse.Status = authenticationResponse.Status > 0 ? authenticationResponse.Status : (int)HttpStatusCode.BadRequest;
            }

            return StatusCode(authenticationResponse.Status, authenticationResponse);
        }

        /// <summary>
        /// User Registeration - Async
        /// </summary>
        /// <param name="userRequest">FromBody - UserRequest</param>
        /// <returns>UserResponse</returns>
        /// <response code="200">User registered</response>
        /// <response code="400">Bad request by client</response>
        /// <response code="500">Something went wrong from Server side</response>
        [HttpPost(Name = "UserRegisterationAsync")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UserRegisterationAsync([FromBody]UserRequest userRequest)
        {
            AuthenticationResponse userResponse = new AuthenticationResponse();

            try
            {
                if (ModelState.IsValid)
                {
                    userRequest.UserViewModel.LoyaltyPoints = 0;
                    userRequest.UserViewModel.RegisteredDate = DateTime.Now;

                    if (await _authenticationService.AuthenticateUsernameAsync(userRequest.UserViewModel.Username))
                    {
                        userResponse.Status = (int)HttpStatusCode.BadRequest;
                        throw new Exception("Username already taken.");
                    }

                    bool isRegistered = await _authenticationService.RegisterUserAsync(userRequest.UserViewModel, userRequest.Password);

                    if (isRegistered)
                    {
                        userResponse.IsSuccess = true;
                        userResponse.Status = (int)HttpStatusCode.OK;
                    }
                    else
                    {
                        userResponse.Status = (int)HttpStatusCode.InternalServerError;
                        userResponse.Message = "Somthing went wrong";
                    }
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
                userResponse.Status = userResponse.Status > 0 ? userResponse.Status : (int)HttpStatusCode.BadRequest;
            }

            return StatusCode(userResponse.Status, userResponse);
        }
    }
}