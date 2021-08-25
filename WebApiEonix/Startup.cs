using GlobalSettings =  Eonix.Configuration.GlobalSettings;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Eonix.Core.Utilities;

namespace WebApiEonix
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
            // Settings
            var globalSettings = services.AddGlobalSettingsServices(Configuration);
            // Entity Framework
            services.AddEntityFramework(globalSettings);
            // Repositories
            services.AddSqlServerRepositories();
            // Controllers
            services.AddControllers();
            // Register swagger
            services.AddSwaggerService(globalSettings);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
                              GlobalSettings globalSettings)
        {
            // Enable swagger
            app.UseSwaggerService(globalSettings);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
