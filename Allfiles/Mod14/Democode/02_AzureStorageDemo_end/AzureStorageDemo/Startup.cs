using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureStorageDemo.Data;
using AzureStorageDemo.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AzureStorageDemo
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
            services.AddMvc();

            services.AddDbContext<PhotoContext>(options =>
                 options.UseSqlite("Data Source=photoDb.db"));
        }

        public void Configure(IApplicationBuilder app, PhotoContext photoContext, IHostingEnvironment environment)
        {
            photoContext.Database.EnsureDeleted();
            photoContext.Database.EnsureCreated();

            app.UseStaticFiles();

            app.UseNodeModules(environment.ContentRootPath);

            app.UseMvcWithDefaultRoute();
        }
    }
}
