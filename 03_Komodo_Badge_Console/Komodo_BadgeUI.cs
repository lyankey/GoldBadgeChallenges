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
    public class ProgramUI
    {
        private readonly IConsole _console;
        private readonly BadgeRepository _badgesRepo = new BadgeRepository();
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

        public void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Please choose a function below."\n +
                     "1) See All Badges\n" +
                    "2) Change Door Access\n" +
                    "3) Add a New Badge\n" +
                    "4) Look Up a Badge by Id\n" +
                    "5) Delete a Badge\n"+
                    "6) Exit");
                
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        //Show All
                        _badgesRepo.GetBadgeList();
                        break;
                    case "2":
                        //Update
                        ChangeDoorAccess();
                        break;
                    case "3":
                        //Add New
                        AddNewBadge();
                        break;
                    case "4":
                        //Get by Id
                        GetContentById();
                        break;
                    case "5":
                        //Add New
                        DeleteBadge();
                        break;
                    case "6":
                        //Exit
                        continueToRun = false;
                        break;
                    default:
                        //default
                        _console.WriteLine("Please enter a valid number between 1 and 6. \n" +
                            "Press any key to continue.....");
                        _console.ReadKey();
                        break;
                }
            }
        }
        public void ChangeDoorAccess()
        {
            AddNewBadge();
        }

        public void AddNewBadge()
        {
            int badgeId = 0;
            List<string> Doors = new List<string>();
            badgeId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter one new door for this badge.");
            string accessInput = Console.ReadLine();
            Doors.Add(accessInput);

            bool running = true;
            while (running)
            {
                Console.WriteLine("Do you need to add access to another door for this badge?\n" + "Type 1 for yes or 2 for No");
                string ynResponse = Console.ReadLine();
                switch (ynResponse)
                {
                    case "1":
                        Console.WriteLine("Enter one new door for this badge.");
                        string accessInput2 = Console.ReadLine();
                        Doors.Add(accessInput2);
                        break;
                    case "2";
                        running = false;
                        break;
                }
            }
            BadgeContent newBadge = new BadgeContent(badgeId, doors);
            _badgesDirectory.
        }


        //seedcontent:
        //static void Mani(string[] args)
        //{
        //    dict = new Dictionary<string, object>();

        //    Add("pi", 3.14159);
        //    Add("john", "wayne");
        //    Add("chicken", "is a bird that doesn't fly.");
        //    Add("i", 45);

        //    Console.WriteLine("pi=" + GetAnyValue<double>("pi"));
        //    Console.WriteLine("john=" + GetAnyValue<string>("john"));
        //    Console.WriteLine("chicken=" + GetAnyValue<string>("chicken"));
        //    Console.WriteLine("i=" + GetAnyValue<int>("i"));
        //    //Console.WriteLine("j=" + GetAnyValue<int>("j")); - will equal 0 because no value associated with j

        //    Console.ReadLine();

        //}
    }
