
using System;
using System.Security.Cryptography.X509Certificates;
using Windows.Storage.Provider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UpKeepProject;
using UpKeepProject.Model.Catalog;

namespace UnitTestProject2
{
   
    [TestClass]
    public class KundeTest
    {
        [TestMethod]
        public void TestKundeName()
        {
            //Arrange
            KundeCatalog kundeCatalog = new KundeCatalog();

            //Act
            Kunde kunde = new Kunde();
            kunde = kundeCatalog.Read(1);

            //Assert
            Assert.AreEqual("UpKeep", kunde.Name);
        }


        [TestMethod]
        public void TestKundeAdresse()
        {
            //Arrange
            KundeCatalog kundeCatalog = new KundeCatalog();

            //Act
            Kunde kunde = new Kunde();
            kunde = kundeCatalog.Read(1);

            //Assert
            Assert.AreEqual("Maglegårdsvej 4", kunde.Adresse);
        }

        [TestMethod]
        public void TestKundeNummer()
        {
            //Arrange
            KundeCatalog kundeCatalog = new KundeCatalog();

            //Act
            Kunde kunde = new Kunde();
            kunde = kundeCatalog.Read(1);

            //Assert
            Assert.AreEqual(12345678, kunde.Nummer);
        }
    }
}
