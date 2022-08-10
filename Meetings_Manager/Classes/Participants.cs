using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetings_Manager.Classes
{
    public class Participants
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public DateTime TimeWhenAdded { get; set; }

        //public Participants() { }


        public Participants(string name, string surname, DateTime timewhenAdded)
        {
            Name = name;
            Surname = surname;
            TimeWhenAdded = timewhenAdded;

        }
    }

 
}
