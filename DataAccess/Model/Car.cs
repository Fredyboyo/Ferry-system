using System;
using System.Collections.Generic;

namespace Model
{
    internal class Car
    {
        public int carID { get; set; }
        public virtual HashSet<Passenger> passengers { get; set; }

        public Car()
        {
            passengers = new HashSet<Passenger>();
        }
        public Car(int carID, HashSet<Passenger> passengers)
        {
            this.carID = carID;
            this.passengers = passengers;
        }

        /// <summary>
        /// Returns:
        ///     true if the element is added;
        ///     false if the element is already present.
        /// </summary>
        public bool AddPassenger(Passenger passenger)
        {
            return passengers.Add(passenger);
        }

        /// <summary>
        /// Returns:
        ///     true if the element is removed;
        ///     false if the element can't be found.
        /// </summary>
        internal bool RemovePassenger(Passenger passenger)
        {
            return passengers.Remove(passenger);
        }
    }
}
