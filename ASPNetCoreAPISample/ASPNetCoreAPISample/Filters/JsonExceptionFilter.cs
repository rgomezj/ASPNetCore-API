using ASPNetCoreAPISample.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreAPISample.Filters
{
    public class JsonExceptionFilter : IExceptionFilter
    {
        private readonly IHostingEnvironment _env;

        public JsonExceptionFilter(IHostingEnvironment env)
        {
            _env = env;
        }

        public void OnException(ExceptionContext context)
        {
            var response = new ApiError();
            if(_env.IsDevelopment())
            {
                response.Message = context.Exception.Message;
                response.Detail = context.Exception.StackTrace;
            }
            else
            {
                response.Message = "A Server Error Ocurred";
                response.Detail = context.Exception.Message;
            }

            var result = new ObjectResult(response);
            context.Result = result;
        }
    }
}
