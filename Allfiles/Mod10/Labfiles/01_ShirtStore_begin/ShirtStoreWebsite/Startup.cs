﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ShirtStoreWebsite.Data;
using Microsoft.EntityFrameworkCore;

namespace ShirtStoreWebsite
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
            services.AddDbContext<ShirtContext>(options =>
                 options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ShirtContext shirtContext)
        {
            shirtContext.Database.EnsureDeleted();
            shirtContext.Database.EnsureCreated();

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-US")
            });
            
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "defaultRoute",
                    template: "{controller=Shirt}/{action=Index}/{id?}");
            });
        }
    }
}
