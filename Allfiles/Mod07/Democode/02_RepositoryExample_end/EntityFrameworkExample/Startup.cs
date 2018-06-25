using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EntityFrameworkExample.Data;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkExample.Repositories;


namespace EntityFrameworkExample
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
            services.AddDbContext<PersonContext>(options =>
                 options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IRepository, MyRepository>();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, PersonContext personContext)
        {
            personContext.Database.EnsureDeleted();
            personContext.Database.EnsureCreated();

            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "defaultRoute",
                    template: "{controller=Person}/{action=Index}/{id?}");
            });
        }
    }
}
