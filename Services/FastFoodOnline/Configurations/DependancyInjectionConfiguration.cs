using FastFoodOnline.Core.DataAccess;
using FastFoodOnline.Core.DataAccess.Repositories;
using FastFoodOnline.Core.Services;
using FastFoodOnline.DataAccess;
using FastFoodOnline.DataAccess.Repositories;
using FastFoodOnline.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace FastFoodOnline.Configurations
{
    public static class DependancyInjectionConfiguration
    {
        public static IServiceCollection RegisterDependancies(this IServiceCollection services)
        {
            #region Other - Dependancies

            // To get authentication token info
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            #endregion

            #region Repository - Dependencies

            services.AddScoped<IFoodRepository, FoodRepository>();
            services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<ISentEmailRepository, SentEmailRepository>();
            services.AddScoped<ISentMessageRepository, SentMessageRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthorizationRepository, AuthorizationRepository>();

            #endregion

            #region UnitOfWork - Dependencies

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #endregion

            #region Service - Dependencies

            services.AddScoped<IAuthenticateService, AuthenticateService>();
            services.AddScoped<IFoodService, FoodService>();
            services.AddScoped<IPaymentMethodService, PaymentMethodService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IUserService, UserService>();

            #endregion

            return services;
        }
    }
}
