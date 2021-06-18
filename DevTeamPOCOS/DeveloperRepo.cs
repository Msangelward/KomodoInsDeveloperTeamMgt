using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamPOCOS
{
    public class DeveloperRepo
    {
        private List<DeveloperPOCOS.Developer> _listOfDevelopers = new List<DeveloperPOCOS.Developer>();

        //Create
        public void AddDeveloperToList(DeveloperPOCOS.Developer Developer)
        {
            _listOfDevelopers.Add(Developer);
        }

        //Read
        public List<DeveloperPOCOS.Developer> GetDeveloperList()
        {
            return _listOfDevelopers;
        }

        //Update
        public bool UpdateExistingDeveloper(int originalDeveloperIDNumber, DeveloperPOCOS.Developer newDeveloperIDNumber)
        {

            //find the Content
            DeveloperPOCOS.Developer oldDeveloper = GetDeveloperByID(originalDeveloperIDNumber);


            //Update the content
            if(oldDeveloper != null)
            {
                oldDeveloper.FirstName = newDeveloperIDNumber.FirstName;
                oldDeveloper.LastName = newDeveloperIDNumber.LastName;
                oldDeveloper.DeveloperIDNumber = newDeveloperIDNumber.DeveloperIDNumber;
                oldDeveloper.PluralSight = newDeveloperIDNumber.PluralSight;
                oldDeveloper.TeamName = newDeveloperIDNumber.TeamName;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveDeveloperFromList (int developerIDNumber)
        {
            DeveloperPOCOS.Developer developer = GetDeveloperByID(developerIDNumber);

            if(developer == null)
            {
                return false;
            }

            int initialCount = _listOfDevelopers.Count;
            _listOfDevelopers.Remove(developer);

            if(initialCount > _listOfDevelopers.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Helper method
        public DeveloperPOCOS.Developer GetDeveloperByID(int developerIDNumber)
        {
            foreach(DeveloperPOCOS.Developer developerID in _listOfDevelopers)
            {
                if(developerID.DeveloperIDNumber == developerIDNumber)
                {
                    return developerID;
                }
            }

            return null;
        }
    }
}
