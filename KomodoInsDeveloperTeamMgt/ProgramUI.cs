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
                    "1. Create New Developer\n" +
                    "2. View List of Developers\n" +
                    "3. View Developer by Developer ID Number\n" +
                    "4. Update Existing Developer information\n" +
                    "5. Remove Existing Developer\n" +
                    "6. Exit");

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
    }

        //they need to be able to add/remove by developerID number, see a list of existing developers to choose from, and add to existing lists. 
        //mgr creates team, then add developers individually fromt he developer directory

       
}
