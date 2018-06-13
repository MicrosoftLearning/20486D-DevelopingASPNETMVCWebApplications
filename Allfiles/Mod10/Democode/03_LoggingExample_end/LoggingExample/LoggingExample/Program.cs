using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LoggingExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureLogging((hostingContext, logging) =>
            {
                IConfigurationSection configLogSection = hostingContext.Configuration.GetSection("LogLevel");
                logging.AddConfiguration(configLogSection);

                var env = hostingContext.HostingEnvironment;
                if (env.IsProduction())
                    logging.AddFile("myLog.txt", LogLevel.Warning);
            })
                .UseStartup<Startup>();
    }
}
