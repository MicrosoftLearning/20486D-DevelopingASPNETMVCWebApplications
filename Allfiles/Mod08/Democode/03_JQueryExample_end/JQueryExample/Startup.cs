using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JQueryExample.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace JQueryExample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();

            app.UseNodeModules(env.ContentRootPath);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "GradeBookRoute",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "GradeBook", action = "Index" },
                    constraints: new { id = "[0-9]+" });
            });
        }
    }
}
