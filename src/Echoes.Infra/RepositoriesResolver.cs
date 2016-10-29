using Auxo.Data;
using Echoes.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Echoes.Infra
{
    public static partial class Resolver
    {
        public static void Repositories(IServiceCollection services)
        {
            services.AddScoped<IDataContext, EchoesContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}