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
        }

        [Test]
        public void PushCorrectStockTransactAndCheckInHistoryList()
        {
            steps.LoginInQuotex();
            steps.ChooseStockInList("AUD/CAD");
            steps.PushStockTransaction(new System.DateTime(2021, 1, 1, 0, 1, 0), 50, true);

            
            foreach(var item in steps.GetListItemsInHistoryList())
            {
                TestContext.WriteLine(item);
            }
            Assert.IsTrue(Utils.GetStandartValueForTest.GetCorrectList().EqualListsOfItemInHistoryList(steps.GetListItemsInHistoryList()));
        }

        [Test]
        public void CheckTypeZerosFromTimeAndCostInput()
        {
            steps.LoginInQuotex();
            steps.PushStockTransaction(new System.DateTime(2021, 1, 1, 0, 0, 0), 0, false);

            Assert.AreNotEqual(Utils.GetStandartValueForTest.GetZerosValueTimeAndCost().Time, steps.GetTimeAndCostOfStockTransaction().Time);
            Assert.AreNotEqual(Utils.GetStandartValueForTest.GetZerosValueTimeAndCost().Cost, steps.GetTimeAndCostOfStockTransaction().Cost);
        }

        [Test]
        public void CheckTypeNegativeValueForCostAndNotCorrectForTime()
        {
            steps.LoginInQuotex();
            steps.PushStockTransaction(Utils.GetStandartValueForTest.GetNegativeValueFromCostAndNotCorrectFromTime().Time,
                System.Convert.ToInt32(Utils.GetStandartValueForTest.GetNegativeValueFromCostAndNotCorrectFromTime().Cost));

            Assert.AreNotEqual(Utils.GetStandartValueForTest.GetNegativeValueFromCostAndNotCorrectFromTime().Time, steps.GetTimeAndCostOfStockTransaction().Time);
            Assert.AreNotEqual(Utils.GetStandartValueForTest.GetNegativeValueFromCostAndNotCorrectFromTime().Cost, steps.GetTimeAndCostOfStockTransaction().Cost);
        }

        [Test]
        public void MultiPushStockTransaction()
        {
            steps.LoginInQuotex();
            steps.ChooseStockInList("AUD/CAD");
            steps.PushStockTransaction(new System.DateTime(2021, 1, 1, 0, 1, 0), 50, true, 10);

            Assert.IsTrue(Utils.GetStandartValueForTest.GetMultiClickList().EqualListsOfItemInHistoryList(steps.GetListItemsInHistoryList()));
        }
    }
}