using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitiesDetails.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CitiesDetails
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<ICityProvider, CityProvider>();
        }
        
        public void Configure(IApplicationBuilder app)
        {
            app.UseExceptionHandler();

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
