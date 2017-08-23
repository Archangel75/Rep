using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebAppAspCoreHello
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;
        string pattern;
        

        public TokenMiddleware(RequestDelegate next, string pattern)
        {
            this._next = next;
            this.pattern = pattern;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Query["token"];
            if (string.IsNullOrEmpty(token) || token != pattern)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Cabooooooooooooooop token wrong vorui poloskai");
            }
            else
            {
                await _next.Invoke(context);
            }

        }


    }
}
