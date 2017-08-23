using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebAppAspCoreHello
{
    public class TimeMiddleWare
    {
        private readonly RequestDelegate _next;
        TimeService _ts;

        public TimeMiddleWare(RequestDelegate next, TimeService ts)
        {
            _next = next;
            _ts = ts;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.Value.ToLower() == "/time")
            {
                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.WriteAsync($"Datetimenow is : {_ts?.gettime()}");

            }
            else
                await _next.Invoke(context);
        }
    }

    public static class TimerExtensions
    {
        public static IApplicationBuilder BoopTimer(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimeMiddleWare>();
        }
    }
}
