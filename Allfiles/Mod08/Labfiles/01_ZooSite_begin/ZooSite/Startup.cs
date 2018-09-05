using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZooSite.Data;

namespace ZooSite
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
            services.AddDbContext<ZooContext>(options =>
                  options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ZooContext zooContext)
        {
            zooContext.Database.EnsureDeleted();
            zooContext.Database.EnsureCreated();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "ZooRoute",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Zoo", action = "Index" },
                    constraints: new { id = "[0-9]+" });
            });
        }
    }
}
