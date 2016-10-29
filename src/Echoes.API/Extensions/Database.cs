using Echoes.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Echoes.API
{
    public static partial class Extensions
    {
        public static void DatabaseConfig(this IServiceCollection services, IConfigurationRoot config)
        {
            var pass = new
            { 
                Database = config["echoes_db:database"],
                Username = config["echoes_db:username"],
                Password = config["echoes_db:password"],
                Server = config["echoes_db:hostname"],
                Port = config["echoes_db:port"]
            };
            var appName = "Echoes Project";
            var connection = $@"Server={pass.Server};
                                Port={pass.Port};
                                User Id={pass.Username};
                                Password={pass.Password};
                                Database={pass.Database};
                                Application Name={appName}";
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<EchoesContext>(options => options.UseNpgsql(connection));
        }
    }
}