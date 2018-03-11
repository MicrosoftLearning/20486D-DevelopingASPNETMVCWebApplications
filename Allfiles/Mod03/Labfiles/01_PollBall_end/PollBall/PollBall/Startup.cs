using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PollBall.Services;

namespace PollBall
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IPollResultsService, PollResultsService>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IPollResultsService pollResults)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvcWithDefaultRoute();


            app.Use(async (context, next) =>
            {
                if (context.Request.Query.ContainsKey("Favorite"))
                {
                    string selectedValue = context.Request.Query["Favorite"];
                    SelectedGame selectedGame = (SelectedGame)Enum.Parse(typeof(SelectedGame), selectedValue);
                    pollResults.AddVote(selectedGame);

                    if (env.IsDevelopment())
                    {
                        SortedDictionary<SelectedGame, int> gameVotes = pollResults.GetVoteResult();

                        foreach (KeyValuePair<SelectedGame, int> currentVote in gameVotes)
                        {
                            await context.Response.WriteAsync($"<p> Game name: {currentVote.Key}, Votes: {currentVote.Value} </p>");
                        }
                    }
                    else await context.Response.WriteAsync($"Thank you for submitting !");
                }
                else await next();
            });

            app.UseStaticFiles();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
