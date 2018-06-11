using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FastFoodOnline.Base.Services;
using FastFoodOnline.Core.DataAccess;
using FastFoodOnline.Core.Services;
using FastFoodOnline.Models;
using FastFoodOnline.Resources.ViewModels;

namespace FastFoodOnline.Services
{
    public class FoodService : BaseService, IFoodService
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork Dependancy</param>
        /// <param name="mapper">Auto Mapper Injection</param>
        public FoodService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        { }

        /// <summary>
        /// Get All FoodViewModels - Async
        /// </summary>
        /// <returns>IEnumerable of FoodViewModel</returns>
        public async Task<IEnumerable<FoodViewModel>> GetAllFoodViewModelsAsync()
        {
            return Mapper.Map<IEnumerable<Food>, IEnumerable<FoodViewModel>>(await UnitOfWork.FoodRepository.GetAllFoodsAsync());
        }

        /// <summary>
        /// Get FoodViewModel By Id - Async
        /// </summary>
        /// <param name="id">FoodViewModel Id</param>
        /// <returns>FoodViewModels</returns>
        public async Task<FoodViewModel> GetFoodViewModelGetByIdAsync(int id)
        {
            return Mapper.Map<Food, FoodViewModel>(await UnitOfWork.FoodRepository.GetFoodByIdAsync(id));
        }
    }
}
