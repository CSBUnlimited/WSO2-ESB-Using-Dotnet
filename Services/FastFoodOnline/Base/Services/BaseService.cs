using AutoMapper;
using FastFoodOnline.Core.Base.Services;
using FastFoodOnline.Core.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace FastFoodOnline.Base.Services
{
    /// <summary>
    /// Common for all Services
    /// </summary>
    public abstract class BaseService : IBaseService
    {
        /// <summary>
        /// UnitOfWork for access repositories
        /// </summary>
        protected readonly IUnitOfWork UnitOfWork;
        /// <summary>
        /// Auto Mapper 
        /// </summary>
        protected readonly IMapper Mapper;
        /// <summary>
        /// Application Configurations
        /// </summary>
        protected readonly IConfiguration Configuration;

        /// <summary>
        /// HttpContextAccessor - For get token related data
        /// </summary>
        public IHttpContextAccessor HttpContextAccessor { protected get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork Dependancy</param>
        /// <param name="mapper">Auto Mapper Injection</param>
        protected BaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork Dependancy</param>
        /// <param name="mapper">Auto Mapper Injection</param>
        /// <param name="configuration">Configutaions of Application</param>
        protected BaseService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration) : this(unitOfWork, mapper)
        {
            Configuration = configuration;
        }
    }
}
