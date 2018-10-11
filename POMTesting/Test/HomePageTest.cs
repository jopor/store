using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Store.PageObjects
{
    class HomePageTest : InitClass
    {
        [Test]
        public void ShouldDisplayMessageAboutOneProductOnCart()
        {
            HomePage home = new HomePage(driver);
            home.addProductToChart();
            home.getCartItemsAmount().Should().Contain("1 item(s)", "Invalid cart items amount");
          //  Assert.IsTrue(home.getCartItemsAmount().StartsWith("2 item(s)"));
        }
    }
}
