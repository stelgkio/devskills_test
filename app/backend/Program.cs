using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .UseSerilog((context, serilog) =>
               {
                   serilog
                       .ReadFrom.Configuration(context.Configuration)
                       .Enrich.FromLogContext()
                       .Enrich.WithProperty("DevSkill", Assembly.GetEntryAssembly()?.GetName().Version);
               })
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder.UseStartup<Startup>();
                   webBuilder.CaptureStartupErrors(true);
                   webBuilder.ConfigureAppConfiguration((context, configuration) =>
                   {
                       if (args != null)
                           configuration.AddCommandLine(args);

                       var env = context.HostingEnvironment;

                       configuration
                           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                           .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true,
                               reloadOnChange: true);

                       configuration.AddEnvironmentVariables();
                   });
               });

    }
}
