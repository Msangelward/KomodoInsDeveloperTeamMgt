using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPOCOS
{ 
    public class Developer
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int DeveloperIDNumber { get; set; }

        public bool PluralSight { get; set; }

        public Developer() { }

        public Developer(string firstName, string lastName, int developerIDNumber, bool pluralSight)
        {
            FirstName = firstName;
            LastName = lastName;
            DeveloperIDNumber = developerIDNumber;
            PluralSight = pluralSight;
            
        }
    }
}
