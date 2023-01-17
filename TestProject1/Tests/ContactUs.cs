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
    public class ContactUs
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        private Locators locators;

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
        public void TheContactUsTest()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(locators.contactButton).Click();
            driver.FindElement(locators.contactEmailField).Click();
            driver.FindElement(locators.contactEmailField).SendKeys("netko@netko.com");
            driver.FindElement(locators.contactNameField).Click();
            driver.FindElement(locators.contactNameField).SendKeys("Netko");
            driver.FindElement(locators.contactMessageField).Click();
            driver.FindElement(locators.contactMessageField).SendKeys("Neka poruka");
            driver.FindElement(locators.contactSubmitButton).Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            Assert.AreEqual("Thanks for the message!!", CloseAlertAndGetItsText());
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
