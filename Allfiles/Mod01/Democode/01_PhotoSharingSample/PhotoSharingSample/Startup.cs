using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Register Mvc as a service
            services.AddMvc();

            //Register PhotoSharingContext as a service
            services.AddDbContext<PhotoSharingDB>(options =>
                   options.UseSqlServer(_configuration.GetConnectionString("PhotoSharingContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //add static files to the http request pipeline
            app.UseStaticFiles();

            //add mvc route to the http request pipeline with the default template
            app.UseMvcWithDefaultRoute();
        }
    }
}
