using System;
using System.Collections.Generic;
using Gold_Badge_Komodo_Cafe_Console_App_Challenge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Komodo_Cafe_Test
{
    [TestClass]
    public class KomodoCafeRepositoryTest
    {
        [TestMethod]
        public void AddToDirectory_ShouldGetCorrectBoolean()
        {
            //Arrange
            MenuContent content = new MenuContent();
            MenuContentRepository repository = new MenuContentRepository();

            //ACT - run the code that you're trying to test
            bool addResult = repository.AddContentToDirectory(content);

            //ASSERT
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetDirectory_ShouldReturnCorrectMenuList()
        {
            //Arrange
            MenuContent newMenuItem = new MenuContent();
            MenuContentRepository repoMenu = new MenuContentRepository();
            //StreamingContent secondObject = new StreamingContent();

            repoMenu.AddContentToDirectory(newMenuItem);

            //ACT
            List<MenuContent> listOfContents = repoMenu.GetContents();

            //ASSERT
            bool directoryHasContent = listOfContents.Contains(newMenuItem);
            Assert.IsTrue(directoryHasContent);

        }

        private MenuContentRepository repo;
        private MenuContent content;
        [TestInitialize]

        //because of the way the below method is written, you don't have to write this code again as long as you're in this class. The _ means it's a field
        //Arrange
        public void Arrange()
        {
            repo = new MenuContentRepository();
            content = new MenuContent(1,"Shrimp", "The shrimpinest shrimp in the west", 3.99m, new List<string>());
            repo.AddContentToDirectory(content);
        }
        [TestMethod]
        public void GetbyNameOfDish_ShouldReturnCorrectContent()
        {
            //ACT
            MenuContent searchResult = repo.GetContentByName("Shrimp");

            //ASSERT
            Assert.AreEqual(content, searchResult);
        }
        [TestMethod]
        public void UpdateExistingContent_ShouldReturnTrue()
        {
            //Arrange
            MenuContent updatedContent = new MenuContent(2, "Crab Rangoons", "The rangooniest rangoons in the west", 2.99m, new List<string>());
            repo.AddContentToDirectory(content);
            //ACT
            bool updateResult = repo.UpdateExistingContent("Crab Rangoons", updatedContent);
            //ASSERT
            Assert.IsTrue(updateResult);
        }
        [TestMethod]
        public void DeleteExistingContent_ShouldReturnTrue()
        {
            //arrange
            MenuContent foundContent = repo.GetContentByName("Crab Rangoons");
            //ACT
            bool removeResult = repo.DeleteExistingContent(foundContent);
            //Assert
            Assert.IsTrue(removeResult);
        }
    }
}

