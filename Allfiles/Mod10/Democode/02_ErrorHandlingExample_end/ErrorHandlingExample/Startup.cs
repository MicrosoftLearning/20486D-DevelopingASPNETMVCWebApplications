using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ErrorHandlingExample.Services;
using Microsoft.AspNetCore.Http.Extensions;

namespace ErrorHandlingExample
{
    public class Startup
    {
        

         public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<ICounter,Counter>();
            services.AddSingleton<IPrimalNumberCalculator, PrimalNumberCalculator>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ICounter cnt)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.Use(async (context, next) =>
            {
                cnt.IncrementRequestPathCount(context.Request.GetDisplayUrl());
                await next.Invoke();
            });

            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
