using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestProject1;

namespace SeleniumTests
{
    [TestFixture]
    public class AddToCard
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        private Locators locators;
        public AddToCard() { }
        public AddToCard(IWebDriver driver) {
            this.driver = driver;
            baseURL = "https://www.demoblaze.com/";
            verificationErrors = new StringBuilder();
            this.locators = new Locators();
        }
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.demoblaze.com/";
            verificationErrors = new StringBuilder();
            this.locators = new Locators();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheAddToCardTest()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.Navigate().GoToUrl(baseURL);

            wait.Until(ExpectedConditions.ElementExists(locators.addToCardProduct));
            driver.FindElement(locators.addToCardProduct).Click();

            wait.Until(ExpectedConditions.ElementExists(locators.addToCardButton));
            driver.FindElement(locators.addToCardButton).Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            Assert.AreEqual("Product added", CloseAlertAndGetItsText());
            wait.Until(ExpectedConditions.ElementExists(locators.addToCardNavigateButtton));
            driver.FindElement(locators.addToCardNavigateButtton).Click();
        }      
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
