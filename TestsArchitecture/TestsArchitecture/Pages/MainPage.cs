using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TestsArchitecture.Pages
{
    public class MainPage
    {
        IWebDriver webDriver;

        By buttonToHidePopup = By.XPath("//a[@class='button button--light button--small modal-byte__demo-button']");
        By changeSet = By.XPath("//input[@class='input-control__input opacity']");
        By demoFromChangeSet = By.XPath("//div[@class='input-control__dropdown']/div[2]");
        By inputOfCost = By.XPath("//div[@class='input-control-wrapper section-deal--black']/label/input[@class='input-control__input']");
        By inputOfTime = By.XPath("//div[@class='section-deal__time section-deal__input-black']/label/input[@class='input-control__input opacity']");
        By buttonToPushTransaction = By.XPath("//button[@class='button button--success button--spaced call-btn section-deal__button']");
        By elementsInHistoryList = By.XPath("//div[@class='trades__list']/div[@class='trades-list__item trades-list-item trades-list-item__close']");
        By currectStock = By.XPath("//div[@class='section-deal']/div[@class='section-deal__name']");
        By chooseStockButton = By.XPath("//button[@class='asset-select__button']");
        By chooseStockInput = By.XPath("//input[@class='asset-select__search-input']");
        By listOfChooseStock = By.XPath("//div[@class='assets-table']/div[@class='assets-table__item']");
        By listOfStockInTabs = By.XPath("//div[@class='tabs__items']/div[@class='tab desktop']");
        By listOfInputControlDropoutOption = By.XPath("//div[@class='input-control__dropdown']/div[@class='input-control__dropdown-option']");
        By currectStockName = By.XPath("//div[@class='section-deal__header']/div[@class='section-deal__name']");
        By activeStockInTabList = By.XPath("//div[@class='tabs__items']/div[@class='tab desktop active']");
        By buttonToResetSearchToCripto = By.XPath("//div[@class='asset-select__search-filters active']/button[@class='asset-select__search-filter '][text()='Криптовалюты']");

        public MainPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public MainPage HidePopup()
        {
            new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(3))
                .Until(webDriver => webDriver.FindElement(buttonToHidePopup)).Click();
            Thread.Sleep(2000);

            return this;
        }

        public MainPage ClickToChangeSet()
        {
            new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(3))
                    .Until(webDriver => webDriver.FindElement(changeSet)).Click();

            return this;
        }

        public MainPage ClickToDemoFromChangeSet()
        {
            new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(3))
                .Until(webDriver => webDriver.FindElement(demoFromChangeSet)).Click();

            return this;
        }

        public MainPage TypeCostFromTransaction(int cost)
        {
            IWebElement costElement = new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(3))
                    .Until(webDriver => webDriver.FindElement(inputOfCost));

            costElement.SendKeys(Keys.Backspace + Keys.Backspace + Keys.Backspace + Keys.Backspace + Keys.Backspace + Keys.Backspace);
            costElement.SendKeys(System.Convert.ToString(cost));

            return this;
        }

        public MainPage TypeTimeFromTransaction(DateTime time)
        {
            IWebElement costElement = new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(3))
                    .Until(webDriver => webDriver.FindElement(inputOfTime));

            costElement.SendKeys(Keys.Left + Keys.Left + Keys.Left + Keys.Left + Keys.Left + Keys.Left + Keys.Left + Keys.Left);
            costElement.SendKeys(String.Format("{0:d2}{1:d2}{2:d2}", time.Hour, time.Minute, time.Second));

            return this;
        }

        public MainPage TypeTimeFromTransaction(string time)
        {
            IWebElement costElement = new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(3))
                    .Until(webDriver => webDriver.FindElement(inputOfTime));

            costElement.SendKeys(Keys.Left + Keys.Left + Keys.Left + Keys.Left + Keys.Left + Keys.Left + Keys.Left + Keys.Left);
            costElement.SendKeys(time);

            return this;
        }

        public MainPage ClickToPushTransaction()
        {
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(3))
                    .Until(webDriver => webDriver.FindElement(buttonToPushTransaction))
                    .Click();

            return this;
        }

        public List<Utils.ItemInHistoryList> GetItemInHistoryLists()
        {
            List<IWebElement> arrayOfItemInHistoryList = new List<IWebElement>(new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(3))
                    .Until(webDriver => webDriver.FindElements(elementsInHistoryList)));

            return arrayOfItemInHistoryList.Select(item => new Utils.ItemInHistoryList()
            {
                NameOfStock = item.FindElement(By.ClassName("trades-list-item__name")).Text,
                TimeOfTrade = item.FindElement(By.ClassName("trades-list-item__countdown")).Text
            })
                .ToList();
        }

        public string GetCurrectNameOfStock()
        {
            return new WebDriverWait(webDriver, TimeSpan.FromSeconds(3))
                    .Until(webDriver => webDriver.FindElement(currectStock)).Text;
        }

        public string GetValueFromTimeInTransaction()
        {
            return new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(3))
                .Until(webDriver => webDriver.FindElement(inputOfTime)).GetAttribute("value").Trim();
        }

        public string GetValueFromCostInTransaction()
        {
            return new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(3))
                .Until(webDriver => webDriver.FindElement(inputOfCost)).GetAttribute("value").Trim().Split(" ")[0];
        }

        public MainPage ClickToChooseStockButton()
        {
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(3))
                    .Until(webDriver => webDriver.FindElement(chooseStockButton))
                    .Click();

            return this;
        }

        public MainPage InputValueInInputOfChooseStock(string value)
        {
            IWebElement input = new WebDriverWait(webDriver, TimeSpan.FromSeconds(3))
                    .Until(webDriver => webDriver.FindElement(chooseStockInput));
            input.Clear();
            input.SendKeys(value);

            return this;
        }

        public MainPage ClickToChooseStockItem()
        {
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(3))
                    .Until(webDriver => webDriver.FindElements(listOfChooseStock))[0].FindElement(By.ClassName("assets-table__name")).Click();

            return this;
        }

        public MainPage ClickToFirstElementInTabs(int index)
        {
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(3))
                    .Until(webDriver => webDriver.FindElements(listOfStockInTabs)[index]).Click();

            return this;
        }

        public MainPage ClickToInputTime()
        {
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(3))
                    .Until(webDriver => webDriver.FindElements(inputOfTime)[0]).Click();
            Thread.Sleep(500);

            return this;
        }

        public MainPage ClickToElementInTimeDropout(int index)
        {
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(3))
                    .Until(webDriver => webDriver.FindElements(listOfInputControlDropoutOption)[index]).Click();

            return this;
        }

        public string GetStockName()
        {
            return new WebDriverWait(webDriver, TimeSpan.FromSeconds(3))
                    .Until(webDriver => webDriver.FindElement(currectStockName)).Text;
        }

        public MainPage ClickToCloseButtonOfCurrectStock()
        {
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(3))
                    .Until(webDriver => webDriver.FindElement(activeStockInTabList)).FindElement(By.ClassName("tab__close")).Click();

            return this;
        }

        public MainPage ClickToButtonOfResetSearchToCripto()
        {
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(3))
                    .Until(webDriver => webDriver.FindElement(buttonToResetSearchToCripto)).Click();

            return this;
        }
    }
}
