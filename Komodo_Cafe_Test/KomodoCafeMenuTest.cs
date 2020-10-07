using System;
using System.Collections.Generic;
using Gold_Badge_Komodo_Cafe_Console_App_Challenge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Komodo_Cafe_Test
{
    [TestClass]
    public class KomodoCafeMenuTest
    {
        [TestMethod]
        public void MenuContentNotes()
        {
            MenuContent dishObject = new MenuContent();
            MenuContent newDish = new MenuContent(1, "Rangoons", "Deep fried cream cheese and fake crab", 3.99m, new List<string>());
        }

    }
}

