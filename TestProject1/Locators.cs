using OpenQA.Selenium;

namespace TestProject1
{
    public class Locators
    {
        public By signIn2Button = By.Id("signin2");
        public By signInNameField = By.Id("sign-username");
        public By signInPasswordField = By.Id("sign-password");
        public By signInSubmitButton = By.XPath("//div[@id='signInModal']/div/div/div[3]/button[2]");

        public By PlaceOrderNameField = By.Id("name");
        public By PlaceOrderCountryField = By.Id("country");
        public By PlaceOrderCityField = By.Id("city");
        public By PlaceOrderCardField = By.Id("card");
        public By PlaceOrderMonthField = By.Id("month");
        public By PlaceOrderYearField = By.Id("year");
        public By PlaceOrderSubmitButton = By.XPath("//div[@id='orderModal']/div/div/div[3]/button[2]");
        public By PlaceOrderOkButton = By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Cancel'])[1]/following::button[1]");
        public By PlaceOrderDialogButton = By.XPath("//div[@id='page-wrapper']/div/div[2]/button");

        public By loginButton = By.Id("login2");
        public By loginUsernameField = By.Id("loginusername");
        public By loginPasswordField = By.Id("loginpassword");
        public By loginSubmitButton = By.XPath("//div[@id='logInModal']/div/div/div[3]/button[2]");

        public By contactButton = By.LinkText("Contact");
        public By contactEmailField = By.Id("recipient-email");
        public By contactNameField = By.Id("recipient-name");
        public By contactMessageField = By.Id("message-text");
        public By contactSubmitButton = By.XPath("//div[@id='exampleModal']/div/div/div[3]/button[2]");

        public By addToCardProduct = By.LinkText("Samsung galaxy s6");
        public By addToCardButton = By.LinkText("Add to cart");
        public By addToCardNavigateButtton = By.Id("cartur");
    }
}
