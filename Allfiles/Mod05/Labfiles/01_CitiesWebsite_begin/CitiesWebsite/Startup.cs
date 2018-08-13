using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using CitiesWebsite.Services;

namespace CitiesWebsite
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<ICityProvider, CityProvider>();
            services.AddSingleton<ICityFormatter, CityFormatter>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "Default",
                template: "{controller}/{action}",
                defaults: new { controller = "City", action = "ShowCities" });
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Page not found");
            });
        }
    }
}
