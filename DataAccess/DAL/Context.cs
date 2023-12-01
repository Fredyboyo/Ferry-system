using Model;
using System.Data.Entity;

namespace DAL
{
    internal class Context : DbContext
    {
        public Context() : base("Ferries")
        {

        }

        public DbSet<Ferry> ferries { get; set; }
        public DbSet<Car> cars { get; set; }
        public DbSet<Passenger> passengers { get; set; }
    }
}
