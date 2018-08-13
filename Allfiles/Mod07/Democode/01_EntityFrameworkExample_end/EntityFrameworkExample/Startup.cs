using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkExample.Data;

namespace EntityFrameworkExample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PersonContext>(options =>
                    options.UseSqlite("Data Source=person.db"));

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
