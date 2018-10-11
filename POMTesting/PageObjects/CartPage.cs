using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Store.PageObjects
{
    class CartPage
    {
        private IWebDriver driver;

        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".buttons .pull-right a")]
        private IWebElement checkoutButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "checkout-cart")]
        private IWebElement cartConent { get; set; }

        public CheckouPage clickOnCheckoutButton()
        {
            checkoutButton.Click();
            return new CheckouPage(driver);
        }

        public string getMessage()
        {
            return cartConent.Text.ToString();
        }
    }
}