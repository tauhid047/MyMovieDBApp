using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MyMovieDBApp.Models;
using MyMovieDBApp.Service;
using MyMovieDBApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovieDBApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            TheMovieDBAPIConstants.Url = Configuration.GetSection("TheMovieDBAPIInfo").GetValue<string>("URL");
            TheMovieDBAPIConstants.Key = Configuration.GetSection("TheMovieDBAPIInfo").GetValue<string>("Key");

            services.AddDbContextPool<UserContext>(options => options.UseSqlServer(Configuration.GetConnectionString("UserContextConnectionString")));
            services.AddScoped<IUser, UserService>();
            services.AddScoped<ISearchHistory, SearchHistoryservice>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
