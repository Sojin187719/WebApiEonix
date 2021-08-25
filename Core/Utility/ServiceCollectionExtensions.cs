using Core.EonixDBContext;
using GlobalSettings = Eonix.Configuration.GlobalSettings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Core.Repositories;
using Core.Repositories.Implementation;

namespace Eonix.Core.Utilities
{
	public static class ServiceCollectionExtensions
    {
        public static void AddEntityFramework(this IServiceCollection services, GlobalSettings globalSettings)
        {
            services.AddDbContext<EonixContext>(
                options =>
                {
                    options.UseSqlServer(globalSettings.SqlServer.EonixConnectionString);
                });
        }

        public static void AddSqlServerRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPersonRepository, PersonRepository>();
		}
        public static GlobalSettings AddGlobalSettingsServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            var globalSettings = new GlobalSettings();
            configuration.GetSection("GlobalSettings").Bind(globalSettings);
            services.AddSingleton(s => globalSettings);
            return globalSettings;
        }
        public static void AddSwaggerService(this IServiceCollection services, GlobalSettings globalSettings)
        {
            if (globalSettings.Swagger.IsActive)
            {
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApiEonix", Version = "v1" });
                });
            }
        }
        public static void UseSwaggerService(this IApplicationBuilder app, GlobalSettings globalSettings)
        {
            if (globalSettings.Swagger.IsActive)
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint($"{globalSettings.BaseServiceUri.Api}/swagger/v1/swagger.json", "Eonix API V1");
                });
            }
        }
    }
}
