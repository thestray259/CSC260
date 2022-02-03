using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InClass.Interfaces; 
using InClass.Data; 

namespace InClass
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
            services.AddControllersWithViews();
            services.AddTransient<IDataAccessLayer, MovieListDAL>(); 
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                /*                endpoints.MapControllerRoute(
                                    name: "PizzaToTest",
                                    //pattern: "pizza",
                                    //pattern: "pizza{id}", // ex pizza5 
                                    //pattern: "pizza/{id?}", // ex pizza/5
                                    pattern: "pizza/{id:int?}", // ex pizza/5 but has to be slash number 
                                    defaults: new { controller = "Home", action="Test" });*/

                /* endpoints.MapControllerRoute(
name: "catchall",
pattern: "{*catchall}", // could be anything instead of catchall 
defaults: new { controller = "home", action = "error" }
);*/

                /*                endpoints.MapControllerRoute(
                    name: "many", 
                    pattern: "colors/{*colors}",
                    defaults: new { controller = "Home", action = "Colors" }
                    ); */

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
