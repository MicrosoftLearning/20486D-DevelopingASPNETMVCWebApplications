using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectricStore.Data;
using ElectricStore.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ElectricStore.Hubs;

namespace ElectricStore
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<StoreContext>(options =>
                 options.UseSqlite("Data Source=electricStore.db"));

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(60);
            });

            services.AddSignalR();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, StoreContext storeContext, IHostingEnvironment environment)
        {
            storeContext.Database.EnsureDeleted();
            storeContext.Database.EnsureCreated();

            app.UseStaticFiles();

            app.UseNodeModules(environment.ContentRootPath);

            app.UseSession();

            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHub>("/chatHub");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "ElectricStoreRoute",
                    template: "{controller}/{action}/{id?}/{RefreshCache?}",
                    defaults: new { controller = "Products", action = "Index" },
                    constraints: new { id = "[0-9]+" });
            });
        }
    }
}
