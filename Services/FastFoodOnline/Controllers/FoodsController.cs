using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FastFoodOnline.Core.Services;
using FastFoodOnline.Resources.DTOs.Food;
using FastFoodOnline.Resources.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodOnline.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class FoodController : ControllerBase
    {
        #region Private Properties
        
        private readonly IFoodService _foodService;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpContextAccessor">HttpContextAccessor to Get Token details</param>
        /// <param name="foodService">FoodService</param>
        public FoodController(IHttpContextAccessor httpContextAccessor, IFoodService foodService)
        {
            _foodService = foodService;
            _foodService.HttpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Get All Foods - Async
        /// </summary>
        /// <returns>FoodResponse</returns>
        [HttpGet(Name = "GetFoodsAsync")]
        public async Task<IActionResult> GetFoodsAsync()
        {
            FoodResponse foodResponse = new FoodResponse();

            try
            {
                foodResponse.FoodViewModels = await _foodService.GetAllFoodViewModelsAsync();
                foodResponse.IsSuccess = true;
                foodResponse.Status = (int)HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                foodResponse.Message = ex.Message;
                foodResponse.MessageDetails = ex.ToString();
                foodResponse.Status = foodResponse.Status > 0 ? foodResponse.Status : (int)HttpStatusCode.BadRequest;
            }

            return StatusCode(foodResponse.Status, foodResponse);
        }

        /// <summary>
        /// Get Food By Id - Async
        /// </summary>
        /// <param name="id">Food Id</param>
        /// <returns>FoodResponse</returns>
        [HttpGet("{id}", Name = "GetFoodByIdAsync")]
        public async Task<IActionResult> GetFoodByIdAsync(int id)
        {
            FoodResponse foodResponse = new FoodResponse();

            try
            {
                foodResponse.FoodViewModels = new List<FoodViewModel>()
                {
                     await _foodService.GetFoodViewModelGetByIdAsync(id)
                };
                foodResponse.IsSuccess = true;
                foodResponse.Status = (int)HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                foodResponse.Message = ex.Message;
                foodResponse.MessageDetails = ex.ToString();
                foodResponse.Status = foodResponse.Status > 0 ? foodResponse.Status : (int)HttpStatusCode.BadRequest;
            }

            return StatusCode(foodResponse.Status, foodResponse);
        }
    }
}