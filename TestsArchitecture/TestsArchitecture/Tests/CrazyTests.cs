using NUnit.Framework;
using OpenQA.Selenium;
using TestsArchitecture.Pages;
using TestsArchitecture.Utils;
using System.Threading;

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
            Thread.Sleep(1500);
        }

        [TearDown]
        public void Cleanup()
        {
            Utils.TestLogger.LogStat(TestContext.CurrentContext);
            Driver.DriverInstance.CloseBrowser();
            Thread.Sleep(1500);
        }

        [Test]
        public void PushCorrectStockTransactAndCheckInHistoryList()
        {
            steps.LoginInQuotex();
            steps.ChooseStockInSearch("AUD/CAD");
            steps.PushStockTransaction(new System.DateTime(2021, 1, 1, 0, 1, 0), 50, true);


            foreach (var item in steps.GetListItemsInHistoryList())
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

            TestContext.WriteLine(Utils.GetStandartValueForTest.GetZerosValueTimeAndCost());
            TestContext.WriteLine(steps.GetTimeAndCostOfStockTransaction());

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
            steps.ChooseStockInSearch("AUD/CAD");
            steps.PushStockTransaction(new System.DateTime(2021, 1, 1, 0, 1, 0), 50, true, 10);

            Assert.IsTrue(Utils.GetStandartValueForTest.GetMultiClickList().EqualListsOfItemInHistoryList(steps.GetListItemsInHistoryList()));
        }

        [Test]
        public void ChooseTwoMinutesTimeInDropoutList()
        {
            steps.LoginInQuotex();
            steps.ChooseTimeInTimeDropoutTabs(1);

            TestContext.WriteLine(steps.GetTimeAndCostOfStockTransaction().Time);
            Assert.AreEqual(steps.GetTimeAndCostOfStockTransaction().Time, "00:02:00");
        }

        [Test]
        public void ChooseFiveMinutesTimeInDropoutList()
        {
            steps.LoginInQuotex();
            steps.ChooseTimeInTimeDropoutTabs(4);

            Assert.AreEqual(steps.GetTimeAndCostOfStockTransaction().Time, "00:05:00");
        }

        [Test]
        public void ChooseStockInSearchList()
        {
            steps.LoginInQuotex();
            steps.ChooseStockInSearch("CAD/J");

            Assert.AreEqual(steps.GetCurrectStockName(), "CAD/JPY (OTC)");
        }

        [Test]
        public void ChooseStockInSearchListAndReturnToFirstStock()
        {
            steps.LoginInQuotex();
            steps.ChooseStockInSearch("CAD/J");
            steps.ChooseStockInTabList(0);

            Assert.AreNotEqual(steps.GetCurrectStockName(), "CAD/JPY (OTC)");
        }

        [Test]
        public void ChooseStockInSearchCryptoList()
        {
            steps.LoginInQuotex();
            steps.ChooseStockInSearchCrypto();

            Assert.AreNotEqual(steps.GetCurrectStockName(), "Ethereum");
        }

        [Test]
        public void CloseCurrectStockInTabList()
        {
            steps.LoginInQuotex();
            steps.ChooseStockInSearch("CAD/J");
            steps.CloseCurrectStockInTabList();

            Assert.AreNotEqual(steps.GetCurrectStockName(), "CAD/JPY (OTC)");
        }
    }
}