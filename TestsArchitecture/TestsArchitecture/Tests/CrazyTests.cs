using NUnit.Framework;
using OpenQA.Selenium;
using TestsArchitecture.Pages;
using TestsArchitecture.Utils;

namespace TestsArchitecture
{
    [TestFixture]
    public class Tests
    {
        private Steps.CrazySteps steps = new Steps.CrazySteps();
        private const string WebSiteAddress = "https://qxbroker.com/";

        [SetUp]
        public void Init()
        {
            Driver.DriverInstance.GetInstance().Navigate().GoToUrl(WebSiteAddress);
            steps.InitBrowser();
        }

        [TearDown]
        public void Cleanup()
        {
            Utils.TestLogger.LogStat(TestContext.CurrentContext);
            Driver.DriverInstance.CloseBrowser();
            TestContext.WriteLine("Hello world");
        }

        [Test]
        public void PushCorrectStockTransactAndCheckInHistoryList()
        {
            steps.LoginInQuotex();
            steps.ChooseStockInList("AUD/CAD");
            steps.PushStockTransaction(new System.DateTime(2021, 1, 1, 0, 1, 0), 50, true);

            Assert.IsTrue(Utils.GetStandartValueForTest.GetCorrectList().EqualListsOfItemInHistoryList(steps.GetListItemsInHistoryList()));
        }

        [Test]
        public void CheckTypeZerosFromTimeAndCostInput()
        {
            steps.LoginInQuotex();
            steps.PushStockTransaction(new System.DateTime(2021, 1, 1, 0, 0, 0), 0, false);

            Assert.AreNotEqual(Utils.GetStandartValueForTest.GetZerosValueTimeAndCost(), steps.GetTimeAndCostOfStockTransaction());
        }

        [Test]
        public void test()
        {
            Assert.IsTrue(false);
        }
    }
}