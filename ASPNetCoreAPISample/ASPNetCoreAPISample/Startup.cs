using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NLog.Web;
using NLog.Extensions.Logging;
using ASPNetCoreAPISample.Infrastructure;
using ASPNetCoreAPISample.Middleware.Configuration;
using ASPNetCoreAPISample.Data;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCoreAPISample
{
    public class Startup
    {
        Microsoft.Extensions.Configuration.IConfigurationRoot _launchSettings;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
            
            _launchSettings = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("Properties\\launchSettings.json")
                .Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<HotelApiContext>(opt => opt.UseInMemoryDatabase("Hotel"));
            services.AddCustomizedMvc(_launchSettings);
            services.AddCustomizedRouting();
            services.AddCustomizedVersioning();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            env.ConfigureNLog("nlog.config");
            loggerFactory.AddNLog();
            app.AddNLogWeb();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var serviceScope = app.ApplicationServices.CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetService<HotelApiContext>();
                    HotelApiContext.AddTestData(context);
                }
            }

            app.UseHsts(opt =>
            {
                opt.MaxAge(days: 180);
                opt.IncludeSubdomains();
                opt.Preload();
            });

            app.UseMvc();
        }
    }
}
