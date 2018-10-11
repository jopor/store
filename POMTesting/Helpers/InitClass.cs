using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Store.PageObjects
{
    public class InitClass 
    {
        protected IWebDriver driver { get; private set; }

        [SetUp]
        public void Initialize()
        {
            SelectBrowser(BrowserType.Chrome);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://rekrutacjaqa2.xsolve.software/index.php?route=common/home");
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Dispose();
        }

        private void SelectBrowser(BrowserType browserType)
        {
            switch(browserType)
            {
                case BrowserType.Chrome:
                    ChromeOptions option = new ChromeOptions();
                    driver = new ChromeDriver(option);
                    break;
                case BrowserType.Firefox:
                    driver = new FirefoxDriver();
                    break;
                case BrowserType.IE:
                    break;
                default:
                    break;
            }
        }

        enum BrowserType
        {
            Chrome,
            Firefox,
            IE
        }
    }
}