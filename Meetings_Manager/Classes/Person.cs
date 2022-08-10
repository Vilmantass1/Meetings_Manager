using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetings_Manager.Classes
{
    public class Person 
    {

        public Participants FullName { get; set; }

        public string Name
        {
            get
            {
                return FullName.Name;
            }
        }
        public string Surname
        {
            get
            {
                return FullName.Surname;
            }
        }

     

    }
}
