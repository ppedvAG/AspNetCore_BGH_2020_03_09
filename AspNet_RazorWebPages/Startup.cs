using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using AspNet_RazorWebPages.Pages.Modul05;
using Microsoft.EntityFrameworkCore;
using AspNet_RazorWebPages.Data;

namespace AspNet_RazorWebPages
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
            services.AddRazorPages();

            services.AddControllers();

            // Session regestrieren
            services.AddSession();

            services.AddDbContext<AufgabenContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("AufgabenContext")));

            services.AddDbContext<AufgabenContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("AufgabenContext")));
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            AppDomain.CurrentDomain.SetData("BildVerzeichnis", env.WebRootPath);
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            // Verwenden des Session Features
            app.UseSession();
            app.UseAuthorization();
            app.UseAuthentication();

            app.MapWhen(context => context.Request.Path.ToString().Contains("imagegen"), subapp =>
            {
                subapp.UseThumbNailGen();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
