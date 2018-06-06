using FastFoodOnline.Core.Base.Repositories;
using FastFoodOnline.DataAccess.Persistence;

namespace FastFoodOnline.Base.Repositories
{
    public abstract class BaseRepository : IBaseRepository
    {
        /// <summary>
        /// Fast Food - DbContext
        /// </summary>
        public FastFoodDbContext DbContext { protected get; set; }
    }
}
