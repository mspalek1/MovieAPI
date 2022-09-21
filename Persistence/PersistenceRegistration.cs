using Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace Persistence
{
    public static class PersistenceRegistration
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseAsyncRepository<>));
            services.AddScoped<IMovieAsyncRepository, MovieAsyncRepository>();
            return services;
        }
    }
}
