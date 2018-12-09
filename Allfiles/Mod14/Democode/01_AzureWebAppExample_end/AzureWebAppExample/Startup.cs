using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureWebAppExample.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AzureWebAppExample
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

            services.AddDbContext<PhotoAlbumContext>(options =>
                   options.UseSqlServer(_configuration.GetConnectionString("PhotoAlbumContext")));
        }

        public void Configure(IApplicationBuilder app, PhotoAlbumContext photoAlbumContext)
        {
            photoAlbumContext.Database.EnsureDeleted();
            photoAlbumContext.Database.EnsureCreated();

            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();
        }
    }
}
