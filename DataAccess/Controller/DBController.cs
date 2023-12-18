using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using DAL;

namespace Database
{
    public static class DBController
    {
        public static List<DTO.Ferry> GetFerries()
        {
            using (Context context = new Context())
            {
                List<Ferry> ffs = context.ferries.Include("passengers").Include("cars").ToList();

                List<DTO.Ferry> fs = ffs.ConvertAll(f => Mapper.MapFerry(f));
                foreach (DTO.Ferry ferry in fs)
                {
                    Console.WriteLine(ferry.name);
                    foreach (DTO.Passenger passenger in ferry.passengers)
                    {
                        Console.WriteLine(passenger.name);
                    }
                }
                return fs;
            } 
        }
        public static List<DTO.Car> GetCars()
        {
            using (Context context = new Context())
            {
                return context.cars.ToList().ConvertAll(c => Mapper.MapCar(c));
            }
        }
        public static List<DTO.Passenger> GetPassegers()
        {
            using (Context context = new Context())
            {
                return context.passengers.ToList().ConvertAll(p => Mapper.MapPassenger(p));
            }
        }
        //-----------------------------------------------------------------------------
        public static List<DTO.Passenger> GetPassengersByIds(List<int> ids)
        {
            using (Context context = new Context())
            {
                return context.passengers.Where(p => ids.Contains(p.passengerID)).ToList().ConvertAll(p => Mapper.MapPassenger(p));
            }
        }
    }
}
