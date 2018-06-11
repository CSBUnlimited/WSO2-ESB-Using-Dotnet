using Microsoft.AspNetCore.Http;

namespace FastFoodOnline.Core.Base.Services
{
    public interface IBaseService
    {
        IHttpContextAccessor HttpContextAccessor { set; }
    }
}
