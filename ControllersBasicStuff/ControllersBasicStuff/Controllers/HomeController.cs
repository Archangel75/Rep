using ControllersBasicStuff.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllersBasicStuff.Controllers
{
    public class HomeController : Controller
    {
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
            string file_type = "application/txt";
            string file_name = "About the program.txt";
            return File(file_path, file_type, file_name);
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