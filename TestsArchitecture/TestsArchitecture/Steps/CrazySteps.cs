using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TestsArchitecture.Steps
{
    public class CrazySteps
    {
        private IWebDriver driver;

        public void InitBrowser()
        {
            driver = Driver.DriverInstance.GetInstance();
        }

        public void CloseBrowser()
        {
            Driver.DriverInstance.CloseBrowser();
        }

        public void LoginInQuotex()
        {
            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            loginPage.TransitionToDemoAccount()
                .HidePopup()
                .ClickToChangeSet()
                .ClickToDemoFromChangeSet();
        }

        public void PushStockTransaction(DateTime time, int cost, bool turnOnSleep = false, int count = 1)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.TypeCostFromTransaction(cost)
                .TypeTimeFromTransaction(time);

            for (int i = 0; i < count; i++)
            {
                mainPage.ClickToPushTransaction();
            }

            if (turnOnSleep)
                Thread.Sleep(time.Hour * 1200000 + time.Minute * 60000 + time.Second + 5000);
        }

        public void PushStockTransaction(string time, int cost)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.TypeCostFromTransaction(cost)
                .TypeTimeFromTransaction(time)
                .ClickToPushTransaction();
        }

        public (string Time, string Cost) GetTimeAndCostOfStockTransaction()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            Thread.Sleep(500);
            return (mainPage.GetValueFromTimeInTransaction(), mainPage.GetValueFromCostInTransaction());
        }

        public void ChooseStockInSearch(string stockName)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.ClickToChooseStockButton()
                .InputValueInInputOfChooseStock(stockName)
                .ClickToChooseStockItem();
        }

        public void ChooseStockInSearchCrypto()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.ClickToChooseStockButton()
                .ClickToButtonOfResetSearchToCripto()
                .ClickToChooseStockItem();
        }

        public void CloseCurrectStockInTabList()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.ClickToCloseButtonOfCurrectStock();
        }

        public void ChooseStockInTabList(int indexOfTabList)
        {

            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.ClickToFirstElementInTabs(indexOfTabList);
        }

        public List<Utils.ItemInHistoryList> GetListItemsInHistoryList()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            return mainPage.GetItemInHistoryLists();
        }

        public void ChooseTimeInTimeDropoutTabs(int indexOfTabs)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.ClickToInputTime().ClickToElementInTimeDropout(indexOfTabs);
        }

        public string GetCurrectStockName()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            return mainPage.GetStockName();
        }
    }
}
