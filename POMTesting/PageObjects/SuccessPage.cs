using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace Store.PageObjects
{
    class SuccessPage
    {
        private IWebDriver driver;

        public SuccessPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#common-success")));
        }

        [FindsBy(How = How.Id, Using = "content")]
        private IWebElement messageContent { get; set; }

        public string getMessage()
        {
            return messageContent.Text.ToString();
        }
    }
}