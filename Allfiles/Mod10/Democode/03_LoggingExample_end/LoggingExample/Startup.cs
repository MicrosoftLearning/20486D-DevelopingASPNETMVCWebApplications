using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using LoggingExample.Services;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;

namespace LoggingExample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<ICounter, Counter>();
            services.AddSingleton<IDivisionCalculator, DivisionCalculator>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ICounter cnt, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error.html");
            }
            
            app.UseStaticFiles();

            app.Use(async (context, next) =>
            {
                string page = context.Request.GetDisplayUrl();
                cnt.IncrementRequestPathCount(page);
                await next.Invoke();
            });

            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Page not found.");
            });
        }
    }
}
