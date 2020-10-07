using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Komodo_Greeting_Class
{
    public interface IConsole
    {

        void WriteLine(string s);
        void WriteLine(object o);
        void Clear();
        string ReadLine();
        ConsoleKeyInfo ReadKey();
    }
}
