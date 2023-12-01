using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class Ferry
    {
        public int ferryID { get; set; }
        [Required]
        public string name { get; set; }
        public virtual List<Car> cars { get; set; }
        public virtual List<Passenger> passengers { get; set; }
        public Ferry()
        {
            cars = new List<Car>();
            passengers = new List<Passenger>();
        }
        public Ferry(string name)
        {
            this.name = name;
            cars = new List<Car>();
            passengers = new List<Passenger>();
        }
        public Ferry(int ferryID, string name)
        {
            this.ferryID = ferryID;
            this.name = name;
            cars = new List<Car>();
            passengers = new List<Passenger>();
        }
        public Ferry(int ferryID, string name, List<Car> cars, List<Passenger> passengers)
        {
            this.ferryID = ferryID;
            this.name = name;
            this.cars = cars;
            this.passengers = passengers;
        }

        public void AddCar(Car car)
        {
            cars.Add(car);
            foreach (Passenger passenger in car.passengers)
            {
                passengers.Add(passenger);
            }
        }
        public void RemoveCar(Car car)
        {
            cars.Remove(car);
            foreach (Passenger passenger in car.passengers)
            {
                passengers.Remove(passenger);
            }
        }
        public void AddPassenger(Passenger passenger)
        {
            passengers.Add(passenger);
        }
        public void RemovePassenger(Passenger passenger)
        {
            passengers.Remove(passenger);
        }
    }
}
