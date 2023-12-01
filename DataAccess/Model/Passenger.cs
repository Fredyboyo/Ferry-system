
namespace Model
{
    internal class Passenger
    {
        public Passenger() { }
        public Passenger(string name, Sex sex)
        {
            this.name = name;
            this.sex = sex;
        }

        public int passengerID { get; set; }
        public string name { get; set; }
        public Sex sex { get; set; }
    }
}
