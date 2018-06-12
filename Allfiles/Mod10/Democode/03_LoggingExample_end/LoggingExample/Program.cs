using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace LoggingExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
    WebHost.CreateDefaultBuilder(args)
        .ConfigureLogging((hostingContext, logging) =>
        {
            var env = hostingContext.HostingEnvironment;
            logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));

            if (env.IsProduction())
                logging.AddFile("myLog.txt");

            if (env.IsDevelopment())
                logging.AddConsole();
        })
        .UseStartup<Startup>()
        .Build();


    }
}
