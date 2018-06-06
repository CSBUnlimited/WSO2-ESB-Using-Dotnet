using System.Collections.Generic;
using FastFoodOnline.Base.DTOs;
using FastFoodOnline.Resources.ViewModels;

namespace FastFoodOnline.Resources.DTOs.Food
{
    public class FoodResponse : BaseResponse
    {
        public IEnumerable<FoodViewModel> FoodViewModels { get; set; }
    }
}
