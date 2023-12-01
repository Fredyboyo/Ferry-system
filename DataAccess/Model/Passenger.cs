
namespace Model
{
    internal class Passenger
    {
        public int passengerID { get; set; }
        public string name { get; set; }
        public Sex sex { get; set; }
        public Passenger() { }
        public Passenger(string name, Sex sex)
        {
            this.name = name;
            this.sex = sex;
        }
        public Passenger(int passengerID, string name, Sex sex)
        {
            this.passengerID = passengerID;
            this.name = name;
            this.sex = sex;
        }

    }
}
