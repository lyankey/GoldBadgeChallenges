using _05_Komodo_Greeting_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace _05_Komodo_Greeting
{
    public class ProgramUI
    {
        private readonly IConsole _console;
        private readonly GreetingContentRepository _greetingRepo = new GreetingContentRepository();
        //public GreetingContent currentGreeting = new GreetingContent();

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
                _console.WriteLine("Enter the number of the option you'd like to select :\n" +
                    "1) Show all customers in ABC order \n" +
                    "2) Show current customers \n" +
                    "3) Show past customers \n" +
                    "4) Show potential customers \n" +
                    "5) Enter a new customer \n" +
                    "6) Exit \n");

                string userInput = _console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        //Show All
                        ShowAllABC();
                        break;
                    case "2":
                        //Find by Name
                        ShowCurrent();
                        break;
                    case "3":
                        //Add New
                        ShowPast();
                        break;
                    case "4":
                        //Add New
                        ShowFuture();
                        break;
                    case "5":
                        //Add New
                        EnterNew();
                        break;
                    case "6":
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
        //show abc
        ShowAllABC()
        {

        }



        ShowCurrent()
        {

        }

        ShowPast()
        {

        }

        ShowFuture()
        {

        }

        EnterNew()
        {

        }
    }
}
