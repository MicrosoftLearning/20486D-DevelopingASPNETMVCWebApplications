using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using CachingExample.Data;
using Microsoft.EntityFrameworkCore;
using CachingExample.Repositories;

namespace CachingExample
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
            services.AddDbContext<ProductContext>(options =>
                 options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, ProductContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "defaultRoute",
                    template: "{controller=Product}/{action=Index}/{id?}");
            });
        }
    }
}
