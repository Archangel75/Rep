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
        //если объявлена глобальная переменная базы данных, то её надо чистить(dispose см снизу.)
        CarContext carDb = new CarContext();

        public ActionResult Index()
        {
            //лучше делать так:
            
            using (CarContext carDb2 = new CarContext())
            {
                var carList = carDb.Cars;
                return View(carList);
            }
                       
            
        }

        public ActionResult GetCar(int id)
        {
            Car c = carDb.Cars.Find(id);
            if (c == null)
                return HttpNotFound();
            return View(c);
        }

        //Создание машины
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Car car)
        {
            carDb.Cars.Add(car);
            carDb.SaveChanges();
            return RedirectToAction("Index");
        }

        #region Чтобы не попасться на удочку мошенников и троллей нужно сделать delete по другому.

        //public ActionResult Delete(int id)
        //{
        //    //это не очень круто потому что 2 запроса в базу.
        //    //Car c = carDb.Cars.Find(id);
        //    //if (c != null)
        //    //{
        //    //    carDb.Cars.Remove(c);
        //    //    carDb.SaveChanges();
        //    //}
        //    //-------------------

        //    Car c = new Car { id = id };
        //    carDb.Entry(c).State = System.Data.Entity.EntityState.Deleted;
        //    carDb.SaveChanges();
        //    return RedirectToAction("Index");
        //}
#endregion

        [HttpGet]
       public ActionResult Delete(int id)
       {
            Car c = carDb.Cars.Find(id);
            if (c == null)
            {
                return HttpNotFound();
            }
            return View(c);            
        }
        [HttpPost,ActionName("Delete")]
       public ActionResult DeleteConfirmed(int id)
        {
            Car c = carDb.Cars.Find(id);
            if (c == null)
            {
                return HttpNotFound();
            }
            carDb.Cars.Remove(c);
            carDb.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Car car = carDb.Cars.Find(id);
            if (car != null)
            {
                return View(car);
            }
            return HttpNotFound();
        }


        [HttpPost]
        public ActionResult Edit(Car car)
        {
            carDb.Entry(car).State = System.Data.Entity.EntityState.Modified;
            carDb.SaveChanges();
            return RedirectToAction("Index");
        }




        public ActionResult GetList()
        {
            string[] a = new string[] { "rus" , "swed", "nor", "can"};
            return PartialView("_GetList",a);
        }

        [HttpPost]
        //имя параметра совпадает с именем первого параметра хтмл хелпера html.textarea
        //public string GetForm(string text)
        //public string GetForm(bool set)
        public string GetForm(string[] countries)
        {
            string result = "";
            foreach (string a in countries)
            {
                result += a;
                result += ";";
            }

            return "Вы выбрали :" + result;
            //return set.ToString();
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
            return View(new Purchase { CarId = id, FIO = "Анонимус" });
        }


        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.DatePurchase = DateTime.Now;
            carDb.Purchases.Add(purchase);
            carDb.SaveChanges();
            return "Спасибо за покупку!";
        }

        protected override void Dispose(bool disposing)
        {
            carDb.Dispose();
            base.Dispose(disposing);
        }
    }
}