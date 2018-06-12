using FastFoodOnline.Core.Base.Repositories;
using FastFoodOnline.DataAccess.Persistence;

namespace FastFoodOnline.Base.Repositories
{
    /// <summary>
    /// Common for all reposioties
    /// </summary>
    public abstract class BaseRepository : IBaseRepository
    {
        /// <summary>
        /// Fast Food DbContext - For access Database data
        /// </summary>
        public FastFoodDbContext DbContext { protected get; set; }
    }
}
