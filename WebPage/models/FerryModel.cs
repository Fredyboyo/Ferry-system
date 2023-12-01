using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web.Mvc;

namespace WebPage.Models
{
    public class FerryModel
    {
        public Ferry ferry { get; }
        public Passenger newPassenger { get; }
        public Car newCar { get; }
        public List<List<SelectListItem>> passengerSexs { get; }
        public List<List<SelectListItem>> passengerCarIDs { get; }
        public List<SelectListItem> newPassengerCarID { get; }
        public FerryModel()
        {

        }
        public FerryModel(Ferry ferry)
        {
            this.ferry = ferry;
            this.newPassenger = new Passenger();
            this.newCar = new Car();
            passengerSexs = new List<List<SelectListItem>>();
            passengerCarIDs = new List<List<SelectListItem>>();

            newPassengerCarID = new List<SelectListItem>()
                {
                    new SelectListItem()
                    {
                        Value = "0",
                        Text = "None"
                    }
                };
            foreach (Car car in ferry.cars)
            {
                newPassengerCarID.Add(new SelectListItem()
                {
                    Value = "" + car.carID,
                    Text = "" + car.carID
                });
            }

            foreach (Passenger passengerInFerry in ferry.passengers)
            {
                List<SelectListItem> passengerCarID = new List<SelectListItem>()
                {
                    new SelectListItem()
                    {
                        Value = "0",
                        Text = "None"
                    }
                };
                foreach (Car car in ferry.cars)
                {
                    passengerCarID.Add(new SelectListItem()
                    {
                        Value = "" + car.carID,
                        Text = "" + car.carID,
                        Selected = car.passengers.Any(p => p.passengerID == passengerInFerry.passengerID)
                    });
                }
                passengerCarIDs.Add(passengerCarID);
                List<SelectListItem> passengerSex = new List<SelectListItem>();
                foreach (Sex sex in Enum.GetValues(typeof(Sex)))
                {
                    passengerSex.Add(new SelectListItem()
                    {
                        Value = "" + sex,
                        Text = "" + sex,
                        Selected = passengerInFerry.sex == sex
                    });
                }
                passengerSexs.Add(passengerSex);
            }
        }
    }
}
