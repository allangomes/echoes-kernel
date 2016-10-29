using Auxo.Messages;
using Microsoft.Extensions.DependencyInjection;

namespace Echoes.Infra
{
    public static partial class Resolver
    {
        public static void Application(IServiceCollection services)
        {
            services.AddScoped<IMessageHandler<Message>, MessageHandler>();
        }
    }
}