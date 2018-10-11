using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Store.PageObjects
{
    class GuestOrderTest : InitClass
    {
        [Test]
        public void ShouldOrderProductAsRegister()
        {
            HomePage home = new HomePage(driver);
            home.addProductToChart();
            home.addProductToChart();
            CartPage cart = home.goToCartPage();
            CheckouPage checkout = cart.clickOnCheckoutButton();

            checkout.checkRegisterAccount();
            checkout.finishStep1();

            checkout.setPersonalDetails();
            checkout.setPassword();
            checkout.checkPrivacyPolicy();
            checkout.setAddress();
            checkout.finishStep2AsRegister();

            checkout.finishStep3();

            checkout.finishStep4Guest();
            checkout.agreeTerms();

            checkout.finishStep5();

            SuccessPage success = checkout.confirmOrder();
            success.getMessage().Should().Contain("Your order has been placed!", "Invalid success message");
        }

        [Test]
        public void ShouldOrderProductAsGuest()
        {
            HomePage home = new HomePage(driver);
            home.addProductToChart();
            home.addProductToChart();
            CartPage cart = home.goToCartPage();
            CheckouPage checkout = cart.clickOnCheckoutButton();
            checkout.checkGuestCheckout();
            checkout.finishStep1();
            checkout.setPersonalDetails();
            checkout.setAddress();
            checkout.finishStep2AsGuest();
            checkout.finishStep4Guest();
            checkout.agreeTerms();
            checkout.finishStep5();
            SuccessPage success = checkout.confirmOrder();
            success.getMessage().Should().Contain("Your order has been placed!", "Invalid success message");
        }
    }
}
