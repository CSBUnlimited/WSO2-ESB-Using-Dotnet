using FastFoodOnline.DataAccess.Persistence;

namespace FastFoodOnline.Core.Base.Repositories
{
    /// <summary>
    /// Common Repository - Interface
    /// </summary>
    public interface IBaseRepository
    {
        /// <summary>
        /// Fast Food DbContext - For access Database data
        /// </summary>
        FastFoodDbContext DbContext { set; }
    }
}
