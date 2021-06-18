using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamPOCOS
{
    class DevTeamRepo
    {
        private List<DevTeamPOCOS.DevTeam> _listOfTeamDevelopers = new List<DevTeamPOCOS.DevTeam>();

        //Create
        public void AddTeamMemberToList(DevTeamPOCOS.DevTeamRepo Developers)
        {
            _listOfTeamDevelopers.Add(Developers);
        }

        //Read
        public List<DevTeamPOCOS.DevTeam> GetTeamDeveloperList()
        {
            return _listOfTeamDevelopers;
        }

        //Update
        public void AddTeamMemberToList(DevTeamPOCOS.DevTeamRepo Developers)
        {
            _listOfTeamDevelopers.Add(Developers);
        }

        //Delete
        public bool RemoveDeveloperFromList(int developerIDNumber)
        {
            DeveloperPOCOS.Developer developer = GetDeveloperByID(developerIDNumber);

            if (developer == null)
            {
                return false;
            }

            int initialCount = _listOfDevelopers.Count;
            _listOfDevelopers.Remove(developer);

            if (initialCount > _listOfDevelopers.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

            //Helper method

        }
}
