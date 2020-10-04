using Gold_Badge_Komodo_Cafe_Console_App_Challenge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Cafe_Console
{
    public class ProgramUI
    {
        private readonly IConsole _console;
        private readonly MenuRepositorycs _menuRepo = new MenuRepositorycs();
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
                    "1) Show All Menu Items \n" +
                    "2) Find by name \n" +
                    "3) Add new Menu Item \n" +
                    "4) Remove Menu Item \n" +
                    "5) Exit \n");

                string userInput = _console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        //Show All
                        ShowAllContent();
                        break;
                    case "2":
                        //Find by Name
                        ShowContentByName();
                        break;
                    case "3":
                        //Add New
                        CreateNewContent();
                        break;
                    case "4":
                        //Remove
                        RemoveContentFromList();
                        break;
                    case "5":
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
        private void ShowAllContent()
        {
            _console.Clear();
            //GET the items from our fake database
            List<MenuContent> listOfContent = _menuRepo.GetContents();
            //Take EACH item and display property values
            foreach (MenuContent content in listOfContent)
            {
                _console.WriteLine(
                    $"Menu Item #{content.Id} \n" +
                    $"{content.Name} \n" +
                    $"{content.Description} \n" +
                    $"${content.Price} \n" +
                    $"{string.Join(", ", content.Ingredients)} \n" +
                    $"------------------");
            }
            //Pause the program so the user can see the printed objects
            //Show all items in our fake database
            _console.WriteLine("Press Enter to continue.");
            _console.ReadLine();
        }

        private void ShowContentByName()
        {
            _console.Clear();
            //Goal? I want to show only one object -> found by title
            //Step 1 Get title from user
            _console.WriteLine("Please enter the name: ");
            //store their response as "name"
            string name = _console.ReadLine();
            //Use that name to find the one object -> we have built this method
            MenuContent foundContent = _menuRepo.GetContentByName(name);
            //If object found display data / if not inform user that title does not exist
            if (foundContent != null)
            {
                DisplayAllProps(foundContent);
            }
            else
            {
                _console.WriteLine("There are no menu items that matched the one you gave. /n");
            }
            _console.WriteLine("Press any key to continue....");
            _console.ReadKey();
        }

        private void CreateNewContent()
        {
            //a new content object
            MenuContent content = new MenuContent();
            //Ask user for information
            //Name
            _console.WriteLine("Please enter the name of the new dish.");
            string contentName = _console.ReadLine();
            content.Name = contentName;

            //Description
            _console.WriteLine($"Please enter the description for {content.Name}.");
            content.Description = _console.ReadLine();

            //Price
            _console.WriteLine($"Please enter the price for {content.Name}, such as 1.99.");
            content.Price = (decimal)float.Parse(_console.ReadLine());

            //Ingredients
            _console.WriteLine($"Please enter all the ingredients for {content.Name}, separated by commas.");
            string ingredients = Console.ReadLine();
            List<string> ingredientList = ingredients.Split(new char[] { ' ' },
            StringSplitOptions.RemoveEmptyEntries).ToList();
            content.Ingredients = ingredientList;


            _menuRepo.AddContentToDirectory(content);

            //a new content with properties filled out by user
            //Pass that to the add method in our repository

        }

        private void RemoveContentFromList()
        {
            //Ask the user which one they want to remove
            _console.WriteLine("Which menu item would you like to remove?");
            //need a list of items
            List<MenuContent> contentList = _menuRepo.GetContents();
            int count = 0;
            foreach (var content in contentList)
            {
                count++;
                _console.WriteLine($"{count}) {content.Name}");
            }
            //take in user response
            int targetContentID = int.Parse(_console.ReadLine());
            int correctIndex = targetContentID - 1;
            if (correctIndex >= 0 && correctIndex < contentList.Count)
            {
                MenuContent desiredContent = contentList[correctIndex];
                //Remove that item
                if (_menuRepo.DeleteExistingContent(desiredContent))
                {
                    _console.WriteLine($"{desiredContent.Name} successfully removed!");
                }
                else
                {
                    _console.WriteLine("I'm sorry, Dave. I'm afraid I can't do that.");
                }
            }
            else
            {
                _console.WriteLine("INVALID OPTION");
            }
            _console.WriteLine("Press any key to continue....");
            _console.ReadKey();
        }


        private void DisplayAllProps(MenuContent content)
        {
            _console.WriteLine(
                $"Id: {content.Id} \n" +
                $"Name: {content.Name} \n" +
                $"Description: {content.Description} \n" +
                $"Price: ${content.Price}" +
                $"Ingredients: {content.Ingredients} \n" +
                $"");
        }

        private void SeedContent()
        {
            List<int> listOne = new List<int>() { 1, 2 };

            var titleOne = new MenuContent(1, "Spaghetti", "Plain old spaghetti", 2.50m, new List<string>() { "noodles", "tomato sauce" });
            var titleTwo = new MenuContent(2, "Mac N Cheese", "Junk from a box", 3.75m, new List<string>() { "noodles", "fake cheese sauce", "milk" });
            var titleThree = new MenuContent(3, "PBnJ", "So easy a 5 year old could make it", 5.00m, new List<string>() { "bread", "peanut butter", "jelly" });
            var titleFour = new MenuContent(4, "Cereal", "Lucky Charms", 1.50m, new List<string>() { "sugar", "wheat", "milk" });
            var titleFive = new MenuContent(5, "Filet Mignon", "Eat hearty", 20.00m, new List<string>() { "meat" });

            _menuRepo.AddContentToDirectory(titleOne);
            _menuRepo.AddContentToDirectory(titleTwo);
            _menuRepo.AddContentToDirectory(titleThree);
            _menuRepo.AddContentToDirectory(titleFour);
            _menuRepo.AddContentToDirectory(titleFive);

        }
    }
}

