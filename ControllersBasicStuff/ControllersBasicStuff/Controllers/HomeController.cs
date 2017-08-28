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
            ViewData["Head"] = "Привет мир!";
            ViewBag.Head = "Дратути";

            ViewBag.Fruit = new List<string>
            {
                "олени","бараны","козлы"
            };
            return View();
        }

        public ActionResult GetImage()
        {
            string path = "../Content/Images/yz9uxVlpO0U.jpg";
            return new ImageResult(path);
        }



        public ActionResult GetHtml()
        {
            return new HtmlResult("<h2>Дратути</h2>");
        }

        
        public ActionResult GetVoid()
        {
            try
            {
                //переадресация на метод контакт
                //return Redirect("/Home/Contact");'
                //если в запросе не будет '?id=...' то тут будет ошибка.
                if (Int32.Parse(Request.Params["id"]) > 3)
                {
                    //return RedirectToRoute(new { controller = "Home", action = "Contact" });
                    //return RedirectToAction("Contact"); если метод в другом контроллере, то нужно указывать контроллер вторым параметром.
                    //метод, контроллер, объект с хранимыми параметрами.
                    return RedirectToAction("Square", "Home", new { a = 10, b = 12 });
                }
                return View("About");
            }
            catch
            {
                //return new HttpStatusCodeResult(404);
                //return new HttpUnauthorizedResult();
                return new HttpNotFoundResult();
            }
            
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

        public ImageResult Contact()
        {
            //ViewBag.Message = "Your contact page.";
            string path = "../Content/Images/yz9uxVlpO0U.jpg";
            return new ImageResult(path);
        }
    }
}