using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace WebAppAspCoreHello
{
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="env">позволяет взаимодействовать со средой в которой запускается приложение</param>
        /// <param name="loggerFactory">предоставляет механизм логгирования в приложении</param>

        public Startup(IHostingEnvironment env, Microsoft.Extensions.Logging.ILoggerFactory loggerFactory)
        {

        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthenticationCore();
            services.AddMvc();
            services.AddTransient<TimeService>();
            services.AddDirectoryBrowser();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, TimeService ts)
        {
			//тест гита
			//тест гита апдейтед
			
			//caboop beep bup more comments pls
            //buiasehugjea
			
			//it`s master detka

            app.UseDirectoryBrowser(new DirectoryBrowserOptions()
            {
                //это в какой папке в проекте искать файлики
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Content")),
                //это по какому пути в запросе их отображать
                RequestPath = new PathString("/pages")
            });
            app.UseStaticFiles();

            /*
            //для запуска кастомного хтмл
            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("Boop.html");
            app.UseDefaultFiles(options);*/




            // если приложение в процессе разработки
            if (env.IsDevelopment())
            {
                // то выводим информацию об ошибке, при наличии ошибки
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                // установка обработчика ошибок
                app.UseExceptionHandler("/Home/Error");
            }



            // обработка запроса - получаем констекст запроса в виде объекта context
            /*int x = 348279;
            app.Use(async (context, next) =>
            {
                x = x * 74;
                await next.Invoke();

                x = x * 2;
                await context.Response.WriteAsync($"Result = {x}");
            });

            app.Run(async (context) =>
            {

                x = x * 4;
                // отправка ответа в виде строки "Hello World!"
                //await context.Response.WriteAsync("Hello World!");
                await Task.FromResult(0);
            });*/


            //маппинг предоставляет страничку по ссылке localhost:xxxx/Homey/boopex
            /*app.Map("/Homey", Homey =>
            {
                Homey.Map("/index", Index);
                Homey.Map("/boopex", Boopex);
            });*/

            /*app.MapWhen(context => {
                return context.Request.Query.ContainsKey("id") && context.Request.Query["id"] == "5";
                }, DealWithIt);*/
                
          
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseMiddleware<AuthenticationMiddleware>();
            app.UseMiddleware<RoutingMiddleware>();

            app.BoopTimer();
            app.BoopToken("1234");

            //так тоже можно.
            //TimeService ts = app.ApplicationServices.GetService<TimeService>();


            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("\n End of booping");
            });
        }


        private static void DealWithIt(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("id is equal to 5");
            });
        }

        private static void Index(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Index page");
            });
        }

        private static void Boopex(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Boop page");
            });
        }
    }
}
