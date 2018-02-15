using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PhotoSharingSample.Models;

namespace PhotoSharingSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            //Create database context instance from the dependency injection container
            using (var newScope = host.Services.CreateScope())
            {
                var scopeServices = newScope.ServiceProvider;
                try
                {
                    var dbContext = scopeServices.GetRequiredService<PhotoSharingDB>();
                    PhotoSharingInitializer.Seed(dbContext);
                }
                catch (Exception ex)
                {
                    var log = scopeServices.GetRequiredService<ILogger<Program>>();
                    log.LogError(ex, "Seed data error");
                }
            }
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
