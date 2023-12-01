using System;
using System.Collections.Generic;

namespace Model
{
    internal class Ferry
    {
        public int ferryID { get; set; }
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

        public void AddCar(Car car)
        {
            cars.Add(car);
            passengers.AddRange(car.passengers);
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
