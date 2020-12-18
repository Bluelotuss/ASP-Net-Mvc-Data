using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Net_Mvc_Data.Models.Data;
using ASP_Net_Mvc_Data.Models.Database;
using ASP_Net_Mvc_Data.Models.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ASP_Net_Mvc_Data
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
            services.AddDbContext<PeopleDbContext>(options => options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddScoped<IPeopleRepo, InMemoryPeopleRepo>(); //Container setting for my IoC.
            services.AddScoped<IPeopleRepo, DatabasePeopleRepo>(); //Container setting for my IoC.
            services.AddScoped<IPeopleService, PeopleService>();

            services.AddScoped<ICityRepo, DatabaseCityRepo>();
            services.AddScoped<ICityService, CityService>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name: "AjaxPage",
                //    pattern: "AjaxPage/{id?}",
                //    defaults: new { controller = "AjaxPersons", action = "AjaxPage" });

                //endpoints.MapControllerRoute(
                //    name: "AjaxNextPage",
                //    pattern: "AjaxNextPage/{id?}",
                //    defaults: new { controller = "AjaxPersons", action = "AjaxNextPage" });

                //endpoints.MapControllerRoute(
                //    name: "AjaxDelete",
                //    pattern: "AjaxDelete/{id?}",
                //    defaults: new { controller = "AjaxPersons", action = "AjaxDelete" });

                endpoints.MapControllerRoute(
                    name: "AjaxFilter",
                    pattern: "AjaxFindByCityOrName/{filter?}",
                    defaults: new { controller = "AjaxPersons", action = "AjaxFindByCityOrName" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
