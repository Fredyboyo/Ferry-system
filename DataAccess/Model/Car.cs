using System.Collections.Generic;

namespace Model
{
    internal class Car
    {
        public int carID { get; set; }
        public virtual List<Passenger> passengers { get; set; }

        public Car()
        {
            passengers = new List<Passenger>();
        }

        public void AddPassenger(Passenger passenger)
        {
            passengers.Add(passenger);
        }
    }
}
