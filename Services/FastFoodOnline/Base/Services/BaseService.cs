using AutoMapper;
using FastFoodOnline.Core.Base.Services;
using FastFoodOnline.Core.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace FastFoodOnline.Base.Services
{
    public abstract class BaseService : IBaseService
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IMapper Mapper;
        protected readonly IConfiguration Configuration;

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
