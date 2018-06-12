using Microsoft.AspNetCore.Http;

namespace FastFoodOnline.Core.Base.Services
{
    /// <summary>
    /// Common service - Interface
    /// </summary>
    public interface IBaseService
    {
        /// <summary>
        /// HttpContextAccessor - For get token related data
        /// </summary>
        IHttpContextAccessor HttpContextAccessor { set; }
    }
}
