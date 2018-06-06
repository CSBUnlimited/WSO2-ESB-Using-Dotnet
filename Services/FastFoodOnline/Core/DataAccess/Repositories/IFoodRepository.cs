using System.Collections.Generic;
using System.Threading.Tasks;
using FastFoodOnline.Core.Base.Repositories;
using FastFoodOnline.Models;

namespace FastFoodOnline.Core.DataAccess.Repositories
{
    public interface IFoodRepository : IBaseRepository
    {
        /// <summary>
        /// Get All Foods - Async
        /// </summary>
        /// <returns>IEnumerable of Food</returns>
        Task<IEnumerable<Food>> GetAllFoodsAsync();

        /// <summary>
        /// Get Food By Id - Async
        /// </summary>
        /// <param name="id">Food Id</param>
        /// <returns>Food</returns>
        Task<Food> GetFoodByIdAsync(int id);
    }
}
