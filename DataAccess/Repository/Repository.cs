using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using DAL;
using DTO;
using Model;

namespace Database
{
    public static class Repository
    {
        //----------------------------------------------------------------------------- GET
        public static List<DTO.Ferry> GetFerries()
        {
            using (Context context = new Context())
            {
                return context.ferries
                    .Include("passengers")
                    .Include("cars")
                    .ToList().ConvertAll(f => Mapper.MapFerry(f));
            }
        }
        public static DTO.Ferry GetFerryByID(int ferryID)
        {
            using (Context context = new Context())
            {
                return Mapper.MapFerry(context.ferries
                    .Include("passengers")
                    .Include("cars")
                    .SingleOrDefault(x => x.ferryID == ferryID));
            }
        }
        //----------------------------------------------------------------------------- ADD
        public static void AddFerry(DTO.Ferry DTOFerry)
        {
            using (Context context = new Context())
            {
                context.ferries.Add(Mapper.MapFerry(DTOFerry));
                context.SaveChanges();
            }
        }

        public static void AddCar(DTO.Car DTOCar, int ferryID)
        {
            using (Context context = new Context())
            {
                Model.Car car = Mapper.MapCar(DTOCar);
                context.ferries.Find(ferryID).AddCar(car);
                context.cars.Add(car);
                context.SaveChanges();
            }
        }
        public static void AddPassenger(DTO.Passenger DTOPassenger, int ferryID, int carID)
        {
            using (Context context = new Context())
            {
                Model.Passenger passenger = Mapper.MapPassenger(DTOPassenger);

                context.ferries.Find(ferryID).AddPassenger(passenger);
                if (carID > 0)
                {
                    context.cars.Find(carID).AddPassenger(passenger);
                }
                context.passengers.Add(passenger);
                context.SaveChanges();
            }
        }
        //----------------------------------------------------------------------------- UPDATE
        public static void UpdateFerry(DTO.Ferry DTOferry)
        {
            using (Context context = new Context())
            {
                Model.Ferry ferry = Mapper.MapFerry(DTOferry);

                Model.Ferry DBFerry = context.ferries.Find(ferry.ferryID);
                DBFerry.name = ferry.name;
                context.SaveChanges();
            }
        }

        public static void UpdatePassenger(DTO.Passenger DTOPassenger, int carID)
        {
            using (Context context = new Context())
            {
                Model.Passenger passenger = Mapper.MapPassenger(DTOPassenger);

                Model.Passenger DBPassenger = context.passengers.Find(passenger.passengerID);
                DBPassenger.name = passenger.name;
                DBPassenger.sex = passenger.sex;

                Model.Car car = context.cars.Find(carID);
                if (car != null)
                {
                    bool hasMoved = true;
                    foreach (Model.Passenger p in car.passengers)
                    {
                        if (p.passengerID == DBPassenger.passengerID)
                        {
                            hasMoved = false;
                            break;
                        }
                    }
                    if (hasMoved)
                    {
                        Model.Car oldCar = context.cars.SingleOrDefault(c => c.passengers.Any(p => p.passengerID == DBPassenger.passengerID));
                        if (oldCar != null)
                        {
                            oldCar.RemovePassenger(DBPassenger);
                        }
                        car.AddPassenger(DBPassenger);
                    }
                } else
                {
                    Model.Car oldCar = context.cars.SingleOrDefault(c => c.passengers.Any(p => p.passengerID == DBPassenger.passengerID));
                    if (oldCar != null)
                    {
                        oldCar.RemovePassenger(DBPassenger);
                    }
                }
                context.SaveChanges();
            }
        }
        //----------------------------------------------------------------------------- DELETE
        public static void DeleteFerry(int ferryID)
        {
            using (Context context = new Context())
            {
                Model.Ferry ferry = context.ferries
                    .Include("passengers")
                    .Include("cars")
                    .SingleOrDefault(f => f.ferryID == ferryID);
                context.passengers.RemoveRange(ferry.passengers);
                context.cars.RemoveRange(ferry.cars);
                context.ferries.Remove(ferry);
                context.SaveChanges();
            }
        }
        public static void DeleteCar(int carID)
        {
            using (Context context = new Context())
            {
                Model.Car car = context.cars
                    .Include("passengers")
                    .SingleOrDefault(c => c.carID == carID);
                car.passengers.Clear();
                context.cars.Remove(car);
                context.SaveChanges();
            } 
        }
        public static void DeletePassenger(int passengerID)
        {
            using (Context context = new Context())
            {
                context.passengers.Remove(context.passengers.Find(passengerID));
                context.SaveChanges();
            }
        }
    }
}
