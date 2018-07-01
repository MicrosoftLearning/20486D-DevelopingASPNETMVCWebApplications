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
using PhotoSharingSample.Models;

namespace PhotoSharingSample
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

            services.AddDbContext<PhotoSharingDB>(options =>
                   options.UseSqlServer(_configuration.GetConnectionString("PhotoSharingContext")));
        }

        public void Configure(IApplicationBuilder app, PhotoSharingDB photoSharingDB)
        {
            photoSharingDB.Database.EnsureDeleted();
            photoSharingDB.Database.EnsureCreated();

            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();
        }
    }
}
