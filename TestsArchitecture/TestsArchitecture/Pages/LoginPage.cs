using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestsArchitecture.Pages
{
    public class LoginPage
    {
        IWebDriver webDriver;
        By buttonToDemoAccount = By.XPath("//a[@class='main__platform-container__footer-demo']");

        public LoginPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        public MainPage TransitionToDemoAccount()
        {
            new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(3))
                   .Until(webDriver => webDriver.FindElement(buttonToDemoAccount)).Click();

            return new MainPage(webDriver);
        }
    }
}
