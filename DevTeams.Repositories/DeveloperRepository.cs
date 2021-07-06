using DeveloperPOCOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams.Repositories
{
    public class DeveloperRepository
    {
        //this is my fake database..
        private List<Developer> _listOfDevelopersDatabase = new List<Developer>();

        int _Count = 0;

        //Create
        public bool AddDeveloperToList(Developer Developer)
        {
            int DevCount = _listOfDevelopersDatabase.Count;

            if (Developer is null)
            {
                return false;
            }

            _Count++;
            Developer.DeveloperIDNumber = _Count;
            _listOfDevelopersDatabase.Add(Developer);

            return _listOfDevelopersDatabase.Count > DevCount;

        }

        

        //Read
        public List<Developer> GetDeveloperList()
        {
            return _listOfDevelopersDatabase;
        }

        //Update
        public bool UpdateExistingDeveloper(int originalDeveloperIDNumber, Developer newDeveloperIDNumber)
        {

            //find the Content
            Developer oldDeveloper = GetDeveloperByID(originalDeveloperIDNumber);


            //Update the content
            if (oldDeveloper != null)
            {
                oldDeveloper.FirstName = newDeveloperIDNumber.FirstName;
                oldDeveloper.LastName = newDeveloperIDNumber.LastName;
                oldDeveloper.DeveloperIDNumber = newDeveloperIDNumber.DeveloperIDNumber;
                oldDeveloper.PluralSight = newDeveloperIDNumber.PluralSight;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveDeveloperFromList(int developerIDNumber)
        {
            Developer developer = GetDeveloperByID(developerIDNumber);

            if (developer == null)
            {
                return false;
            }

            int initialCount = _listOfDevelopersDatabase.Count;
            _listOfDevelopersDatabase.Remove(developer);

            if (initialCount > _listOfDevelopersDatabase.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Helper method
        public Developer GetDeveloperByID(int developerIDNumber)
        {
            foreach (Developer developerID in _listOfDevelopersDatabase)
            {
                if (developerID.DeveloperIDNumber == developerIDNumber)
                {
                    return developerID;
                }
            }

            return null;
        }/*
        public void AddDeveloperToList(Developer newDeveloper)
        {
            throw new NotImplementedException();
        }

        public List<Developer> GetDeveloperList()
        {
            throw new NotImplementedException();
        }

        public Developer GetDeveloperByID(int input)
        {
            throw new NotImplementedException();
        }

        public bool UpdateExistingDeveloper(int v, Developer newDeveloper)
        {
            throw new NotImplementedException();
        }

        public bool RemoveDeveloperFromList(int input)
        {
            throw new NotImplementedException();
        }
      */
    }
}
