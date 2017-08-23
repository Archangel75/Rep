using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebAppAspCoreHello
{
    public class RoutingMiddleware
    {
        //Этот компонент в зависимости от строки запроса возвращает либо определенную строку, либо устанавливает код ошибки.
        private readonly RequestDelegate _next;

        public RoutingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string path = context.Request.Path.Value.ToLower();

            switch (path)
            {
                case "/index":
                    await context.Response.WriteAsync("Home page");
                    break;
                case "/about":
                    await context.Response.WriteAsync("About");
                    break;
                default:
                    context.Response.StatusCode = 404;
                    break;
            }

            await _next.Invoke(context);
        }
    }
}
