using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TestProject1;

namespace SeleniumTests
{
    [TestFixture]
    public class LogIn
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
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
        public void TheLogInTest()
        {
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(locators.loginButton).Click();
            driver.FindElement(locators.loginUsernameField).Click();
            driver.FindElement(locators.loginUsernameField).SendKeys("netko1231235");
            driver.FindElement(locators.loginPasswordField).Clear();
            driver.FindElement(locators.loginPasswordField).SendKeys("123123");
            driver.FindElement(locators.loginSubmitButton).Click();
        }
     
        }
    }
