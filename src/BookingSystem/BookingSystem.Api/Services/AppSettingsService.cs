using BookingSystem.Api.Services.Contracts;
using Microsoft.Extensions.Configuration;

namespace BookingSystem.Api.Services
{
    public class AppSettingsService
    {
        public AppSettingsService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public CorsSettings CorsSettings
        {
            get
            {
                var corsSettings = new CorsSettings();
                Configuration.GetSection("app:corsSettings").Bind(corsSettings);
                return corsSettings;
            }
        }

        public IConfiguration Configuration { get; }
    }
}
