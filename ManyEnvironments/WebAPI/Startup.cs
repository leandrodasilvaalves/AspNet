using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Model;
using Model.DataBase;
using Model.Interfaces;
using WebAPI.Classes;
using WebAPI.Extensions;
using WebAPI.Interfaces;

namespace WebAPI
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;
        public IConfiguration Configuration { get; private set; }

        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            _env = env;
            Configuration = configuration;

            var builder = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                //.AddJsonFile($"appsettings.{_env.EnvironmentName}.json",true)
                //.AddEnvironmentVariables()
                .Build();

            var dbConfig = new DatabaseConfiguration();
            builder.Bind(dbConfig);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddTransient<IClock, Clock>();
            services.AddTransient(typeof(IMongoDal<>), typeof(MongoDal<>));
            services.AddTransient<IPersonMongoDal, PersonMongoDal>();

            services.Configure<DatabaseConfiguration>(opt =>
            {
                opt.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                opt.DatabaseName = Configuration.GetSection("MongoConnection:Database").Value;
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();

            
            //var options = new DefaultFilesOptions();
            //options.DefaultFileNames.Clear();
            //options.DefaultFileNames.Add("index.html");
            //app.UseDefaultFiles(options);
            //app.UseFileServer();

            if (_env.IsDevelopment() || _env.IsQA())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseStatusCodePagesWithRedirects("~/error{0}.html");
            }

            app.UseMvcWithDefaultRoute();
            
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
