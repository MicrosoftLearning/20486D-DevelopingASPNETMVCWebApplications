using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Server.Data;

namespace Server
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<RestaurantContext>(options =>
                  options.UseSqlite("Data Source=restaurant.db"));


            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                                                     .AllowAnyMethod()
                                                                      .AllowAnyHeader()));

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, RestaurantContext restaurantContext)
        {
            restaurantContext.Database.EnsureDeleted();
            restaurantContext.Database.EnsureCreated();

            app.UseCors("AllowAll");

            app.UseMvc();

        }
    }
}
