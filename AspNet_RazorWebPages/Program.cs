using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Serilog;

namespace AspNet_RazorWebPages
{
    public class Program
    {

        // Logging-Sample -> https://blog.tedd.no/2019/06/20/asp-net-core-logging-with-serilog/
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            try
            {
                Log.Information("Starting web host");

                IHost hostBuilder = CreateHostBuilder(args).Build();

                hostBuilder.Run();
            }
            catch(Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {

                    #region Verwenden des Kestrel Webserver
                    //Um zusätzliche Konfiguration nach dem Aufruf von ConfigureWebHostDefaults bereitzustellen, verwenden Sie ConfigureKestrel
                    //Referenz: -> https://docs.microsoft.com/de-de/aspnet/core/fundamentals/servers/kestrel?view=aspnetcore-3.1
                    //webBuilder.ConfigureKestrel(serverOptions =>
                    //{
                    //    // Set properties and call methods on options
                    //    serverOptions.AddServerHeader = true;
                    //    serverOptions.AllowSynchronousIO = true;

                    //    // Referenzüberblick
                    //    //https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.server.kestrel.core.kestrelserveroptions?view=aspnetcore-3.1
                    //});
                    #endregion

                    #region Verwenden des Http Sys WebServers
                    #region Verwenden des HTTP-Sys WebServer
                    //Wenn der HTTP-Sys WebServer verwendet werden kann
                    //Referenz: -> https://docs.microsoft.com/de-de/aspnet/core/fundamentals/servers/httpsys?view=aspnetcore-3.1
                    //webBuilder.UseHttpSys(options =>
                    //{
                    //    options.AllowSynchronousIO = true;
                    //    options.Authentication.Schemes = AuthenticationSchemes.None; //AuthenticationSchema ist in 2 Namespaces zu finden
                    //    options.Authentication.AllowAnonymous = true;
                    //    options.MaxConnections = null;
                    //    options.MaxRequestBodySize = 30000000;
                    //    options.UrlPrefixes.Add("http://localhost:5005");
                    //});
                    #endregion
                    #endregion



                    //Kestrel -> https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.server.kestrel.core.kestrelserveroptions?view=aspnetcore-3.1
                    //http sys webserver -> https://docs.microsoft.com/de-de/aspnet/core/fundamentals/servers/httpsys?view=aspnetcore-3.1
                    webBuilder.UseSerilog();
                    webBuilder.UseStartup<Startup>();
                });
    }
}
