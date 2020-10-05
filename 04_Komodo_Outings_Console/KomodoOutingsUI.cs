using _04_Komodo_Outings;
using _04_Komodo_Outings_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Komodo_Outings_Console
{
    class ProgramUI
    {
        private readonly IConsole _console;
        private readonly OutingRepository _outingsRepository = new OutingRepository();

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
                _console.WriteLine("Welcome to Event Manager4000. What would you like to do?\n" +
                    "1) Display all outings. \n" +
                    "2) Record an outing. \n" +
                    "3) Display all expenditures for all outings. \n" +
                    "4) Display all expenditures for one type of outing. \n" +
                    "5) Exit \n");

                string userInput = _console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        // Display all
                        DisplayAllOutings();
                        break;
                    case "2":
                        // Add an outing
                        RecordOuting();
                        break;
                    case "3":
                        // List total
                        ExpendituresAll();
                        break;
                    case "4":
                        // List cost of one
                        ExpendituresOne();
                        break;
                    case "5":
                        //Exit
                        continueToRun = false;
                        break;
                    default:
                        //default
                        _console.WriteLine("Please enter a valid number between 1 and 5. \n" +
                            "Press any key to continue.....");
                        _console.ReadKey();
                        break;
                }
            }
        }
        public void DisplayAllOutings()
        {
            Console.Clear();
            List<OutingsContent> ListOfAllOutings = _outingsRepository.GetList();

            foreach (OutingsContent outingType in ListOfAllOutings)
            {
                DateTime outingDate = outingType.EventDate;
                string dateFormat = outingDate.ToString("yyyy/mm/dd");
                Console.WriteLine($"{dateFormat} {outingType.OutingType} Attendance:{outingType.Count} Total cost:${outingType.TotalEventCost}");
                Console.ReadLine();
            }

        }
        public void RecordOuting()
        {
            Console.Clear();
            OutingsContent newRecord = new OutingsContent();

            Console.WriteLine("Enter Event Type Number:\n" +
                "1.Golf\n" +
                "2.Bowling\n" +
                "3.Amusement Park\n" +
                "4.Concert");

            string outString = Console.ReadLine();
            int outInt = int.Parse(outString);
            newRecord.OutingType = (OutingType)outInt;

            Console.WriteLine("Enter the attendance count:");
            string attendance = Console.ReadLine();
            newRecord.Count = int.Parse(attendance);

            Console.WriteLine("Enter Date of the Event as YYYY, MM, DD:");
            string date = Console.ReadLine();
            DateTime enteredDate = DateTime.Parse(date);
            newRecord.EventDate = enteredDate;

            Console.WriteLine("Enter the Cost Per Person:");
            string cost = Console.ReadLine();
            newRecord.CostEachPerson = double.Parse(cost);

            Console.WriteLine("Enter Total Event Cost:");
            string totalCost = Console.ReadLine();
            newRecord.TotalEventCost = double.Parse(totalCost);

            _outingsRepository.AddNewOuting(newRecord);
            Console.ReadLine();
        }
        public void ExpendituresAll()
        {
            Console.WriteLine($"Total Expenditures for All Outings is ${_outingsRepository.TotalCost()}.");
            Console.ReadLine();
        }
        public void ExpendituresOne()
        {
            Console.WriteLine($"Total Golf Outings Expenditures: ${_outingsRepository.CostByType(OutingType.Golf)} \n" +
                $"Total Bowling Outings Expenditures: ${_outingsRepository.CostByType(OutingType.Bowling)}\n" +
                $"Total Amusement Park Outings Expenditures: ${_outingsRepository.CostByType(OutingType.AmusementPark)}\n" +
                $"Total Concert Outings Expenditures: ${_outingsRepository.CostByType(OutingType.Concert)}");
            Console.ReadLine();
        }
        private void SeedContent()
        {
            var outingOne = new OutingsContent(OutingType.Concert, 50, new DateTime(2020, 10, 05), 10d, 500d);
            var outingTwo = new OutingsContent(OutingType.AmusementPark, 50, new DateTime(2020, 05, 31), 10d, 500d);
            var outingThree = new OutingsContent(OutingType.Golf, 50, new DateTime(2020, 10, 05), 10d, 500d);
            var outingFour = new OutingsContent(OutingType.Bowling, 50, new DateTime(2020, 10, 05), 10d, 500d);
            var outingFive = new OutingsContent(OutingType.Concert, 50, new DateTime(2020, 10, 05), 10d, 500d);
            _outingsRepository.AddNewOuting(outingOne);
            _outingsRepository.AddNewOuting(outingTwo);
            _outingsRepository.AddNewOuting(outingThree);
            _outingsRepository.AddNewOuting(outingFour);
            _outingsRepository.AddNewOuting(outingFive);

        }
    }
}
   
        