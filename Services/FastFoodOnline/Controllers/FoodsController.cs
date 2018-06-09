using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using FastFoodOnline.Core.Services;
using FastFoodOnline.Models;
using FastFoodOnline.Resources.DTOs.Food;
using FastFoodOnline.Resources.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IMapper _mapper;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="foodService">FoodService</param>
        /// <param name="mapper">Automapper</param>
        public FoodController(IFoodService foodService, IMapper mapper)
        {
            _foodService = foodService;
            _mapper = mapper;
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
                foodResponse.FoodViewModels = _mapper.Map<IEnumerable<Food>, IEnumerable<FoodViewModel>>(await _foodService.GetAllFoodsAsync());
                foodResponse.IsSuccess = true;
                foodResponse.Status = (int)HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                foodResponse.Message = ex.Message;
                foodResponse.MessageDetails = ex.ToString();
                foodResponse.Status = foodResponse.Status > 0 ? foodResponse.Status : (int)HttpStatusCode.Conflict;
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
                     _mapper.Map<Food, FoodViewModel>(await _foodService.GetFoodByIdAsync(id))
                };
                foodResponse.IsSuccess = true;
                foodResponse.Status = (int)HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                foodResponse.Message = ex.Message;
                foodResponse.MessageDetails = ex.ToString();
                foodResponse.Status = foodResponse.Status > 0 ? foodResponse.Status : (int)HttpStatusCode.Conflict;
            }

            return StatusCode(foodResponse.Status, foodResponse);
        }
    }
}