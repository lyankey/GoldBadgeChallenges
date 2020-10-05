using System;
using System.Collections.Generic;
using _02_Komodo_Claim;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_Komodo_Claim_Test
{
    [TestClass]
    public class Komodo_Claim_Repository_Test
    {
        [TestClass]
        public class KomodoClaimRepositoryTest
        {
            [TestMethod]
            public void AddToDirectory_ShouldGetCorrectBoolean()
            {
                //Arrange
                ClaimsContent content = new ClaimsContent();
                ClaimsContentRepository repository = new ClaimsContentRepository();

                //ACT - run the code that you're trying to test
                bool addResult = repository.AddContentToDirectory(content);

                //ASSERT
                Assert.IsTrue(addResult);
            }

            [TestMethod]
            public void GetDirectory_ShouldReturnCorrectMenuList()
            {
                //Arrange
                ClaimsContent newItem = new ClaimsContent();
                ClaimsContentRepository repoMenu = new ClaimsContentRepository();
                //StreamingContent secondObject = new StreamingContent();

                repoMenu.AddContentToDirectory(newItem);

                //ACT
                List<ClaimsContent> listOfContents = repoMenu.GetContents();

                //ASSERT
                bool directoryHasContent = listOfContents.Contains(newItem);
                Assert.IsTrue(directoryHasContent);

            }

    

  

        }

    }
}

