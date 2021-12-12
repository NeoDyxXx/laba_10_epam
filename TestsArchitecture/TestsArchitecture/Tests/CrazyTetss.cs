using NUnit.Framework;
using OpenQA.Selenium;

namespace TestsArchitecture
{
    public class Tests
    {
        private IWebDriver webDriver;

        [SetUp]
        public void Init()
        {
            webDriver = Driver.DriverInstance.GetInstance();
        }

        [TearDown]
        public void Cleanup()
        {
            Driver.DriverInstance.CloseBrowser();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            Assert.Pass();
        }
    }
}