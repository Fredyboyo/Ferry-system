using System;
using System.Collections.Generic;

namespace DTO
{
    public class Car
    {
        public int carID { get; set; }
        public virtual List<Passenger> passengers { get; set; }
        public Car()
        {
            passengers = new List<Passenger>();
        }
        public Car(int carID)
        {
            this.carID = carID;
            passengers = new List<Passenger>();
        }
        public Car(int carID, List<Passenger> passengers)
        {
            this.carID = carID;
            this.passengers = passengers;
        }
        public void AddPassenger(Passenger passenger)
        {
            passengers.Add(passenger);
        }
    }
}
