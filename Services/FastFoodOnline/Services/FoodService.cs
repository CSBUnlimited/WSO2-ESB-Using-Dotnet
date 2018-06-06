using System.Collections.Generic;
using System.Threading.Tasks;
using FastFoodOnline.Base.Services;
using FastFoodOnline.Core.DataAccess;
using FastFoodOnline.Core.Services;
using FastFoodOnline.Models;

namespace FastFoodOnline.Services
{
    public class FoodService : BaseService, IFoodService
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork Dependancy</param>
        public FoodService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }

        /// <summary>
        /// Get All Foods - Async
        /// </summary>
        /// <returns>IEnumerable of Food</returns>
        public async Task<IEnumerable<Food>> GetAllFoodsAsync()
        {
            return await UnitOfWork.FoodRepository.GetAllFoodsAsync();
        }

        /// <summary>
        /// Get Food By Id - Async
        /// </summary>
        /// <param name="id">Food Id</param>
        /// <returns>Food</returns>
        public async Task<Food> GetFoodByIdAsync(int id)
        {
            return await UnitOfWork.FoodRepository.GetFoodByIdAsync(id);
        }
    }
}
