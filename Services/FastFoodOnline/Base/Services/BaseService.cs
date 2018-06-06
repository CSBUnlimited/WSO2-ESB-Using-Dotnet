using FastFoodOnline.Core.Base.Services;
using FastFoodOnline.Core.DataAccess;

namespace FastFoodOnline.Base.Services
{
    public abstract class BaseService : IBaseService
    {
        protected readonly IUnitOfWork UnitOfWork;

        protected BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
