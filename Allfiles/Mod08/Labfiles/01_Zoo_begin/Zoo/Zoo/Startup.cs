using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Zoo
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //app.UseStaticFiles();

            //app.UseNodeModules(env.ContentRootPath);

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "ZooRoute",
            //        template: "{controller}/{action}/{id?}",
            //        defaults: new { controller = "Zoo", action = "Index" },
            //        constraints: new { id = "[0-9]+" });
            //});
        }
    }
}
