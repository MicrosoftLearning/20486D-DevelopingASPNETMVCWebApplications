using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IceCreamCompany.Data;
using IceCreamCompany.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IceCreamCompany
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IRepository, Repository>();

            services.AddDbContext<IceCreamContext>(options =>
                 options.UseSqlite("Data Source=iceCream.db"));

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IceCreamContext iceCreamContext)
        {
            iceCreamContext.Database.EnsureDeleted();
            iceCreamContext.Database.EnsureCreated();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "IceCreamRoute",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "IceCream", action = "Index" },
                    constraints: new { id = "[0-9]+" });
            });
        }
    }
}
