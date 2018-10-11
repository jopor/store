using FluentAssertions;
using NUnit.Framework;

namespace Store.PageObjects
{
    class TestCart : InitClass
    {
        [Test]
        public void ShouldSeeWarningMessageDuringCheckoutingOneProduct()
        {
            HomePage home = new HomePage(driver);
            home.addProductToChart();
            CartPage cart = home.goToCartPage();
            cart.clickOnCheckoutButton();
            cart.getMessage().Should().Contain("Minimum order amount for Test product 1 is 2!", "Invalid message");
        }
    }
}
