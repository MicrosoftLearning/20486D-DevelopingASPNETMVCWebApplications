using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WorldJourney.Filters;
using WorldJourney.Models;

namespace WorldJourney
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //Add service
            services.AddSingleton<IData, Data>();
            //Add service
            services.AddScoped<LogActionFilter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //Create a file for the log data
            loggerFactory.AddFile("Logs/log-{Date}.txt");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            //Custom routes
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                     name: "HistoricalSiteRoute",
                     template: "{controller}/{action}/{id}",
                     defaults: new { controller = "HistoricalSite", action = "Details" },
                     constraints: new { id = "[0-9]+" });

                routes.MapRoute(
                    name: "defaultRoute",
                    template: "{controller}/{action}",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
