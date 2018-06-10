using FastFoodOnline.Core.Base.Services;
using FastFoodOnline.Core.DataAccess;
using Microsoft.Extensions.Configuration;

namespace FastFoodOnline.Base.Services
{
    public abstract class BaseService : IBaseService
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IConfiguration Configuration;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork Dependancy</param>
        protected BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork Dependancy</param>
        /// <param name="configuration">Configutaions of Application</param>
        protected BaseService(IUnitOfWork unitOfWork, IConfiguration configuration) : this(unitOfWork)
        {
            Configuration = configuration;
        }
    }
}
