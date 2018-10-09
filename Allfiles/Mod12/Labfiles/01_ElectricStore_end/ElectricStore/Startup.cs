using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectricStore.Data;
using ElectricStore.Hubs;
using ElectricStore.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ElectricStore
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<StoreContext>(options =>
                 options.UseSqlite("Data Source=electricStore.db"));

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(60);
            });

            services.AddSignalR();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, StoreContext storeContext, IHostingEnvironment environment)
        {
            app.UseSession();

            storeContext.Database.EnsureDeleted();
            storeContext.Database.EnsureCreated();

            app.UseStaticFiles();

            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHub>("/chatHub");
            });

            app.UseNodeModules(environment.ContentRootPath);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "ElectricStoreRoute",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Products", action = "Index" },
                    constraints: new { id = "[0-9]+" });
            });
        }
    }
}
