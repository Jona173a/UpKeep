using Microsoft.VisualStudio.TestTools.UnitTesting;
using UpKeepProject;
using UpKeepProject.Model.Catalog;

namespace UnitTestProject2
{
    [TestClass]
    public class PersonaleTest
    {
            [TestMethod]
            public void TestKundeName()
            {
                //Arrange
                PersonaleCatalog personaleCatalog = new PersonaleCatalog();

                //Act
                Personale personale  = new Personale();
                personale = personaleCatalog.Read(1);

                //Assert
                Assert.AreEqual("Mikail Fener", personale.Name);
            }


            [TestMethod]
            public void TestKundeAdresse()
            {
                //Arrange
                PersonaleCatalog personaleCatalog = new PersonaleCatalog();

                //Act
                Personale personale = new Personale();
                personale = personaleCatalog.Read(1);

                //Assert
                Assert.AreEqual("Kærlunden 14", personale.Adresse);
            }

            [TestMethod]
            public void TestKundeNummer()
            {
                //Arrange
                PersonaleCatalog personaleCatalog = new PersonaleCatalog();

                //Act
                Personale personale = new Personale();
                personale = personaleCatalog.Read(1);

                //Assert
                Assert.AreEqual(22373134, personale.Nummer);
            }
        

    }
}