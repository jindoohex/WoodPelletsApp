using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace WoodPelletsAppLibrary.model.Tests
{
    [TestClass()]
    public class WoodPelletTests
    {
        private static WoodPellet wdpl = new WoodPellet();

        [TestMethod()]
        [DataRow("Trævenner")]
        [DataRow("Varmegutterne")]
        public void WoodPellet_Name_Test_Expected_Success(string brand)
        {
            // Arrange

            // Act

            // Assert
            Assert.IsTrue(wdpl.CheckBrand(brand));
        }


        [TestMethod()]
        [DataRow("")]
        [DataRow("A")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WoodPellet_Name_Test_Expected_Failure(string brand)
        {
            // Arrange

            // Act
            //wdpl.Brand = brand;
            wdpl.CheckBrand(brand);

            // Assert
            Assert.Fail();
        }

        [TestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        public void WoodPellet_Quality_Test_Expected_Success(int quality)
        {
            // Arrange


            // Act


            // Assert
            Assert.IsTrue(wdpl.CheckQuality(quality));
        }

        [TestMethod()]
        [DataRow(0)]
        [DataRow(6)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WoodPellet_Quality_Test_Expected_Failure(int quality)
        {
            // Arrange


            // Act
            wdpl.CheckQuality(quality);

            // Assert
            Assert.Fail();
        }

        [TestMethod()]
        [DataRow(1)]
        [DataRow(6)]
        [DataRow(200)]
        [DataRow(2000000)]
        [DataRow(2000000000)]
        public void WoodPellet_Price_Check_Test_Expected_Success(int price)
        {
            // Arrange


            // Act


            // Assert
            Assert.IsTrue(wdpl.PriceCheck(price));
        }

        [TestMethod()]
        [DataRow(0)]
        [DataRow(-1)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WoodPellet_Price_Check_Test_Expected_Failure(int price)
        {
            // Arrange


            // Act
            wdpl.PriceCheck(price);

            // Assert
            Assert.Fail();
        }
    }
}