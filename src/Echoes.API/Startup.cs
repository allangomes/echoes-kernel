using System;
using System.IO;
using Auxo.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Echoes.API
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }
        public Startup(IHostingEnvironment env)
        {
            Console.WriteLine(env.ContentRootPath);
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("settings.json", false, true)
                .AddJsonFile($"settings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.DatabaseConfig(Configuration);
            services.AddMvcCore().AddJsonFormatters(settings => {
                settings.NullValueHandling = NullValueHandling.Ignore;  
            });
            services.RegisterServices();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseMvc(routes => routes.MapRoute(
                name: "default_route",
                template: "{controller}/{action}/{key?}",
                defaults: new { controller = "Home", action = "Index" }));
            HttpContext.Configure(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());
            Locator.Container = new Container();

            if (env.IsDevelopment())
                loggerFactory.AddConsole(LogLevel.Debug);
        }

        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .Build();

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();
            host.Run();
        }
    }
}