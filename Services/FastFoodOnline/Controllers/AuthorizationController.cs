using System;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using FastFoodOnline.Core.Services;
using FastFoodOnline.Models;
using FastFoodOnline.Resources.DTOs.Authentication;
using FastFoodOnline.Resources.DTOs.Login;
using FastFoodOnline.Resources.DTOs.User;
using FastFoodOnline.Resources.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodOnline.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthorizationController : ControllerBase
    {
        #region Private Properties

        private readonly IAuthenticateService _authenticateService;
        private readonly IMapper _mapper;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="authenticateService">AuthenticateService</param>
        /// <param name="mapper">Automapper</param>
        public AuthorizationController(IAuthenticateService authenticateService, IMapper mapper)
        {
            _authenticateService = authenticateService;
            _mapper = mapper;
        }

        /// <summary>
        /// User Login - Async
        /// </summary>
        /// <param name="loginRequest">FromBody - LoginRequest</param>
        /// <returns>UserResponse</returns>
        [HttpPost(Name = "UserLoginAsync")]
        public async Task<IActionResult> UserLoginAsync([FromBody]LoginRequest loginRequest)
        {
            AuthenticationResponse authenticationResponse = new AuthenticationResponse();

            try
            {
                if (ModelState.IsValid)
                {
                    User user = await _authenticateService.LoginUserByUsernameAndPassword(loginRequest.LoginViewModel.Username, loginRequest.LoginViewModel.Password);

                    if (user == null || user.Id <= 0)
                    {
                        authenticationResponse.Status = (int)HttpStatusCode.Unauthorized;
                        throw new Exception("Invalid username or password");
                    }
                    
                    authenticationResponse.AuthenticationToken = _authenticateService.GenarateTokenForUser(user);

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
                authenticationResponse.Status = authenticationResponse.Status > 0 ? authenticationResponse.Status : (int)HttpStatusCode.Conflict;
            }

            return StatusCode(authenticationResponse.Status, authenticationResponse);
        }

        /// <summary>
        /// User Registeration - Async
        /// </summary>
        /// <param name="userRequest">FromBody - UserRequest</param>
        /// <returns>UserResponse</returns>
        [HttpPost(Name = "UserRegisterationAsync")]
        public async Task<IActionResult> UserRegisterationAsync([FromBody]UserRequest userRequest)
        {
            UserResponse userResponse = new UserResponse();

            try
            {
                if (ModelState.IsValid)
                {
                    userRequest.UserViewModel.LoyaltyPoints = 0;
                    userRequest.UserViewModel.RegisteredDate = DateTime.Now;

                    bool isRegistered = await _authenticateService.RegisterUserAsync(_mapper.Map<UserViewModel, User>(userRequest.UserViewModel), userRequest.Password);

                    if (!isRegistered)
                    {
                        userResponse.Status = (int)HttpStatusCode.BadRequest;
                        throw new Exception("Username already taken or somthing went wrong");
                    }

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