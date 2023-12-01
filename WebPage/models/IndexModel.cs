using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebPage.Models
{
    public class IndexModel
    {
        public List<Ferry> ferries { get; set; }
        public List<List<SelectListItem>> selectionListCars { get; set; }
        public List<List<SelectListItem>> selectionListPassengers { get; set; }
        public IndexModel()
        {

        }
        public IndexModel(List<Ferry> ferries)
        {
            this.ferries = ferries;
            selectionListCars = new List<List<SelectListItem>>();
            selectionListPassengers = new List<List<SelectListItem>>();
            foreach (Ferry ferry in ferries)
            {
                List<SelectListItem> selectListCars = new List<SelectListItem>();
                foreach (Car car in ferry.cars)
                {
                    selectListCars.Add(new SelectListItem()
                    {
                        Text = car.carID + " | Passengers: " + car.passengers.Count
                    });
                }
                selectionListCars.Add(selectListCars);
                List<SelectListItem> selectListPassengers = new List<SelectListItem>();
                foreach (Passenger passenger in ferry.passengers)
                {
                    selectListPassengers.Add(new SelectListItem()
                    {
                        Text = passenger.passengerID + " | " + passenger.name + " " + passenger.sex
                    });
                }
                selectionListPassengers.Add(selectListPassengers);
            }
        }
    }
}
