using DeveloperPOCOS;
using DevTeamPOCOS;
using DevTeams.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsDeveloperTeamMgt
{
    class ProgramUI
    {
        public DeveloperRepository _developerRepo = new DeveloperRepository();
        public string pluralSightAsString;
        public object newDeveloper;
        public object _devTeamRepo;
        private object _devRepo;

        //Method that runs/starts the application
        public void Run()
        {
            Menu();
        }

        //Menu
        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                //Display our options to the user
                Console.WriteLine("Select a menu option:\n" +
                    "-------------Developer Menu----------------\n\n" +
                    "1. Create New Developer\n" +
                    "2. View List of Developers\n" +
                    "3. View Developer by Developer ID Number\n" +
                    "4. Update Existing Developer information\n" +
                    "5. Remove Existing Developer\n" +
                    "-------------Dev Team Menu-----------------\n\n" +
                    "6. Create Team\n" +
                    "7. View All Teams\n" +
                    "8. View Single Team\n" +
                    "9. Update Existing Team\n" +
                    "10. Delete Exiting Team\n" +
                    "11. Exit");

                //Get the user's input
                string input = Console.ReadLine();

                //Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        //Create new Developer
                        CreateNewDeveloper();
                        break;
                    case "2":
                        //View List of Developers by Team Name
                        DisplayListOfDevelopers();
                        break;
                    case "3":
                        //View List of Developers by Developer IDNumber
                        DisplayDeveloperByDeveloperIDNumber();
                        break;
                    case "4":
                        //Update Existing Developer information
                        UpdateExistingDeveloper();
                        break;
                    case "5":
                        //Remove Existing Developer
                        DeleteExistingDeveloper();
                        break;
                    case "6":
                        //Create new Team
                        CreateTeam();
                        break;
                    case "7":
                        //View All Teams
                        ViewAllTeams();
                        break;
                    case "8":
                        //View Single Team
                        ViewSingleTeam();
                        break;
                    case "9":
                        //Update Existing Team
                        UpdateExistingTeam();
                        break;
                    case "10":
                        //Remove Existing Team
                        DeleteExistingTeam();
                        break;
                    case "11":
                        //Exit
                        Console.WriteLine("Goodbye.");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Please press any key to continue...:");
                Console.ReadKey();
                Console.Clear();
            }
        }
        
        //Create New Developer
        public void CreateNewDeveloper()
        {
            Console.Clear();
            DeveloperPOCOS.Developer newDeveloper = new DeveloperPOCOS.Developer();

            Console.WriteLine("Enter First Name:");
            newDeveloper.FirstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name:");
            newDeveloper.LastName = Console.ReadLine();

            Console.WriteLine("Do you have access to Pluralsight? y/n");
            string pluralSightAsString = Console.ReadLine().ToLower();

            if(pluralSightAsString == "y")
            {
                newDeveloper.PluralSight = true;
            }
            else
            {
                newDeveloper.PluralSight = false;
            }

            _developerRepo.AddDeveloperToList(newDeveloper);

        }

        //View Current List of Developers
        public void DisplayListOfDevelopers()
        {
            List<DeveloperPOCOS.Developer> listOfDevelopers = _developerRepo.GetDeveloperList();

            foreach (DeveloperPOCOS.Developer developer in listOfDevelopers)
            {
                Console.WriteLine($"Name: {developer.FirstName} {developer.LastName}\n" +
                    $"Developer ID Number {developer.DeveloperIDNumber}\n" +
                    $"PluralSight: {developer.PluralSight}\n");
                if (pluralSightAsString == "y")
                {
                    developer.PluralSight = true;
                }
                else
                {
                    developer.PluralSight = false;
                }
            }
        }

        //View Existing Developers by Developer ID Number
        public void DisplayDeveloperByDeveloperIDNumber()
        {
            Console.Clear();
            //Prompt User for Developer ID
            Console.WriteLine("\nEnter the Developer's ID Number.");
            int input = int.Parse(Console.ReadLine());

            //Find the Developer that has that IDNumber
            DeveloperPOCOS.Developer developerIDNumber = _developerRepo.GetDeveloperByID(input);

            //Display Said Developer if it isn't null
            if(developerIDNumber != null)
            {
                Console.WriteLine($"Name: {developerIDNumber.FirstName} {developerIDNumber.LastName}\n" +
                    $"Developer ID Number {developerIDNumber.DeveloperIDNumber}\n" +
                    $"PluralSight: {developerIDNumber.PluralSight}\n");
            }
            else
            {
                Console.WriteLine("No Developer by that ID Number Found.");
            }
        }

        //Update Existing Developer
        public void UpdateExistingDeveloper()
        {
            // Display all content
            DisplayDeveloperByDeveloperIDNumber();

            // Ask for Developer they want to update via IDNumber
            Console.WriteLine("Enter ID Number of Developer you'd like to update.");

            // Get that Developer
            string oldDeveloper = Console.ReadLine();

            // We will build a new developer
            DeveloperPOCOS.Developer newDeveloper = new DeveloperPOCOS.Developer();

            Console.WriteLine("Enter First Name:");
            newDeveloper.FirstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name:");
            newDeveloper.LastName = Console.ReadLine();

            Console.WriteLine("Enter Developer's ID Nmber:");
            string devIDAsString = Console.ReadLine();
            newDeveloper.DeveloperIDNumber = int.Parse(devIDAsString);

            Console.WriteLine("Do you have access to Pluralsight? y/n");
            string pluralSightAsString = Console.ReadLine().ToLower();

            if (pluralSightAsString == "y")
            {
                newDeveloper.PluralSight = true;
            }
            else
            {
                newDeveloper.PluralSight = false;
            }

            //Verify the update worked
            bool wasUpdated = _developerRepo.UpdateExistingDeveloper(int.Parse(oldDeveloper), newDeveloper);

            if (wasUpdated)
            {
                Console.WriteLine("Developer Successfully Updated.");
            }
            else
            {
                Console.WriteLine("Could not update Developer.");
            }
        }

        //Remove Existing Developer
        public void DeleteExistingDeveloper()
        {
            Console.Clear();

            DisplayListOfDevelopers();


            // Get the Developer they want to remove via IDNumber
            Console.WriteLine("\nEnter the ID Number for Developer you'd like to delete.");

            int input = int.Parse(Console.ReadLine());


            // Call the delete method

            bool wasDeleted = _developerRepo.RemoveDeveloperFromList(input);

            // If the content was deleted, say so
            if (wasDeleted)
            {
                Console.WriteLine("Developer was successfully deleted.");
            }
            else
            {
                Console.WriteLine("Developer could not be located.");
            }

            // Otherwise state it could not be deleted
        }

        private void DeletingExistingTeam()
        {
            Console.Clear();

            List<DevTeam> devTeamsInDatabase = _devTeamRepo.GetDevTeams().ToList();
            foreach (var team in devTeamsInDatabase)
            {
                Console.WriteLine($"{team.TeamID} {team.TeamName}");
            }

            Console.WriteLine("Please input Team ID:");
            var userInputTeamId = int.Parse(Console.ReadLine());

            var devTeam = _devTeamRepo.GetDevTeamByID(userInputTeamId);

            if (team is null)
            {
                Console.WriteLine("Team does not exist");
            }
            else
            {
                var success = _devTeamRepo.DeleteTeam(userInputTeamId);
                if (success)
                {
                    Console.WriteLine("Success");
                }
                else
                {
                    Console.WriteLine("Failure");
                }
            }

            Console.ReadKey();
        }

        private void UpdateExistingTeam()
        {
            Console.Clear();

            List<DevTeam> devTeamsInDatabase = _devTeamRepo.GetDevTeams().ToList();
            foreach (var team in devTeamsInDatabase)
            {
                Console.WriteLine($"{team.TeamID} {team.TeamName}");
            }

            Console.WriteLine("Please input Team ID:");
            var userInputTeamId = int.Parse(Console.ReadLine());

            var devTeam = _devTeamRepo.GetDevTeamByID(userInputTeamId);

            if (team is null)
            {
                Console.WriteLine("Team does not exist");
            }
            else
            {
                List<Developer> DevsInDatabase = _developerRepo.GetDevelopers().ToList();

                List<Developer> DevsToBeAddedToTeam = new List<Developer>();
                bool teamPosFilled = false;

                Console.WriteLine("Please input a Team Name:");
                var userInputTeamName = Console.ReadLine();

                while (!teamPosFilled)
                {
                    Console.Clear();
                    Console.WriteLine("Do you want to add any members? y/n");
                    var userInputAnyTeamMembers = Console.ReadLine();
                    if (userInputAnyTeamMembers == "Y".ToLower())
                    {
                        foreach (var dev in DevsInDatabase)
                        {
                            Console.WriteLine($"{dev.DeveloperIDNumber} {dev.FirstName} {dev.LastName}");
                        }

                        Console.WriteLine("Please Select a Developer by ID:");
                        int userInputDevId = int.Parse(Console.ReadLine();

                        var developer = _developerRepo.GetDeveloperByID(userInputDevId);

                        DevsToBeAddedToTeam.Add(developer);

                        DevsInDatabase.Remove(developer);
                    }
                    else
                    {
                        teamPosFilled = true;
                    }
                }

                DevTeam newDevTeamData = new DevTeam(userInputTeamName, DevsToBeAddedToTeam);
                var success = _devTeamRepo.UpdateTeam(userInputTeamId, newDevTeamData);

                if (success)
                {
                    Console.WriteLine("Sucess!!!");
                }
                else
                {
                    Console.WriteLine("Failure!!!");
                }
            }

            Console.ReadKey();

        }

        private void ViewSingleTeam()
        {
            Console.Clear();

            List<DevTeam> devTeamsInDatabase = _devTeamRepo.GetDevTeams().ToList();
            foreach (var team in devTeamsInDatabase)
            {
                Console.WriteLine($"{team.TeamID} {team.TeamName}");
            }

            Console.WriteLine("Please input Team ID:");
            var userInputTeamId = int.Parse(Console.ReadLine());

            var devTeam = _devTeamRepo.GetDevTeamByID(userInputTeamId);

            if (team is null)
            {
                Console.WriteLine("Team does not exist");
            }
            else
            {
                DisplayTeamData(devTeam);
            }

            Console.ReadKey();
        }

        private void ViewAllTeams()
        {
            Console.Clear();
            List<DevTeam> devTeamsInDatabase = _devTeamRepo.GetDevTeams().ToList();
            
            foreach (var team in devTeamsInDatabase)
            {
                DisplayTeamData(team);
            }
            Console.ReadKey();
        }

        private void DisplayTeamData(DevTeam team)
        {
            Console.WriteLine($"{team.TeamIDNumber}\n" +
                                $"{team.TeamName}\n");

            Console.WriteLine("--------------Members--------------------");

            foreach (var dev in team.Developers)
            {
                Console.WriteLine($"{dev.DeveloperIDNumber}\n"+
                                    $"{dev.FirstName} {dev.LastName}\n"+
                                    $"{dev.PluralSight}\n");
            }

            Console.WriteLine("--------------------------------------------");
        }

        private void CreateTeam()
        {
            Console.Clear();

            List<Developer> DevsInDatabase = _developerRepo.GetDevelopers().ToList();

            List<Developer> DevsToBeAddedToTeam = new List<Developer>();
            bool teamPosFilled = false;

            Console.WriteLine("Please input a Team Name:");
            var userInputTeamName = Console.ReadLine();

            while (!teamPosFilled)
            {
                Console.Clear();
                Console.WriteLine("Do you want to add any members? y/n");
                var userInputAnyTeamMembers = Console.ReadLine();
                if (userInputAnyTeamMembers == "Y".ToLower())
                {
                    foreach (var dev in DevsInDatabase)
                    {
                        Console.WriteLine($"{dev.DeveloperIDNumber} {dev.FirstName} {dev.LastName}");
                    }

                    Console.WriteLine("Please Select a Developer by ID:");
                    int userInputDevId = int.Parse(Console.ReadLine();

                    var developer = _developerRepo.GetDeveloperByID(userInputDevId);

                    DevsToBeAddedToTeam.Add(developer);

                    DevsInDatabase.Remove(developer);
                }
                else
                {
                    teamPosFilled = true;
                }
            }

            DevTeam devTeam = new DevTeam(userInputTeamName, DevsToBeAddedToTeam);

            bool success = _devTeamRepo.AddTeam(devTeam);

            if (success)
            {
                Console.WriteLine($"{devTeam.TeamName} was Created!");
            }
            else
            {
                Console.WriteLine("Failure!");
            }

            Console.ReadKey();
        }

        //Seed Developer Data
        
        private void SeedDevelopers()
        {
            Developer developerA = new Developer("John", "Weckerly", true);
            Developer developerB = new Developer("Nancy", "Lady", false);
            Developer developerC = new Developer("Wayne", "Robbinson", false);
            Developer developerD = new Developer("Kayla", "Jones", true);

            _devRepo.AddDeveloperToRepo(developerA);
            _devRepo.AddDeveloperToRepo(developerB);
            _devRepo.AddDeveloperToRepo(developerC);
            _devRepo.AddDeveloperToRepo(developerD);

            DevTeam teamA = new DevTeam("Tritan", new List<Developer>() { developerA, developerB });
            DevTeam teamB = new DevTeam("Long Rangers", new List<Developer>() { developerA, developerB, developerD });

            _devTeamRepo.AddTeam(teamA);
            _devTeamRepo.AddTeam(teamB);
        }
    }    
}
