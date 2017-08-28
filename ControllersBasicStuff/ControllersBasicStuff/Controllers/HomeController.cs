using ControllersBasicStuff.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllersBasicStuff.Controllers
{
    public class HomeController : Controller
    {

        public string GetContext()
        {
            string browser = HttpContext.Request.Browser.Browser;
            string user_agent = HttpContext.Request.UserAgent;
            string url = HttpContext.Request.RawUrl;
            string ip = HttpContext.Request.UserHostAddress;
            string referrer = HttpContext.Request.UrlReferrer == null ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri;
            return @"<p>Browser: " + browser + " </p> /n <p>User-agent: " + user_agent + " </p> /n <p>Url: " + url + " </p> /n <p>Refferer: " + referrer
                    + " </p> /n <p>Ipaddress: " + ip + " </p> /n ";
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetImage()
        {
            string path = "../Content/Images/yz9uxVlpO0U.jpg";
            return new ImageResult(path);
        }


        public FilePathResult GetFile()
        {
            string file_path = Server.MapPath("~/Files/About the program.txt");

            //string filep = "E:/Repository/Files/Boop.pdf"; так тоже можно.
            //string file_type = "application/txt";
            //для всех типов.
            string file_type = "application/octet-stream";
            string file_name = "About the program.txt";
            return File(file_path, file_type, file_name);
        }

        public FileContentResult GetBytes()
        {
            string file_path = Server.MapPath("~/Files/About the program.txt");
            byte[] mas = System.IO.File.ReadAllBytes(file_path);
            string file_type = "application/txt";
            string file_name = "About the program.txt";
            return File(mas, file_type, file_name);
        }

        public FileStreamResult GetStream()
        {
            string file_path = Server.MapPath("~/Files/About the program.txt");
            FileStream fs = new FileStream(file_path, FileMode.Open);
            string file_type = "application/txt";
            string file_name = "About the program.txt";
            return File(fs, file_type, file_name);
        }

        public ActionResult GetHtml()
        {
            return new HtmlResult("<h2>Дратути</h2>");
        }



        public string GetId(int id)
        {

            return id.ToString();
        }


        [HttpGet]        
        public ActionResult GetCar()
        {
            return View();
        }

        [HttpPost]
        public string PostCar()
        {
            string title = Request.Form["title"];
            string model= Request.Form["model"];
            return title + " " + model;
        }

        public string Square()
        {
            int a = Int32.Parse(Request.Params["a"]);
            int b = Int32.Parse(Request.Params["b"]);
            return "Площадь треугольника = " + (a*b/2).ToString();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}