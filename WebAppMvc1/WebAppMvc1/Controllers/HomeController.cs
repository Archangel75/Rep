using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppMvc1.Models;

namespace WebAppMvc1.Controllers
{
    public class HomeController : Controller
    {
        CarContext carDb = new CarContext();

        public ActionResult Index()
        {
            var carList = carDb.Cars;
            ViewBag.Cars = carList;

            return View();
        }

    }
}