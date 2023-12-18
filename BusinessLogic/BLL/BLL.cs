using DTO;
using Database;
using System.Collections.Generic;
using System;

namespace BusinessLogic.BLL
{
    public static class BLL
    {
        // ----------------------------------- GET
        public static List<Ferry> GetFerries()
        {
            return Repository.GetFerries();
        }
        public static Ferry GetFerryByID(int id)
        {
            return Repository.GetFerryByID(id);
        }
        // ----------------------------------- ADD
        public static void AddFerry(Ferry ferry)
        {
            Repository.AddFerry(ferry);
        }
        public static void AddCar(Car car, int ferryID)
        {
            Repository.AddCar(car, ferryID);
        }
        public static void AddPassenger(Passenger newPassenger, int ferryID, int carID)
        {
            Repository.AddPassenger(newPassenger, ferryID, carID);
        }
        // ----------------------------------- UPDATE
        public static void UpdateFerry(Ferry ferry)
        {
            Repository.UpdateFerry(ferry);
        }
        public static void UpdatePassenger(Passenger passenger, int carID)
        {
            Repository.UpdatePassenger(passenger, carID);
        }
        public static void UpdateCar(Car car)
        {
            throw new NotImplementedException();
        }
        // ----------------------------------- DELETE
        public static void DeleteFerry(int ferryID)
        {
            Repository.DeleteFerry(ferryID);
        }
        public static void DeleteCar(int carID)
        {
            Repository.DeleteCar(carID);
        }
        public static void DeletePassenger(int passengerID)
        {
            Repository.DeletePassenger(passengerID);
        }
    }
}
