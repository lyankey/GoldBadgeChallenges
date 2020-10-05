using System;
using System.Collections.Generic;
using _03_Komodo_Badge;
using _03_Komodo_Badge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_Komodo_Test
{
    [TestClass]
    public class Badge_Repository_Test
    {
        [TestMethod]
        public void AddToDirectory_ShouldGetCorrectBoolean()
        {
            //Arrange
            BadgeContent content = new BadgeContent();
            BadgeRepository repository = new BadgeRepository();

            //ACT - run the code that you're trying to test
            bool addResult = repository.AddContentToDirectory(content);

            //ASSERT
            Assert.IsTrue(addResult);
        }
 
    }
}
