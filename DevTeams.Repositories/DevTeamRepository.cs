using DevTeamPOCOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams.Repositories
{
    public class DevTeamRepository
    {
        //1. Create the fake database
        private readonly List<DevTeam> _devTeamRepository = new List<DevTeam>();

        //2.  Make Int Value to increment DevTeamID
        private int _count = 0;

        //3.   Create add-Method (C)

        public bool AddTeam(DevTeam devTeam)
        {
            if (devTeam is null)
            {
                return false;
            }

            //increment _count
            _count++;

            //assign _count to devTeam.TeamID
            devTeam.TeamID = _count;

            //add devTeam to the database
            _devTeamRepository.Add(devTeam);

            //we can just return true
            return true;
        }

        //4.  Get all the DevTeams w/in the database and store them as a collection
        public IEnumerable<DevTeam> GetDevTeams()
        {
            return _devTeamRepository;

        }

        //5.  Get a single DevTeam
        public DevTeam GetDevTeamByID(int id)
        {
            //loop thru teams in the database
            foreach (var team in _devTeamRepository)
            {
                //if team in database has same ID number that the user lists
                if (team.TeamID == id)
                {
                    //return that specific team
                    return team;
                }
            }
            //else return nothing
            return null;
        }

        //6.  Update a team
        public bool UpdateTeam(int id, DevTeam newDevTeamData)
        {
            //get a specific team
            DevTeam team = GetDevTeamByID(id);

            if (team == null)
            {
                return false;
            }

            team.TeamID = id;
            team.TeamName = newDevTeamData.TeamName;
            team.Developers = newDevTeamData.Developers;

            return true;
        }

        //7. Delete Team
        public bool DeleteTeam(int id)
        {
            foreach (var team in _devTeamRepository)
            {
                if (team.TeamID == id)
                {
                    _devTeamRepository.Remove(team);
                    return true;
                }
            }

            return false;
        }
    }
}
