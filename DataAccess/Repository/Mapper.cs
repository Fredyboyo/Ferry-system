using DTO;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace Database
{
    internal static class Mapper
    {
        //----------------------------------------------------------------------------- MODEL -> DTO
        public static DTO.Ferry MapFerry(Model.Ferry ferry)
        {
            List<DTO.Car> DTOCars = new List<DTO.Car>();
            foreach (Model.Car car in ferry.cars)
            {
                DTOCars.Add(MapCar(car));
            }
            List<DTO.Passenger> DTOPassengers = new List<DTO.Passenger>();
            foreach (Model.Passenger passenger in ferry.passengers)
            {
                DTOPassengers.Add(MapPassenger(passenger));
            }

            return new DTO.Ferry(
                ferry.ferryID,
                ferry.name,
                DTOCars,
                DTOPassengers);
        }
        public static DTO.Car MapCar(Model.Car car)
        {
            List<DTO.Passenger> DTOPassengers = new List<DTO.Passenger>();
            foreach(Model.Passenger passenger in car.passengers) {
                DTOPassengers.Add(MapPassenger(passenger));
            }

            return new DTO.Car(
                car.carID,
                DTOPassengers);
        }
        public static DTO.Passenger MapPassenger(Model.Passenger passenger)
        {
            return new DTO.Passenger(
                passenger.passengerID,
                passenger.name,
                MapSex(passenger.sex));
        }
        public static DTO.Sex MapSex(Model.Sex sex)
        {
            switch (sex)
            {
                case Model.Sex.Nonbinary:
                    return DTO.Sex.Nonbinary;
                case Model.Sex.Female:
                    return DTO.Sex.Female;
                default:
                    return DTO.Sex.Male;
            }
        }
        //----------------------------------------------------------------------------- DTO -> MODEL
        public static Model.Ferry MapFerry(DTO.Ferry ferry)
        {
            HashSet<Model.Car> ModelCars = new HashSet<Model.Car>();
            foreach (DTO.Car car in ferry.cars)
            {
                ModelCars.Add(MapCar(car));
            }
            HashSet<Model.Passenger> ModelPassengers = new HashSet<Model.Passenger>();
            foreach (DTO.Passenger passenger in ferry.passengers)
            {
                ModelPassengers.Add(MapPassenger(passenger));
            }
            return new Model.Ferry(
                ferry.ferryID,
                ferry.name,
                ModelCars,
                ModelPassengers);
        }
        public static Model.Car MapCar(DTO.Car car)
        {
            HashSet<Model.Passenger> ModelPassengers = new HashSet<Model.Passenger>();
            foreach (DTO.Passenger passenger in car.passengers)
            {
                ModelPassengers.Add(MapPassenger(passenger));
            }
            return new Model.Car(
                car.carID,
                ModelPassengers);
        }
        public static Model.Passenger MapPassenger(DTO.Passenger passenger)
        {
            return new Model.Passenger(
                passenger.passengerID,
                passenger.name,
                MapSex(passenger.sex));
        }

        public static Model.Sex MapSex(DTO.Sex sex)
        {
            switch (sex)
            {
                case DTO.Sex.Nonbinary:
                    return Model.Sex.Nonbinary;
                case DTO.Sex.Female:
                    return Model.Sex.Female;
                default:
                    return Model.Sex.Male;
            }
        }
    }
}
