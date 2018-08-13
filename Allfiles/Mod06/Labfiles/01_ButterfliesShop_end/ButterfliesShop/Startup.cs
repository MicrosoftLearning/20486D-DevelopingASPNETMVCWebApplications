using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ButterfliesShop.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ButterfliesShop
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IDataService, DataService>();
            services.AddSingleton<IButterfliesQuantityService, ButterfliesQuantityService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "ButterflyRoute",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Butterfly", action = "Index" },
                    constraints: new { id = "[0-9]+" });
            });
        }
    }
}
