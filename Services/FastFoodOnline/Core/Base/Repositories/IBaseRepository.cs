using FastFoodOnline.DataAccess.Persistence;

namespace FastFoodOnline.Core.Base.Repositories
{
    public interface IBaseRepository
    {
        FastFoodDbContext DbContext { set; }
    }
}
