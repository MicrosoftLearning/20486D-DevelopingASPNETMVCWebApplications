using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "RestaurantRoute",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Restaurant", action = "Index" },
                    constraints: new { id = "[0-9]+" });
                routes.MapRoute(
                     name: "EmployeeRoute",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Employee", action = "Index" },
                    constraints: new { id = "[0-9]+" }
                    );
            });
        }
    }
}
