using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Passenger
    {
        public int passengerID { get; set; }
        [Required]
        public string name { get; set; }
        public Sex sex { get; set; }
        public Passenger() {
            name = string.Empty;
            sex = Sex.Male;
        }
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
