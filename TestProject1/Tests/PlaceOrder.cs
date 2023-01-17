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
    public class PlaceOrder
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
            locators = new Locators();

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
        public void ThePlaceOrderTest()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            AddToCard addToCard = new AddToCard(driver);
            addToCard.TheAddToCardTest();
            driver.FindElement(locators.PlaceOrderDialogButton).Click();

            wait.Until(ExpectedConditions.ElementExists(locators.PlaceOrderNameField));
            driver.FindElement(locators.PlaceOrderNameField).Click();
            driver.FindElement(locators.PlaceOrderNameField).SendKeys("123");
            driver.FindElement(locators.PlaceOrderCountryField).Click();
            driver.FindElement(locators.PlaceOrderCountryField).SendKeys("123");
            driver.FindElement(locators.PlaceOrderCityField).Click();
            driver.FindElement(locators.PlaceOrderCityField).SendKeys("123");
            driver.FindElement(locators.PlaceOrderCardField).Click();
            driver.FindElement(locators.PlaceOrderCardField).SendKeys("123");
            driver.FindElement(locators.PlaceOrderMonthField).Click();
            driver.FindElement(locators.PlaceOrderMonthField).SendKeys("123");
            driver.FindElement(locators.PlaceOrderYearField).Click();
            driver.FindElement(locators.PlaceOrderYearField).SendKeys("123");
            driver.FindElement(locators.PlaceOrderSubmitButton).Click();
            driver.FindElement(locators.PlaceOrderOkButton).Click();
            driver.Navigate().GoToUrl("https://www.demoblaze.com/index.html");
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        }
    }

