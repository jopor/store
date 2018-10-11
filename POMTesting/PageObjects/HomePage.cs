using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Store.Helpers;

namespace Store.PageObjects
{
    class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            Wait.WaitForLoadedPage(driver);
        }

        [FindsBy(How = How.CssSelector, Using = ".product-thumb button>i.fa-shopping-cart")]
        private IWebElement addToCartButton { get; set; }
        [FindsBy(How = How.Id, Using = "cart-total")]
        private IWebElement cartButton { get; set; }

        public void addProductToChart()
        {
            addToCartButton.Click();      
        }

        public CartPage goToCartPage()
        {
            driver.Navigate().GoToUrl("https://rekrutacjaqa2.xsolve.software/index.php?route=checkout/cart");
            return new CartPage(driver);
        }

        public string getCartItemsAmount()
        {
            Wait.WaitForElementVisible(driver, cartButton);
            return cartButton.Text.ToString();
        }
    }
}