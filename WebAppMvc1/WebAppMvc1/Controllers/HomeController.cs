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
            //ViewBag.Cars = carList;
            ViewBag.Message = "Частичное представление";

            return View(carList);
        }


        public ActionResult GetList()
        {
            string[] a = new string[] { "rus" , "swed", "nor", "can"};
            return PartialView("_GetList",a);
        }

        [HttpPost]
        //имя параметра совпадает с именем первого параметра хтмл хелпера html.textarea
        //public string GetForm(string text)
        public string GetForm(bool set)
        {
            return set.ToString();
        }

        public ActionResult CarIndex()
        {
            var carList = carDb.Cars;
            //ViewBag.Cars = carList;


            return View(carList);
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.CarId = id;
            return View();
        }


        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.DatePurchase = DateTime.Now;
            carDb.Purchases.Add(purchase);
            carDb.SaveChanges();
            return "Спасибо за покупку!";
        }
    }
}