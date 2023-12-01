using Model;
using System.Collections.Generic;
using System.Data.Entity;

namespace DAL
{
    internal class Initializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            List<Ferry> ferries = new List<Ferry>()
            {
                new Ferry("Susane"),
                new Ferry("Olivia")
            };

            List<Car> cars = new List<Car>()
            {
                new Car(),
                new Car(),
                new Car(),
                new Car()
            };

            List<Passenger> passengers = new List<Passenger>
            {
                new Passenger("Laurids Tomson", Sex.male),
                new Passenger("Donny Tomson", Sex.male),
                new Passenger("Amy Tomson", Sex.female),
                new Passenger("Simon Jesper Williams", Sex.male),
                new Passenger("Rubert Ergo", Sex.male),
                new Passenger("Victor Gordon", Sex.male),
                new Passenger("Lucia Gordon", Sex.female),
                new Passenger("Micheal Shores", Sex.male),
                new Passenger("Elise Henricksen", Sex.female),
                new Passenger("Sofia Corner", Sex.female),
                new Passenger("Lukas Vincent", Sex.male),
                new Passenger("David Richard Noxon", Sex.female)
            };

            cars[0].AddPassenger(passengers[0]);
            cars[0].AddPassenger(passengers[1]);
            cars[0].AddPassenger(passengers[2]);

            cars[1].AddPassenger(passengers[5]);
            cars[1].AddPassenger(passengers[6]);

            cars[2].AddPassenger(passengers[3]);
            cars[2].AddPassenger(passengers[4]);

            cars[3].AddPassenger(passengers[8]);

            ferries[0].AddCar(cars[0]);
            ferries[0].AddCar(cars[1]);

            ferries[0].AddPassenger(passengers[7]);
            ferries[0].AddPassenger(passengers[9]);

            ferries[1].AddCar(cars[2]);
            ferries[1].AddCar(cars[3]);

            ferries[1].AddPassenger(passengers[10]);
            ferries[1].AddPassenger(passengers[11]);

            context.ferries.AddRange(ferries);
            context.cars.AddRange(cars);
            context.passengers.AddRange(passengers);

            context.SaveChanges();
            base.Seed(context);
        }

        private void dummy()
        {
            string result = System.Data.Entity.SqlServer.SqlFunctions.Char(65);
        }
    }
}
