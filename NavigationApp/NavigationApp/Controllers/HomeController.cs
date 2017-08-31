using NavigationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace NavigationApp.Controllers
{
    public class HomeController : Controller
    {
        SoccerContext db = new SoccerContext();
        public ActionResult Index()
        {
            //обязательно нужен инклуд чтобы тим тоже можно было использовать в представлении.
            var players = db.Players.Include(p => p.Team);
            return View(players.ToList());
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