using Microsoft.Extensions.DependencyInjection;

namespace Echoes.Infra
{
    public static partial class Resolver
    {
        public static void All(IServiceCollection services)
        {
            Application(services);
            Repositories(services);
            Services(services);
        }
        public static void ResolveDependencies(this IServiceCollection services) => All(services);
    }
}