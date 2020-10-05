using _03_Komodo_Badge;
using _03_Komodo_Badge_Repository;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace _03_Komodo_Badge_Console
{
    class ProgramUI
    {
        private readonly IConsole _console;
        private readonly BadgeRepositorycs _badgeRepositorycs = new BadgeRepositorycs();

        static void Main(string[] args)
        {
            IConsole console = new RealConsole();
            ProgramUI ui = new ProgramUI(console);
            ui.Run();
        }

        public ProgramUI(IConsole console)
        {
            _console = console;
        }

        public void Run()
        {
            SeedContent();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                _console.Clear();
                _console.WriteLine("Hello Security Admin, What would you like to do?\n" +
                    "1) Add a badge \n" +
                    "2) Edit a badge \n" +
                    "3) List all badges \n" +
                    "4) Exit \n");

                string userInput = _console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        // Add a badge
                        AddBadge();
                        break;
                    case "2":
                        // Edit a badge
                        EditBadge();
                        break;
                    case "3":
                        // List all badges
                        GetAllBadges();
                        break;
                    case "4":
                        //Exit
                        continueToRun = false;
                        break;
                    default:
                        //default
                        _console.WriteLine("Please enter a valid number between 1 and 4. \n" +
                            "Press any key to continue.....");
                        _console.ReadKey();
                        break;
                }
            }
        }

        private void AddBadge()
        {
            BadgeContent content = new BadgeContent();
            int id = _badgeRepositorycs.GetAllBadges().Count + 1;
            content.BadgeId = id;
            RequestDoorAccess(content);
        }

        private void RequestDoorAccess(BadgeContent content)
        {
            _console.WriteLine($"Please enter the door access for badge {content.BadgeId}.");
            string response = _console.ReadLine();
            content.Doors = ProgramUI.addDoorAccess(content.Doors, response);

            _console.WriteLine($"Would you like to add another door for badge {content.BadgeId}? \n" +
                "1) Yes \n" +
                "2) No \n");
            string doorAccessResponse = _console.ReadLine();
            switch (doorAccessResponse)
            {
                case "1":
                    RequestDoorAccess(content);
                    break;
                case "2":
                    _badgeRepositorycs.AddContentToDirectory(content);
                    break;
                default:
                    //default
                    _console.WriteLine("Please enter (1) Yes or (2) No (enter 1 or 2) \n" +
                        "Press any key to continue.....");
                    _console.ReadKey();
                    break;
            }
        }

        private static List<string> addDoorAccess(List<string> doors, string door)
        {
            doors.Add(door);
            return doors;
        }

        private void EditBadge()
        {
            GetAllBadges(false);
        }

        private void GetAllBadges(bool returnToMenu = true)
        {
            _console.Clear();
            Dictionary<int, List<string>> allBadges = _badgeRepositorycs.GetContents();
            foreach (KeyValuePair<int, List<string>> badge in allBadges)
            {
                _console.WriteLine($"Badge Id #{badge.Key} \n");

                foreach (string door in badge.Value)
                {
                    _console.WriteLine($"Door: {door}");
                }

                _console.WriteLine($"------------------");
            }

            if (returnToMenu == true)
            {
                _console.WriteLine("Press Enter to continue.");
                _console.ReadLine();
            }
            else
            {
                _console.WriteLine($"Which Badge Id would you like to Update or X to Exit to Main Menu? \n");
                string badgeUpdateResponse = _console.ReadLine();
                if (badgeUpdateResponse.ToLower() == "x")
                {
                    _console.WriteLine("Press Enter to return to the Main Menu.");
                    _console.ReadLine();
                }
                else
                {
                    int badgeId = Int32.Parse(badgeUpdateResponse);
                    AddRemoveEditDoor(badgeId);
                }
            }
        }

        private void AddRemoveEditDoor(int badgeId)
        {
            List<string> doors = _badgeRepositorycs.GetBadgeById(badgeId);
            _console.WriteLine("Badge Id #" + badgeId + " currently has " + doors.Count() + " door(s) assigned.");
            foreach (var door in doors.Select((value, i) => new { i, value }))
            {
                _console.WriteLine($"{door.i + 1}) Door: {door.value}");
            }
            _console.WriteLine($"\n");
            _console.WriteLine($"Would you like to Add, Remove, or Edit a door for Badge Id #" + badgeId + "? \n" +
            "1) Add \n" +
            "2) Remove \n" +
            "3) Edit \n" +
            "4) Return to the Badge Id Edit Menu");
            string doorAddRemoveEditResponse = _console.ReadLine();
            switch (doorAddRemoveEditResponse)
            {
                case "1":
                    AddDoorForEdit(badgeId, doors);
                    break;
                case "2":
                    RemoveDoorForEdit(badgeId);
                    break;
                case "3":
                    EditDoor(badgeId);
                    break;
                case "4":
                    EditBadge();
                    break;
                default:
                    //default
                    _console.WriteLine("Please enter (1) Add, (2) Remove, (3) Edit, or (4) Return to Badge Id Edit Menu. \n" +
                        "Press any key to continue.....");
                    _console.ReadKey();
                    break;
            }
        }
        private void AddDoorForEdit(int badgeId, List<string> doors)
        {
            _console.WriteLine($"\n");
            _console.WriteLine($"Please enter the new door access for Badge Id #{badgeId}.");
            string doorResponse = _console.ReadLine();

            doors.Add(doorResponse);
            AddRemoveEditDoor(badgeId);
        }

        private void RemoveDoorForEdit(int badgeId)
        {
            List<string> doors = _badgeRepositorycs.GetBadgeById(badgeId);
            _console.WriteLine("Badge Id #" + badgeId + " currently has " + doors.Count() + " door(s) assigned.");
            foreach (var door in doors.Select((value, i) => new { i, value }))
            {
                _console.WriteLine($"{door.i + 1}) Door: {door.value}");
            }

            _console.WriteLine($"Which door access would you like to remove? (Or press X to Return to Badge Id Edit Menu.) \n");
            string badgeUpdateResponse = _console.ReadLine();
            if (badgeUpdateResponse.ToLower() == "x")
            {
                _console.WriteLine("Press Enter to Return to Badge Id Edit Menu.");
                _console.ReadLine();
            }
            else
            {
                int badgeUpdateResponseInt = Int32.Parse(badgeUpdateResponse);

                doors.RemoveAt(badgeUpdateResponseInt - 1);

                AddRemoveEditDoor(badgeId);
            }
        }

        private void EditDoor(int badgeId)
        {

            List<string> doors = _badgeRepositorycs.GetBadgeById(badgeId);
            _console.WriteLine($"Badge Id #" + badgeId + " currently has " + doors.Count() + " door(s) assigned. \n");
            foreach (var door in doors.Select((value, i) => new { i, value }))
            {
                _console.WriteLine($"{door.i + 1}) Door: {door.value}");
            }

            _console.WriteLine("Which door would you like to edit?");
            string doorUpdateResponse = _console.ReadLine();

            // Used 1 as starting point for UI so need to subtract to get back to 0
            int doorUpdateResponseInt = Int32.Parse(doorUpdateResponse) - 1;

            _console.WriteLine($"Change the value of " + doors[doorUpdateResponseInt] + " to what? \n");
            string newDoorValue = _console.ReadLine();
            doors[doorUpdateResponseInt] = newDoorValue;


            _console.WriteLine($"Would you like to edit another door for Badge Id #" + badgeId + "? \n" +
            "1) Yes \n" +
            "2) No \n");
            string doorAccessResponse = _console.ReadLine();
            switch (doorAccessResponse)
            {
                case "1":
                    EditDoor(badgeId);
                    break;
                case "2":
                    EditAnotherDoor();
                    break;
                default:
                    //default
                    _console.WriteLine("Please enter (1) Yes or (2) No \n" +
                        "Press any key to continue.....");
                    _console.ReadKey();
                    break;
            }
        }

        private void EditAnotherDoor()
        {
            _console.WriteLine($"Would you like to edit another Badge Id? \n" +
            "1) Yes \n" +
            "2) No \n");
            string badgeIdResponse = _console.ReadLine();
            switch (badgeIdResponse)
            {
                case "1":
                    EditBadge();
                    break;
                case "2":
                    _console.WriteLine("Press Enter to continue.");
                    _console.ReadLine();
                    break;
                default:
                    //default
                    _console.WriteLine("Please enter (1) Yes or (2) No \n" +
                        "Press any key to continue.....");
                    _console.ReadKey();
                    break;
            }
        }

        private void SeedContent()
        {
            var titleOne = new BadgeContent(1, new List<string>() { "A1", "A2" });
            var titleTwo = new BadgeContent(2, new List<string>() { "A1", "A3", "B1" });
            var titleThree = new BadgeContent(3, new List<string>() { "A1" });
            var titleFour = new BadgeContent(4, new List<string>() { "B1", "B2", "B3" });
            var titleFive = new BadgeContent(5, new List<string>() { "A2", "B2" });

            _badgeRepositorycs.AddContentToDirectory(titleOne);
            _badgeRepositorycs.AddContentToDirectory(titleTwo);
            _badgeRepositorycs.AddContentToDirectory(titleThree);
            _badgeRepositorycs.AddContentToDirectory(titleFour);
            _badgeRepositorycs.AddContentToDirectory(titleFive);
        }
    }
}