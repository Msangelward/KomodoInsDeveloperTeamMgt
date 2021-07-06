using DeveloperPOCOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamPOCOS
{
    public class DevTeam
    {
        public List<Developer> Developers { get; set; }
        public string TeamName { get; set; }

        public int TeamIDNumber { get; set; }

        public DevTeam() { }

        public DevTeam(List<Developer> developers, string teamName, int teamIDNumber)
        {
            Developers = developers;
            TeamName = teamName;
            TeamIDNumber = teamIDNumber;
        }

        //create lists of Team Members with Team Name, Team ID
        //Developer info to include FirstName, LastName, DeveloperID, PluralSight, TeamName
    }
}
