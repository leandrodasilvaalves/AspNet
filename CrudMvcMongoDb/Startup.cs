using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudMvcMongoDb.DataLayer;
using CrudMvcMongoDb.DataLayer.Abstracts;
using CrudMvcMongoDb.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrudMvcMongoDb
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
            services.AddMvc();
            //injecting Settings in the Options accessor model
           services.Configure<Settings>(Options =>
           {
               Options.ConnectionString =   Configuration.GetSection("MongoConnection:ConnectionString").Value;
               Options.DataBase = Configuration.GetSection("MongoConnection:Database").Value;
           });
           services.AddTransient<IProductService, ProductService>();
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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
