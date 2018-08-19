using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddHttpClient();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();

            app.UseNodeModules(env.ContentRootPath);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                     name: "RestaurantRoute",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Restaurant", action = "Index" },
                    constraints: new { id = "[0-9]+" });
                routes.MapRoute(
                    name: "ReservationRoute",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Reservation", action = "Create" });
                routes.MapRoute(
                     name: "WantedAdRoute",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "WantedAd", action = "Index" },
                    constraints: new { id = "[0-9]+" });

            });
        }
    }
}
