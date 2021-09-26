using BookingSystem.Api.Services;
using BookingSystem.Common.Mediator;
using BookingSystem.Persistence.Repositories;
using BookingSystem.Persistence.Repositories.Interfaces;
using BookingSystem.Services.Booking;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BookingSystem.Api.Config
{
    public static class Register
    {
        public static IServiceCollection RegisterRepos(this IServiceCollection services)
        {
            services.AddScoped<IBookingRepo, BookingRepo>();
            services.AddScoped<IResourceRepo, ResourceRepo>();
            return services;
        }

        public static IServiceCollection RegisterMediator(this IServiceCollection services)
        {
            services.AddScoped<IMediatorService, MediatorService>();
            services.AddMediatR(typeof(BookingService));
            return services;
        }

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ResourceService>();
            services.AddScoped<BookingService>();
            services.AddSingleton<AppSettingsService>();

            return services;
        }
    }
}
