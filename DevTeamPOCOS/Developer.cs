using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPOCOS
{ 
    public class Developer
    {
        private string v1;
        private string v2;
        private bool v3;

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

        public Developer(string v1, string v2, bool v3)
        {
            this.FirstName = v1;
            this.LastName = v2;
            this.PluralSight = v3;
        }
    }
}
