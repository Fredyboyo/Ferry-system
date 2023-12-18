using System;
using System.Collections.Generic;

namespace Model
{
    internal class Ferry
    {
        public int ferryID { get; set; }
        public string name { get; set; }
        public virtual HashSet<Car> cars { get; set; }
        public virtual HashSet<Passenger> passengers { get; set; }
        public Ferry()
        {
            cars = new HashSet<Car>();
            passengers = new HashSet<Passenger>();
        }
        public Ferry(string name)
        {
            this.name = name;
            cars = new HashSet<Car>();
            passengers = new HashSet<Passenger>();
        }
        public Ferry(int ferryID, string name, HashSet<Car> cars, HashSet<Passenger> passengers)
        {
            this.ferryID = ferryID;
            this.name = name;
            this.cars = cars;
            this.passengers = passengers;
        }

        public void AddCar(Car car)
        {
            cars.Add(car);
            foreach(Passenger passenger in car.passengers)
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
