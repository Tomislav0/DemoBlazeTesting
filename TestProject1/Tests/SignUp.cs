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
    public class SignUp
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
        public void TheSignUpTest()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            
            driver.Navigate().GoToUrl(baseURL);
            wait.Until(ExpectedConditions.ElementToBeClickable(locators.signIn2Button));
            driver.FindElement(locators.signIn2Button).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(locators.signInNameField));
            driver.FindElement(locators.signInNameField).Click();
            driver.FindElement(locators.signInNameField).SendKeys("netko123123822");
            driver.FindElement(locators.signInPasswordField).Click();
            driver.FindElement(locators.signInPasswordField).SendKeys("123123");
            driver.FindElement(locators.signInSubmitButton).Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            Assert.AreEqual("Sign up successful.", CloseAlertAndGetItsText());
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
