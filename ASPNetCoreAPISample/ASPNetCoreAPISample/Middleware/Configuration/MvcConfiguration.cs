using ASPNetCoreAPISample.Filters;
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
        public static IServiceCollection AddCustomizedMvc(this IServiceCollection services)
        {
            services.AddMvc(opt =>
            {
                var jsonFormatter = opt.OutputFormatters.OfType<JsonOutputFormatter>().SingleOrDefault();
                if (jsonFormatter != null)
                {
                    opt.OutputFormatters.Remove(jsonFormatter);
                    opt.OutputFormatters.Add(new IonOutputFormatter(jsonFormatter));
                };
                opt.Filters.Add(typeof(JsonExceptionFilter));
            }
            );

            return services;
        }
    }
}
