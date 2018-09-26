using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Harman.Services.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //BuildWebHost(args).Run();
            var host = new WebHostBuilder()
                .UseApplicationInsights()
                .UseKestrel()
                .ConfigureAppConfiguration(ConfigureAppConfiguration)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();
            host.Run();


        }

        private static void ConfigureAppConfiguration(WebHostBuilderContext context, IConfigurationBuilder configBuilder)
        {
            var env = context.HostingEnvironment;

              

                // Configuration: add some configuration from an in memory collection
            configBuilder.AddInMemoryCollection(new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Setting1", "Setting1Value"),
                    new KeyValuePair<string, string>("Setting2", "Setting2Value")
                })

                // Configuration: add configuration from some optional .json files
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)

                // Configuration: add some configuration from environment variables
                .AddEnvironmentVariables();
        }
    }
}
