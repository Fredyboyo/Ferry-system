using DTO;

namespace Database
{
    internal static class Mapper
    {
        public static Ferry MapFerry(Model.Ferry ferry)
        {
            return new Ferry(ferry.ferryID, ferry.name, ferry.cars.ConvertAll(c => MapCar(c)), ferry.passengers.ConvertAll(p => MapPassenger(p)));
        }
        public static Car MapCar(Model.Car car)
        {
            return new Car(car.carID, car.passengers.ConvertAll(p => MapPassenger(p)));
        }
        public static Passenger MapPassenger(Model.Passenger passenger)
        {
            return new Passenger(passenger.passengerID, passenger.name, MapSex(passenger.sex));
        }
        public static Sex MapSex(Model.Sex sex)
        {
            switch(sex)
            {
                case Model.Sex.nonbinary:
                    return Sex.Nonbinary;
                case Model.Sex.female:
                    return Sex.Female;
                default:
                    return Sex.Male;
            }
        }
    }
}
