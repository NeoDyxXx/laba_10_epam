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

        public void PushStockTransaction(DateTime time, int cost, bool turnOnSleep = false)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.TypeCostFromTransaction(cost)
                .TypeTimeFromTransaction(time)
                .ClickToPushTransaction();

            if (turnOnSleep)
                Thread.Sleep(time.Hour * 1200000 + time.Minute * 60000 + time.Second + 5000);
        }

        public (string, string) GetTimeAndCostOfStockTransaction()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            return (mainPage.GetValueFromTimeInTransaction(), mainPage.GetValueFromCostInTransaction());
        }

        public void ChooseStockInList(string stockName)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.ClickToChooseStockButton()
                .InputValueInInputOfChooseStock(stockName)
                .ClickToChooseStockItem();
        }

        public List<Utils.ItemInHistoryList> GetListItemsInHistoryList()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            return mainPage.GetItemInHistoryLists();
        }
    }
}
