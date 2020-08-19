using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using GI = DemoMultiCategories.Models.Global.Interfaces;
using GS = DemoMultiCategories.Models.Global.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tools.Databases;
using DemoMultiCategories.Models.Client.Interfaces;
using DemoMultiCategories.Models.Client.Services;

namespace DemoMultiCategories
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
            services.AddSingleton<IConnectionInfo, ConnectionInfo>(sp => new ConnectionInfo(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DemoMultiCategories;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
            services.AddSingleton<DbProviderFactory, SqlClientFactory>(sp => SqlClientFactory.Instance);
            services.AddSingleton<IConnection, Connection>();
            services.AddSingleton<GI.ICategoryRepository, GS.CategoryService>();
            services.AddSingleton<ICategoryRepository, CategoryService>();

            services.AddSingleton<GI.IMovieRepository, GS.MovieService>();
            services.AddSingleton<IMovieRepository, MovieService>();
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
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
