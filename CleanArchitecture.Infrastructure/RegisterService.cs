using CleanArchitecture.Application.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure
{
    public static class RegisterService
    {
        public static void ConfigureInfrastructure(this IServiceCollection services,
    IConfiguration configuration)
        {
            services.AddMemoryCache();


            //services.AddScoped<ICacheService<string>, MemoryCacheService<string>>();

        }
    }
}
