using BookingSystem.Api.Config;
using BookingSystem.Api.Services;
using BookingSystem.Persistence.DbContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookingSystem.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AppSettings = new AppSettingsService(configuration);
        }

        public IConfiguration Configuration { get; }
        public AppSettingsService AppSettings { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<AppDbContext>();

            services.RegisterRepos()
                .RegisterServices()
                .RegisterMediator();

            services.AddCors(options =>
            {
                options.AddPolicy(
                    name: AppSettings.CorsSettings.CorsPolicyName,
                    builder => builder.WithOrigins(AppSettings.CorsSettings.AllowedCorsOrigins).AllowAnyHeader().AllowAnyMethod());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(AppSettings.CorsSettings.CorsPolicyName);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
