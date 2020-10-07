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
        public void AddContentToDirectoryTest()
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
        public void GetContentsTest()
        {
            //Arrange
            MenuContent newMenuItem = new MenuContent();
            MenuContentRepository repoMenu = new MenuContentRepository();

            repoMenu.AddContentToDirectory(newMenuItem);

            //ACT
            List<MenuContent> listOfContents = repoMenu.GetContents();

            //ASSERT
            bool directoryHasContent = listOfContents.Contains(newMenuItem);
            Assert.IsTrue(directoryHasContent);

        }

        [TestMethod]
        public void Arrange()
        {
            MenuContentRepository repo = new MenuContentRepository();
            MenuContent content = new MenuContent(1,"Shrimp", "The shrimpinest shrimp in the west", 3.99m, new List<string>());
            repo.AddContentToDirectory(content);
        }
        [TestMethod]
        public void GetContentByNameTest()
        {
            //Arrange
            MenuContent content = new MenuContent(1, "Crab Rangoons", "The rangooniest rangoons in the west", 2.99m, new List<string>());
            MenuContentRepository repo = new MenuContentRepository();
            repo.AddContentToDirectory(content);

            //ACT
            MenuContent searchResult = repo.GetContentByName("Crab Rangoons");

            //ASSERT
            Assert.AreEqual(content, searchResult);
        }
        [TestMethod]
        public void UpdateExistingContentTest()
        {
            //Arrange
            MenuContent content = new MenuContent(1, "Crab Rangoons", "The rangooniest rangoons in the west", 2.99m, new List<string>());
            MenuContent updatedContent = new MenuContent(1, "Crab Rangoons", "The rangoonier rangoons in the west", 5.99m, new List<string>());
            MenuContentRepository repo = new MenuContentRepository();
            repo.AddContentToDirectory(content);

            //ACT
            bool updateResult = repo.UpdateExistingContent("Crab Rangoons", updatedContent);

            //ASSERT
            Assert.IsTrue(updateResult);
        }
        [TestMethod]
        public void DeleteExistingContentTest()
        {
            //arrange
            MenuContent content = new MenuContent(1, "Crab Rangoons", "The rangooniest rangoons in the west", 2.99m, new List<string>());
            MenuContentRepository _repo = new MenuContentRepository();

            bool addResult = _repo.AddContentToDirectory(content);

            //ACT
            bool removeResult = _repo.DeleteExistingContent(content);

            //Assert
            Assert.IsTrue(removeResult);
        }
    }
}

