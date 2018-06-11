using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;

namespace FastFoodOnline.Configurations
{
    /// <summary>
    /// Swagger Configuration - Extention
    /// </summary>
    public static class SwaggerConfiguration
    {
        /// <summary>
        /// Swagger Configure Services
        /// </summary>
        /// <param name="services">Service Collection</param>
        /// <returns>Service Collection</returns>
        public static IServiceCollection SwaggerConfigureServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Swashbuckle.AspNetCore.Swagger.Info()
                    {
                        Title = "Fast Food Online APIs",
                        Version = "v1",
                        Description = "This is the documentation for Fast Food Online",
                        TermsOfService = "None",
                        Contact = new Swashbuckle.AspNetCore.Swagger.Contact()
                        {
                            Name = "Chathuranga Basnayake",
                            Email = "chathurangabasnayake@outlook.com"
                        }
                    });

                Dictionary<string, IEnumerable<string>> security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };

                c.AddSecurityDefinition("Bearer", new Swashbuckle.AspNetCore.Swagger.ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                c.AddSecurityRequirement(security);

                //var filePath = System.IO.Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "FastFoodOnline.xml");
                //c.IncludeXmlComments(filePath);
            });

            return services;
        }

        /// <summary>
        /// Swagger Configure
        /// </summary>
        /// <param name="app">Application Builder</param>
        /// <returns>Application Builder</returns>
        public static IApplicationBuilder UseSwaggerConfigure(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            return app;
        }
    }
}
