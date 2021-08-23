// Author : Chetan Lathi.   
// Created Test Cases for Hamara Basket
// Created on : 23 August 2021

using Microsoft.VisualStudio.TestTools.UnitTesting;
using HamaraBasket;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class HamaraBasketTests
    {    
        [TestMethod]
        public void When_ItemTypeIsNormalItem_And_SellByValueIsZero_Expect_QualityValueIsZero_And_NoChangeInSellByValueOf_CheckQualityofItems()
        {
            ////Arrange
             Basket objBasket = new Basket();
             objBasket.Items.Add(new Item(ItemType.NormalItem) { ItemName = "Orange", SellBy = 0, Quality = 11 });
             objBasket.Items.Add(new Item(ItemType.NormalItem) { ItemName = "Apple", SellBy = 0, Quality = 12 });
             int expectedQualityValue = 0, expectedSellByValue = 0;

            //Act
            objBasket.CheckQualityofItems();

            //Assert
            Assert.AreEqual(expectedQualityValue, objBasket.Items.First(item => item.ItemName == "Orange").Quality);
            Assert.AreEqual(expectedQualityValue, objBasket.Items.First(item => item.ItemName == "Apple").Quality);
            Assert.AreEqual(expectedSellByValue, objBasket.Items.First(item => item.ItemName == "Apple").SellBy);
            Assert.AreEqual(expectedSellByValue, objBasket.Items.First(item => item.ItemName == "Orange").SellBy);
        }

        [TestMethod]
        public void When_ItemTypeIsLegendaryItem_And_SellByValueIsZero_Expect_NoChangeInQuality_And_NoChangeInSellByValueOf_CheckQualityofItems()
        {
            ////Arrange
            Basket objBasket = new Basket();
            objBasket.Items.Add(new Item(ItemType.LegendaryItem) { ItemName = "Orange", SellBy = 0, Quality = 11 });
            objBasket.Items.Add(new Item(ItemType.LegendaryItem) { ItemName = "Apple", SellBy = 0, Quality = 12 });
            int expectedQualityValueOfOrange = 11, expectedQualityValueOfApple = 12, expectedSellByValue = 0;

            //Act
            objBasket.CheckQualityofItems();

            //Assert
            Assert.AreEqual(expectedQualityValueOfOrange, objBasket.Items.First(item => item.ItemName == "Orange").Quality);
            Assert.AreEqual(expectedQualityValueOfApple, objBasket.Items.First(item => item.ItemName == "Apple").Quality);
            Assert.AreEqual(expectedSellByValue, objBasket.Items.First(item => item.ItemName == "Apple").SellBy);
            Assert.AreEqual(expectedSellByValue, objBasket.Items.First(item => item.ItemName == "Orange").SellBy);
        }

        [TestMethod]
        public void When_ItemTypeIsNormalItem_And_SellByValueIsFiveDaysOrLess_Expect_QualityValueIsIncreasedByThreeOf_CheckQualityofItems()
        {
            ////Arrange
            Basket objBasket = new Basket();
            objBasket.Items.Add(new Item(ItemType.NormalItem) { ItemName = "Orange", SellBy = 5, Quality = 8 });
            objBasket.Items.Add(new Item(ItemType.NormalItem) { ItemName = "Apple", SellBy = 4, Quality = 12 });
            int expectedQualityValueOfOrange = 11, expectedQualityValueOfApple = 15;

            //Act
            objBasket.CheckQualityofItems();

            //Assert
            Assert.AreEqual(expectedQualityValueOfOrange, objBasket.Items.First(item => item.ItemName == "Orange").Quality);
            Assert.AreEqual(expectedQualityValueOfApple, objBasket.Items.First(item => item.ItemName == "Apple").Quality);            
        }

        [TestMethod]
        public void When_ItemTypeIsLegendaryItem_And_SellByValueIsFiveDaysOrLess_Expect_NoChangeInQualityValueOf_CheckQualityofItems()
        {
            ////Arrange
            Basket objBasket = new Basket();
            objBasket.Items.Add(new Item(ItemType.LegendaryItem) { ItemName = "Orange", SellBy = 5, Quality = 8 });
            objBasket.Items.Add(new Item(ItemType.LegendaryItem) { ItemName = "Apple", SellBy = 4, Quality = 12 });
            int expectedQualityValueOfOrange = 8, expectedQualityValueOfApple = 12;

            //Act
            objBasket.CheckQualityofItems();

            //Assert
            Assert.AreEqual(expectedQualityValueOfOrange, objBasket.Items.First(item => item.ItemName == "Orange").Quality);
            Assert.AreEqual(expectedQualityValueOfApple, objBasket.Items.First(item => item.ItemName == "Apple").Quality);
        }

        [TestMethod]
        public void When_ItemTypeIsNormalItem_And_SellByValueIsTenDaysOrLess_Expect_QualityValueIsIncreasedByTwoOf_CheckQualityofItems()
        {
            ////Arrange
            Basket objBasket = new Basket();
            objBasket.Items.Add(new Item(ItemType.NormalItem) { ItemName = "Orange", SellBy =10, Quality = 8 });
            objBasket.Items.Add(new Item(ItemType.NormalItem) { ItemName = "Apple", SellBy = 8,  Quality = 12 });
            int expectedQualityValueOfOrange = 10, expectedQualityValueOfApple = 14;

            //Act
            objBasket.CheckQualityofItems();

            //Assert
            Assert.AreEqual(expectedQualityValueOfOrange, objBasket.Items.First(item => item.ItemName == "Orange").Quality);
            Assert.AreEqual(expectedQualityValueOfApple, objBasket.Items.First(item => item.ItemName == "Apple").Quality);
        }

        [TestMethod]
        public void When_ItemTypeIsLegendaryItem_And_SellByValueIsTenDaysOrLess_Expect_NoChangeInQualityValueOf_CheckQualityofItems()
        {
            ////Arrange
            Basket objBasket = new Basket();
            objBasket.Items.Add(new Item(ItemType.LegendaryItem) { ItemName = "Orange", SellBy = 10, Quality = 8 });
            objBasket.Items.Add(new Item(ItemType.LegendaryItem) { ItemName = "Apple", SellBy = 8, Quality = 12 });
            int expectedQualityValueOfOrange = 8, expectedQualityValueOfApple = 12;

            //Act
            objBasket.CheckQualityofItems();

            //Assert
            Assert.AreEqual(expectedQualityValueOfOrange, objBasket.Items.First(item => item.ItemName == "Orange").Quality);
            Assert.AreEqual(expectedQualityValueOfApple, objBasket.Items.First(item => item.ItemName == "Apple").Quality);
        }

        [TestMethod]
        public void When_ItemTypeIsNormalItem_And_SellByDateHasPassed_Expect_QualityValueIsDegradesTwiceOf_CheckQualityofItems()
        {
            ////Arrange
            Basket objBasket = new Basket();
            objBasket.Items.Add(new Item(ItemType.NormalItem) { ItemName = "Orange", SellBy = -1, Quality = 8 });
            objBasket.Items.Add(new Item(ItemType.NormalItem) { ItemName = "Apple", SellBy = -2, Quality = 12 });
            int expectedQualityValueOfOrange = 4, expectedQualityValueOfApple = 6;

            //Act
            objBasket.CheckQualityofItems();

            //Assert
            Assert.AreEqual(expectedQualityValueOfOrange, objBasket.Items.First(item => item.ItemName == "Orange").Quality);
            Assert.AreEqual(expectedQualityValueOfApple, objBasket.Items.First(item => item.ItemName == "Apple").Quality);
        }

        [TestMethod]
        public void When_ItemTypeIsLegendaryItem_And_SellByDateHasPassed_Expect_NoChangeInQualityValueOf_CheckQualityofItems()
        {
            ////Arrange
            Basket objBasket = new Basket();
            objBasket.Items.Add(new Item(ItemType.LegendaryItem) { ItemName = "Orange", SellBy = -1, Quality = 8 });
            objBasket.Items.Add(new Item(ItemType.LegendaryItem) { ItemName = "Apple", SellBy = -2, Quality = 12 });
            int expectedQualityValueOfOrange = 8, expectedQualityValueOfApple = 12;

            //Act
            objBasket.CheckQualityofItems();

            //Assert
            Assert.AreEqual(expectedQualityValueOfOrange, objBasket.Items.First(item => item.ItemName == "Orange").Quality);
            Assert.AreEqual(expectedQualityValueOfApple, objBasket.Items.First(item => item.ItemName == "Apple").Quality);
        }
        
        [TestMethod]
        public void When_ItemTypeIsNormalItem_And_SellByValueIsMoreThanTenDays_Expect_QualityValueIsDecreaseByOneOf_CheckQualityofItems()
        {
            ////Arrange
            Basket objBasket = new Basket();
            objBasket.Items.Add(new Item(ItemType.NormalItem) { ItemName = "Orange", SellBy = 15, Quality = 8 });
            objBasket.Items.Add(new Item(ItemType.NormalItem) { ItemName = "Apple", SellBy = 12,  Quality = 12 });
            int expectedQualityValueOfOrange = 7, expectedQualityValueOfApple = 11;

            //Act
            objBasket.CheckQualityofItems();

            //Assert
            Assert.AreEqual(expectedQualityValueOfOrange, objBasket.Items.First(item => item.ItemName == "Orange").Quality);
            Assert.AreEqual(expectedQualityValueOfApple, objBasket.Items.First(item => item.ItemName == "Apple").Quality);
        }

        [TestMethod]
        public void When_ItemTypeIsLegendaryItem_And_SellByValueIsMoreThanTenDays_Expect_NoChangeInQualityValueOf_CheckQualityofItems()
        {
            ////Arrange
            Basket objBasket = new Basket();
            objBasket.Items.Add(new Item(ItemType.LegendaryItem) { ItemName = "Orange", SellBy = 15, Quality = 8 });
            objBasket.Items.Add(new Item(ItemType.LegendaryItem) { ItemName = "Apple", SellBy = 12, Quality = 12 });
            int expectedQualityValueOfOrange = 8, expectedQualityValueOfApple = 12;

            //Act
            objBasket.CheckQualityofItems();

            //Assert
            Assert.AreEqual(expectedQualityValueOfOrange, objBasket.Items.First(item => item.ItemName == "Orange").Quality);
            Assert.AreEqual(expectedQualityValueOfApple, objBasket.Items.First(item => item.ItemName == "Apple").Quality);
        }

        [TestMethod]
        public void When_ItemTypeIsNormalItem_AND_QualityValueIsNegative_Expect_FalseResultOf_ValidateQuality()
        {
            ////Arrange
            Item objItem= new Item(ItemType.NormalItem) { ItemName = "Orange", SellBy = 15, Quality = -1 };
            bool expectedResult = false;

            //Act
            bool result = objItem._qualityCheck.ValidateQuality(objItem);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void When_ItemTypeIsLegendaryItem_AND_QualityValueIsNegative_Expect_FalseResultOf_ValidateQuality()
        {
            ////Arrange
            Item objItem = new Item(ItemType.LegendaryItem) { ItemName = "Orange", SellBy = 15, Quality = -1 };
            bool expectedResult = false;

            //Act
            bool result = objItem._qualityCheck.ValidateQuality(objItem);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void When_ItemTypeIsNormalItem_AND_QualityValueIsMoreThanfifty_Expect_FalseResultOf_ValidateQuality()
        {
            ////Arrange
            Item objItem = new Item(ItemType.LegendaryItem) { ItemName = "Orange", SellBy = 15, Quality = 52 };
            bool expectedResult = false;

            //Act
            bool result = objItem._qualityCheck.ValidateQuality(objItem);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void When_ItemTypeIsLegendaryItem_AND_QualityValueIsMoreThanfifty_Expect_FalseResultOf_ValidateQuality()
        {
            ////Arrange
            Item objItem = new Item(ItemType.LegendaryItem) { ItemName = "Orange", SellBy = 15, Quality = 55 };
            bool expectedResult = false;

            //Act
            bool result = objItem._qualityCheck.ValidateQuality(objItem);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void When_ItemTypeIsNormalItem_AND_QualityValueIsLessThanfifty_AND_GreaterThanZero_Expect_TrueResultOf_ValidateQuality()
        {
            ////Arrange
            Item objItem = new Item(ItemType.NormalItem) { ItemName = "Orange", SellBy = 15, Quality = 35 };
            bool expectedResult = true;

            //Act
            bool result = objItem._qualityCheck.ValidateQuality(objItem);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void When_ItemTypeIsLegendaryItem_AND_QualityValueIsLessThanfifty_AND_GreaterThanZero_Expect_TrueResultOf_ValidateQuality()
        {
            ////Arrange
            Item objItem = new Item(ItemType.LegendaryItem) { ItemName = "Orange", SellBy = 15, Quality = 35 };
            bool expectedResult = true;

            //Act
            bool result = objItem._qualityCheck.ValidateQuality(objItem);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

    }
}
