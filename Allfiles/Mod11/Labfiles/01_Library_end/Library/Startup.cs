using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data;
using Library.Middleware;
using Library.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library
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

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 7;
                options.Password.RequireUppercase = true;

                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<LibraryContext>();

            services.AddDbContext<LibraryContext>(options =>
                  options.UseSqlite("Data Source=student.db"));

            services.AddMvc();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdministratorRole", policy => policy.RequireRole("Administrator"));
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, LibraryContext libraryContext, IServiceProvider serviceProvider, RoleManager roleManager)
        {
            libraryContext.Database.EnsureDeleted();
            libraryContext.Database.EnsureCreated();

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseNodeModules(env.ContentRootPath);

            roleManager.CreateRoles(serviceProvider, _configuration).Wait();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "StudentRoute",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Library", action = "Index" },
                    constraints: new { id = "[0-9]+" });
            });
        }
    }
}
