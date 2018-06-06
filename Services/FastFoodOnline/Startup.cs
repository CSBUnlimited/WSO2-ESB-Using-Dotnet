using System;
using AutoMapper;
using FastFoodOnline.Configurations;
using FastFoodOnline.DataAccess.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FastFoodOnline
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Setup DbContext Connection String
            services.AddDbContext<FastFoodDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("Default")));

            //Allow any origin to access 
            //Not secure but only for this Assignment
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                    });
            });

            #region Auto Mapper Configs

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfileConfiguration());
            });

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);

            #endregion

            //Dependancy Injection
            services.RegisterDependancies();

            // Add MVC
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Access-Control-Allow-Origin
            app.UseCors("AllowAll");

            // Add MVC
            app.UseMvc();

            // Database Intilization 
            var optionsBuilder = new DbContextOptionsBuilder<FastFoodDbContext>();
            optionsBuilder.UseSqlite(Configuration.GetConnectionString("Default"));

            using (var context = new FastFoodDbContext(optionsBuilder.Options))
            {
                Console.WriteLine("Database Migration started...");
                context.InitializeDatabase();
                Console.WriteLine("Database Migrated and Seeded...");
            }
        }
    }
}
