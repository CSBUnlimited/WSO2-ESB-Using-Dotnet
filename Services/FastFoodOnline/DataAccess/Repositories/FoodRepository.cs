using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastFoodOnline.Base.Repositories;
using FastFoodOnline.Core.DataAccess.Repositories;
using FastFoodOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace FastFoodOnline.DataAccess.Repositories
{
    public class FoodRepository : BaseRepository, IFoodRepository
    {
        /// <summary>
        /// Get All Foods - Async
        /// </summary>
        /// <returns>IEnumerable of Food</returns>
        public async Task<IEnumerable<Food>> GetAllFoodsAsync()
        {
            //IsActive is nullable so have to check true explicitly
            return await DbContext.Foods.Where(f => f.IsActive == true).ToListAsync();
        }

        /// <summary>
        /// Get Food By Id - Async
        /// </summary>
        /// <param name="id">Food Id</param>
        /// <returns>Food</returns>
        public async Task<Food> GetFoodByIdAsync(int id)
        {
            return await DbContext.Foods.SingleOrDefaultAsync(f => f.IsActive == true && f.Id == id);
        }
    }
}
