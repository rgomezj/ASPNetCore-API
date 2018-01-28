using ASPNetCoreAPISample.Infrastructure;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreAPISample.Middleware.Configuration
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomizedRouting(this IServiceCollection services)
        {
            services.AddRouting(opt => opt.LowercaseUrls = true);
            return services;
        }
    }
}
