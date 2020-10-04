using _02_Komodo_Claim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace _02_Komodo_Claim_Console
{
    public class ProgramUI
    {
        private readonly IConsole _console;
        private readonly ClaimsContentRepositorycs _claimsRepo = new ClaimsContentRepositorycs();
        public ClaimsContent currentClaim = new ClaimsContent();

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
                    "1) Show all claims \n" +
                    "2) Take care of next claim \n" +
                    "3) Enter a new claim \n" +
                    "4) Exit \n");

                string userInput = _console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        //Show All
                        ShowAllContent();
                        break;
                    case "2":
                        //Find by Name
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        //Add New
                        CreateNewContent();
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
        private void ShowAllContent()
        {
            _console.Clear();
            //GET the items from our fake database
            List<ClaimsContent> listOfContent = _claimsRepo.GetContents();

            String s = String.Format("{0,-10} {1,-10} {2,-25} {3,-10} {4,-15} {5,-15} {6,-5}\n\n", "Claim Id", "Type", "Description", "Amount", "Date Accident", "Date Claim", "Valid");

            //String s = String.Format("{0,-10} {1,-25} {2,-10}\n\n", "ClaimId", "Description", "Amount");

            foreach (ClaimsContent content in listOfContent)
            {
                //_console.WriteLine(
                //    $"ClaimID: {content.ClaimId} \n" +
                //    $"Type: {content.ClaimType} \n" +
                //    $"Description: {content.Description} \n" +
                //    $"Amount:{content.Amount} \n" +
                //     $"DateOfAccident:{content.DateClaim} \n" +
                //     $"DateOfClaim:{content.DateAccident} \n" +
                //      $"Isvalid: {content.IsValid} \n" +
                //    $"------------------");

                s += String.Format("{0,-10} {1,-10} {2,-25} {3,-10} {4,-15:MM/dd/yy} {5,-15:MM/dd/yy} {6,-5}\n", content.ClaimId, content.ClaimType.ToString(), content.Description, content.Amount, content.DateClaim, content.DateAccident, content.IsValid);

                //s += String.Format("{0,-10} {1,-25} {2,-10}\n", content.ClaimId, content.Description, content.Amount);
            }
            //Pause the program so the user can see the printed objects
            //Show all items in our fake database

            Console.WriteLine($"\n{s}");

            _console.WriteLine("Press Enter to continue.");
            _console.ReadLine();
        }

        private void TakeCareOfNextClaim()
        {
            _console.Clear();

            //If object found display data / if not inform user that title does not exist
            if (currentClaim.ClaimId >= _claimsRepo.GetContents().Count())
            {
                Console.WriteLine("You have reached the last claim in the system. Press any key to return to the menu.");
                Console.ReadKey();
                RunMenu();
            }

                if (currentClaim.ClaimId > 0)
                {
                    currentClaim = _claimsRepo.GetClaimById(currentClaim.ClaimId + 1);
                }
                else
                {
                    currentClaim = _claimsRepo.GetClaimById(1);
                }
                DisplayAllProps(currentClaim);
        }

        private void CreateNewContent()
        {
            //a new content object
            ClaimsContent content = new ClaimsContent();

            // Auto grab the next highest Id for claims
            int id = _claimsRepo.GetAllClaims().Count() + 1;
            content.ClaimId = id;

            _console.WriteLine("Select a Claim Type: \n" +
                    "1)Car \n" +
                    "2)Home \n" +
                    "3)Theft \n");
            string claimTypeResponse = _console.ReadLine();
            switch (claimTypeResponse)
            {
                case "1":
                    content.ClaimType = ClaimType.Car;
                    break;
                case "2":
                    content.ClaimType = ClaimType.Home;
                    break;
                case "3":
                    content.ClaimType = ClaimType.Theft;
                    break;
            }

            //Description
            _console.WriteLine($"Please enter the description for ClaimId {content.ClaimId}.");
            content.Description = _console.ReadLine();

            //Amount
            _console.WriteLine($"Please enter the amount of the claim for Claim No. {content.ClaimId}, such as 109.99.");
            content.Amount = (decimal)float.Parse(_console.ReadLine());

            //Date of Accident
            _console.WriteLine($"Please enter the date of the incident for Claim No. {content.ClaimId}(e.g. 10/22/2020.");
            content.DateAccident = DateTime.Parse(Console.ReadLine());

            //Date of Claim
            _console.WriteLine($"Please enter all the date the claim was made for Claim No.  {content.ClaimId}(e.g. 10/22/2020.");
            content.DateClaim = DateTime.Parse(Console.ReadLine());

            //Validity Check

            ValidityCheck validityCheck = new ValidityCheck();
            content.IsValid = validityCheck.IsTimeDifferenceOverCertainDays(content.DateAccident, content.DateClaim, 30);

            _claimsRepo.AddContentToDirectory(content);
        }



        //    {
        //        string claimsDashboard = "";
        //        string item = "";
        //        double price = 0;
        //        whateverRuler + -"0----5---10---15---20---25---30---35---40" + "\n";
        //        for (int i = 0; 1 < 20; 1++)
        //        {
        //            if (1 % 2 == 0)
        //            {
        //                item = "reallylongname";
        //                price = 6.95;
        //            }
        //            else
        //            {
        //                item = "name";
        //                price = 113.95;
        //            }
        //            whateverRuler += string.Format("{0,20"), item);
        //    //whatever += "\t";
        //    whateverRuler += string.Format("{0,40:C"), price;
        //    whateverRuler += "\n";

        //}
        //Console.WriteLine(ClaimsDashboard);
        //    Console.ReadKey();

        //{
        //    _console.WriteLine(
        //        $"Id: {content.Id} \n" +
        //        $"Name: {content.Name} \n" +
        //        $"Description: {content.Description} \n" +
        //        $"Price: ${content.Price}" +
        //        $"Ingredients: {content.Ingredients} \n" +
        //        $"");
        // 

        private void DisplayAllProps(ClaimsContent content)
        {
            
                _console.WriteLine(
                    $"ClaimID: {content.ClaimId} \n" +
                    $"Type: {content.ClaimType} \n" +
                    $"Description: {content.Description} \n" +
                    $"Amount:{content.Amount} \n" +
                     $"DateOfAccident:{content.DateClaim} \n" +
                     $"DateOfClaim:{content.DateAccident} \n" +
                      $"Isvalid: {content.IsValid} \n" +
                    $"------------------");
            Console.WriteLine("1) View Next Claim \n" + "2) Return to Main Menu.");
                    string userInput = _console.ReadLine();
            switch (userInput)
            {
                case "1":
                    TakeCareOfNextClaim();
                    break;
                case "2":
                    RunMenu();
                    break;
            }
            
            
        }
            private void SeedContent()
        {

            List<int> listOne = new List<int>() { 1, 2 };

            var titleOne = new ClaimsContent(1, ClaimType.Car, "rear-ended", 112.50m, new DateTime(2020, 10, 9), new DateTime(2020, 10, 20), true);
            var titleTwo = new ClaimsContent(2, ClaimType.Car, "parking lot", 113.75m, new DateTime(2020, 10, 11), new DateTime(2020, 10, 20), true);
            var titleThree = new ClaimsContent(3, ClaimType.Car, "t-boned", 115.00m, new DateTime(2020, 10, 12), new DateTime(2020, 10, 20), true);
            var titleFour = new ClaimsContent(4, ClaimType.Theft, "burglary 2pm", 111.50m, new DateTime(2020, 10, 13), new DateTime(2020, 10, 20), true);
            var titleFive = new ClaimsContent(5, ClaimType.Home, "hail damaged roof", 1120.00m, new DateTime(2020, 10, 14), new DateTime(2020, 12, 20), false);

            _claimsRepo.AddContentToDirectory(titleOne);
            _claimsRepo.AddContentToDirectory(titleTwo);
            _claimsRepo.AddContentToDirectory(titleThree);
            _claimsRepo.AddContentToDirectory(titleFour);
            _claimsRepo.AddContentToDirectory(titleFive);

        }

    }
}


    

