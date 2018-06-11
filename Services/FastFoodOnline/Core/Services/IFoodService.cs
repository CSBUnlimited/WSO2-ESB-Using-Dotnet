using System.Collections.Generic;
using System.Threading.Tasks;
using FastFoodOnline.Core.Base.Services;
using FastFoodOnline.Resources.ViewModels;

namespace FastFoodOnline.Core.Services
{
    public interface IFoodService : IBaseService
    {
        /// <summary>
        /// Get All FoodViewModels - Async
        /// </summary>
        /// <returns>IEnumerable of FoodViewModel</returns>
        Task<IEnumerable<FoodViewModel>> GetAllFoodViewModelsAsync();

        /// <summary>
        /// Get FoodViewModel By Id - Async
        /// </summary>
        /// <param name="id">FoodViewModel Id</param>
        /// <returns>FoodViewModel</returns>
        Task<FoodViewModel> GetFoodViewModelGetByIdAsync(int id);
    }
}
