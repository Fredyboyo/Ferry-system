using System;
using System.Web.Mvc;
using BusinessLogic;
using DTO;
using System.Web.WebPages;
using WebPage.Models;
using BusinessLogic.BLL;
using System.Collections.Generic;
using System.Reflection;

namespace WebPage.Controllers
{
    public class HomeController : Controller
    {
        // ------------------------------------------------------------------------ GET

        [HttpGet]
        public ActionResult Index()
        {
            IndexModel model = new IndexModel(BLL.GetFerries());
            return View("Index", model);
        }

        [HttpGet]
        public ActionResult EditFerry(int ferryID)
        {
            FerryModel model = new FerryModel(BLL.GetFerryByID(ferryID));
            return View("Ferry", model);
        }

        // ------------------------------------------------------------------------ ADD

        [HttpPost]
        public ActionResult AddFerry(string ferryName)
        {
            if (!ferryName.IsEmpty())
            {
                BLL.AddFerry(new Ferry(ferryName));
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddCar(int ferryID)
        {
            Car car = new Car();
            BLL.AddCar(car, ferryID);
            return RedirectToAction("EditFerry", new { ferryID });
        }

        [HttpPost]
        public ActionResult AddPassenger(int ferryID, Passenger newPassenger, string carID)
        {
            if (!newPassenger.name.IsEmpty())
            {
                BLL.AddPassenger(newPassenger, ferryID, int.Parse(carID));
            }
            return RedirectToAction("EditFerry", new { ferryID });
        }

        // ------------------------------------------------------------------------ UPDATE

        [HttpPost]
        public ActionResult UpdateFerry(int ferryID, string name)
        {
            Ferry ferry = new Ferry(ferryID, name);
            if (!name.IsEmpty())
            {
                BLL.UpdateFerry(ferry);
            }
            return RedirectToAction("EditFerry", new { ferryID });
        }

        [HttpPost]
        public ActionResult UpdatePassenger(int ferryID, int passengerID, string name, string sex, string carID)
        {
            Passenger passenger = new Passenger(passengerID, name, (Sex)Enum.Parse(typeof(Sex), sex));
            if (!name.IsEmpty())
            {
                BLL.UpdatePassenger(passenger, int.Parse(carID));
            }
            return RedirectToAction("EditFerry", new { ferryID });
        }

        [HttpPost]
        public ActionResult UpdateCar(int ferryID, string carID)
        {
            Car car = new Car(int.Parse(carID));
            BLL.UpdateCar(car);
            return RedirectToAction("EditFerry", new { ferryID });
        }

        // ------------------------------------------------------------------------ DELETE

        [HttpPost]
        public ActionResult DeleteFerry(int ferryID)
        {
            BLL.DeleteFerry(ferryID);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteCar(int ferryID, int carID)
        {
            BLL.DeleteCar(carID);
            return RedirectToAction("EditFerry", new { ferryID });
        }

        [HttpPost]
        public ActionResult DeletePassenger(int ferryID, int passengerID)
        {
            BLL.DeletePassenger(passengerID);
            return RedirectToAction("EditFerry", new { ferryID });
        }
    }
}