using _03_Komodo_Badge;
using _03_Komodo_Badge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Komodo_Badge_Console
{
    class Komodo_BadgeUI
    {
        private readonly IConsole _console;
        private readonly BadgeRepositorycs _menuRepo = new BadgeRepository();
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
