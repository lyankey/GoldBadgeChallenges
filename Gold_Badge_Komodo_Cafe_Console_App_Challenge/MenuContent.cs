using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Gold_Badge_Komodo_Cafe_Console_App_Challenge_Repository
{
    public class MenuContent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<string> Ingredients { get; set; } = new List<string>();

        public MenuContent() { }
        public MenuContent(int id, string name, string description, decimal price, List<string> ingredients)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Ingredients = ingredients;
        }
    }
}


