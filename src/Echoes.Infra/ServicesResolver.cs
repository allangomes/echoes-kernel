using Echoes.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Echoes.Infra
{
    public static partial class Resolver
    {
        public static void Services(IServiceCollection services)
        {
            services.AddScoped<StateService>();
            services.AddScoped<CityService>();
        }
    }
}