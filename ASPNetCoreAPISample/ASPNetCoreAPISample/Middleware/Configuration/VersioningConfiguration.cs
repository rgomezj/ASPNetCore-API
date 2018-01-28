using ASPNetCoreAPISample.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreAPISample.Middleware.Configuration
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomizedVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(opt => {
                opt.ApiVersionReader = new MediaTypeApiVersionReader();
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.DefaultApiVersion = new ApiVersion(1, 0);
                opt.ReportApiVersions = true;
                opt.ApiVersionSelector = new CurrentImplementationApiVersionSelector(opt);
            });
            return services;
        }
    }
}
