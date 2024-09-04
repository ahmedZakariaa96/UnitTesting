using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace UnitTesting.Test
{
    [TestClass]
    public class WeightCalculaterTest
    {
        public TestContext testcontex { get; set; }
        [ClassInitialize]
        public static void classInitlizer(TestContext contex)
        {
            contex.WriteLine("classInitlizer start");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            //contex.WriteLine("ClassCleanup start");
        }

        [TestInitialize]
        public void TestInitialize()
        {
            //testcontex.WriteLine("TestInitialize start");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            //testcontex.WriteLine("TestCleanup start");
        }

        [TestMethod]
        [Description("Given_when_then")]
        [Owner("Mostafe")]
        [Priority(2)]

        //Given_when_then
        public void GetIdealWeight_GanderIsMAndHeightIs73_ResultEqual67Dot25()
        {
            //Arrange
            WeightCalculater WeightCalculater = new WeightCalculater(173, "m");

            //act
            double returnValue = WeightCalculater.GetIdealWeight();
            double expectedValue = 67.25;

            //asserts
            Assert.AreEqual(returnValue, expectedValue);
        }


        [TestMethod]
        [Owner("Mostafe")]
        [Priority(2)]

        public void GetIdealWeight_GenderIsFAndHHeightIs173_ResultEqual61Dot5()
        {
            //arrange
            WeightCalculater WeightCalculater = new WeightCalculater(173, "f");

            //act
            double returnValue = WeightCalculater.GetIdealWeight();
            double expectedValue = 61.5;

            //asserts
            Assert.AreEqual(returnValue, expectedValue);

        }


        [TestMethod]
        [Owner("Mostafe")]
        [Priority(3)]
        [Timeout(3000)]
        [ExpectedException(typeof(ArgumentException))]
        public void GetIdealWeight_GenderIsNoAndHHeightIs173_ReturnExceptions()
        {
            //arrange
            WeightCalculater WeightCalculater = new WeightCalculater(173, "k");

            //act
            double returnValue = WeightCalculater.GetIdealWeight();
            double expectedValue = 0;

            //asserts
            Assert.AreEqual(returnValue, expectedValue);

        }


        [Owner("ahmedzakaria")]
        [Priority(1)]
        [TestMethod]
        public void asssert_class()
        {
            WeightCalculater WeightCalculater = new WeightCalculater(173, "m");
            WeightCalculater WeightCalculater2 = null;


            Assert.IsInstanceOfType(WeightCalculater, typeof(WeightCalculater));
        }

        [Owner("ahmedzakaria")]
        [Priority(1)]
        [TestMethod]
        public void string_assert()
        {
            string name = "ahmedka";
            StringAssert.Contains(name, "ka");
        }

        [Owner("ahmedzakaria")]
        [Priority(1)]
        [TestMethod]
        [Ignore]
        public void collectionAssert_Tests()
        {
            List<string> names = new List<string>() { "ahmed", "zika", "ali2", "koko", "ali", "mostafe" };
            CollectionAssert.AllItemsAreUnique(names);
            CollectionAssert.AllItemsAreNotNull(names);
            CollectionAssert.Contains(names, "zika");
            CollectionAssert.AllItemsAreInstancesOfType(names, typeof(string));

        }



        [TestMethod]
        [Priority(1)]
        [Owner("ahmedzakaria")]
        public void FluentAssertions_test()
        {
            //string assert
            string name = "ahmed";
            name.Should().Contain("hm");
            name.Should().StartWith("a").And.EndWith("ed");

            //class assert

            WeightCalculater WeightCalculater = new WeightCalculater(173, "m");
            WeightCalculater WeightCalculater2 = null;
            WeightCalculater.Should().NotBeSameAs(WeightCalculater2);
            WeightCalculater.Should().NotBeNull();


            //collectons assert
            List<string> names = new List<string>() { "ahmed", "zika", "ali2", "koko", "ali", "mostafe" };
            names.Should().OnlyHaveUniqueItems();

        }

        [TestMethod]
        public void GetIdealBodyWeightFormDataSource_WithGoodInputs_ExpectedResult()
        {
            WeightCalculater wc = new WeightCalculater(new fakeWeightRepository());
            List<double> actualdata = wc.GetIdealBodyWeightFormDataSource();
            double[] expected = { 62.5, 62.75, 74 };
            //CollectionAssert.AreEqual(expected, actualdata);
            actualdata.Should().BeEquivalentTo(expected);
        }
        [TestMethod]
        public void GetIdealBodyWeightFormDataSource_with_moq()
        {
            List<WeightCalculater> WeightCalculaterList = new List<WeightCalculater>()
            {
                new WeightCalculater(175,"f"),//62.5
                new WeightCalculater(167,"m"),//62.75
                new WeightCalculater(182,"m"),//74
            };
            Mock<IDataRepository> rep = new Mock<IDataRepository>();

            rep.Setup(x => x.GetWeightcalculators()).Returns(WeightCalculaterList);
            WeightCalculater wc = new WeightCalculater(rep.Object);
            List<double> actualdata = wc.GetIdealBodyWeightFormDataSource();
            double[] expected = { 62.5, 62.75, 74 };
            actualdata.Should().BeEquivalentTo(expected);

        }
        [TestMethod]
        public void GetIdealBodyWeightFormDataSource_with_Fake()
        {
            List<WeightCalculater> WeightCalculaterList = new List<WeightCalculater>()
            {
                new WeightCalculater(175,"f"),//62.5
                new WeightCalculater(167,"m"),//62.75
                new WeightCalculater(182,"m"),//74
            };
            IDataRepository rep = A.Fake<IDataRepository>();
            A.CallTo(() => rep.GetWeightcalculators()).Returns(WeightCalculaterList);
            WeightCalculater wc = new WeightCalculater(rep);
            List<double> actualdata = wc.GetIdealBodyWeightFormDataSource();
            double[] expected = { 62.5, 62.75, 74 };
            actualdata.Should().BeEquivalentTo(expected);

        }

        [DataTestMethod]
        [DataRow(175,"f", 62.5)]
        [DataRow(167, "m", 62.75)]
        [DataRow(182, "m", 74)]
        public void workingWithDataDeivenTests(double hight,string gander,double expected)
        {
            WeightCalculater wc = new WeightCalculater(hight, gander);
            double actualData = wc.GetIdealWeight();
            actualData.Should().Be(expected);
        }

        public static List<object[]>TestCases()
        {
            return new List<object[]>
            {
                new object[]{175,"f", 62.5},
                new object[]{167, "m", 62.75},
                new object[]{182, "m", 74},

            };
        }
        [DataTestMethod]
        [DynamicData(nameof(TestCases),DynamicDataSourceType.Method)]
        public void workingWithDynamicData(double hight, string gander, double expected)
        {
            WeightCalculater wc = new WeightCalculater(hight, gander);
            double actualData = wc.GetIdealWeight();
            actualData.Should().Be(expected);
        }

        [TestMethod]
        public void validateWithBadSexReturnFalse()
        {
            WeightCalculater wc = new WeightCalculater();
            wc.gander = "t";
            bool actual = wc.validate();
            actual.Should().BeFalse();
        }

    }
}
