using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Store.Helpers;
using System;

namespace Store.PageObjects
{
    class CheckouPage : Randomizer
    {
        private IWebDriver driver;

        public CheckouPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            WaitFor(driver, "div#collapse-checkout-option input");
        }

        #region Step 1: Checkout Options 

        [FindsBy(How = How.CssSelector, Using = "input[value=guest]")]
        private IWebElement guestRadioButton { get; set; }

        public void checkGuestCheckout()
        {
            guestRadioButton.Click();
        }

        [FindsBy(How = How.CssSelector, Using = "input[value=register]")]
        private IWebElement registerRadioButton { get; set; }

        public void checkRegisterAccount()
        {
            registerRadioButton.Click();
        }

        [FindsBy(How = How.Id, Using = "button-account")]
        private IWebElement continueButton { get; set; }

        public void finishStep1()
        {
            continueButton.Click();
            WaitFor(driver, "div#collapse-payment-address .row");
        }

        #endregion Checkout Options

        #region Step 2: Billing Details  

        #region Personal Details

        [FindsBy(How = How.Id, Using = "input-payment-firstname")]
        private IWebElement firstNameInput { get; set; }
        [FindsBy(How = How.Id, Using = "input-payment-lastname")]
        private IWebElement lastNameInput { get; set; }
        [FindsBy(How = How.Id, Using = "input-payment-email")]
        private IWebElement emailInput { get; set; }
        [FindsBy(How = How.Id, Using = "input-payment-telephone")]
        private IWebElement telephoneInput { get; set; }

        public void setPersonalDetails()
        {
            firstNameInput.SendKeys(generateFirstName());
            lastNameInput.SendKeys(generateLastName());
            emailInput.SendKeys(generateEmail());
            telephoneInput.SendKeys(generatePhone());
        }

        #endregion Personal Details

        #region Password (For Register)

        [FindsBy(How = How.Id, Using = "input-payment-password")]
        private IWebElement passwordInput { get; set; }
        [FindsBy(How = How.Id, Using = "input-payment-confirm")]
        private IWebElement confirmPasswordInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div#collapse-payment-address input[name=agree]")]
        private IWebElement privacyPolicyCheckbox { get; set; }

        [FindsBy(How = How.Id, Using = "button-register")]
        private IWebElement continueAsRegisterButton { get; set; }

        [FindsBy(How = How.Id, Using = "button-payment-address")]
        private IWebElement continueAsRegiste2rButton { get; set; }

        public void setPassword()
        {
            var password = generatePassword();
            passwordInput.SendKeys(password);
            confirmPasswordInput.SendKeys(password);
        }

        public void checkPrivacyPolicy()
        {
            if (privacyPolicyCheckbox.GetAttribute("checked") != "checked")
            {
                privacyPolicyCheckbox.Click();
            }
        }

        public void finishStep2AsRegister()
        {
            Wait.WaitForElementVisible(driver, continueAsRegisterButton);
            continueAsRegisterButton.Click();
        }

        #endregion Password (For Register)

        #region Address

        [FindsBy(How = How.Id, Using = "input-payment-company")]
        private IWebElement companyInput { get; set; }
        [FindsBy(How = How.Id, Using = "input-payment-address-1")]
        private IWebElement address1Input { get; set; }
        [FindsBy(How = How.Id, Using = "input-payment-address-2")]
        private IWebElement address2Input { get; set; }
        [FindsBy(How = How.Id, Using = "input-payment-city")]
        private IWebElement cityInput { get; set; }
        [FindsBy(How = How.Id, Using = "input-payment-postcode")]
        private IWebElement postcodeInput { get; set; }
        [FindsBy(How = How.Id, Using = "input-payment-country")]
        private IWebElement countryDropdown { get; set; }
        [FindsBy(How = How.Id, Using = "input-payment-zone")]
        private IWebElement regionDropdown { get; set; }

        [FindsBy(How = How.Name, Using = "shipping_address")]
        private IWebElement deliveryAndBilingAddressesCheckbox { get; set; }
        [FindsBy(How = How.Id, Using = "button-guest")]
        private IWebElement continueAsGuestButton { get; set; }

        public void setAddress()
        {
            companyInput.SendKeys(generateCompany());
            address1Input.SendKeys(generateAddress());
            address2Input.SendKeys(generateAddress());
            cityInput.SendKeys(generateCity());
            postcodeInput.SendKeys(generateCountryCode());
            select(countryDropdown, "Poland");
            select(regionDropdown, "Slaskie");
        }

        public void checkTheSameAddressForDeliveryAndBiling()
        {
            if(deliveryAndBilingAddressesCheckbox.GetAttribute("checked") != "checked")
            {
                deliveryAndBilingAddressesCheckbox.Click();
            }
        }

        public void finishStep2AsGuest()
        {
            continueAsGuestButton.Click();
            WaitFor(driver, "div#collapse-shipping-method input");
        }

        #endregion Address

        #endregion Step 2: Billing Details 

        #region Step 3: Delivery Details  

        [FindsBy(How = How.Id, Using = "button-shipping-address")]
        private IWebElement continue3Button { get; set; }

        public void finishStep3()
        {
            Wait.WaitForElementVisible(driver, continue3Button);
            continue3Button.Click();
            WaitFor(driver, "div#collapse-shipping-method input");
        }

        #endregion Step 3: Delivery Details 

        #region Step 4: Delivery Method 

        [FindsBy(How = How.Id, Using = "button-shipping-method")]
        private IWebElement continue4Button { get; set; }

        public void finishStep4Guest()
        {
            continue4Button.Click();
            WaitFor(driver, "div#collapse-payment-method input");
        }

        #endregion Step 4: Delivery Method 

        #region Step 5: Payment Method 

        [FindsBy(How = How.Name, Using = "agree")]
        private IWebElement agreeTermsCheckbox { get; set; }
        [FindsBy(How = How.Id, Using = "button-payment-method")]
        private IWebElement continue5Button { get; set; }

        public void agreeTerms()
        {
            agreeTermsCheckbox.Click();
        }

        public void finishStep5()
        {
            continue5Button.Click();
            WaitFor(driver, "div#collapse-checkout-confirm input");
        }

        #endregion Step 5: Payment Method 

        #region Step 6: Confirm Order 

        [FindsBy(How = How.Id, Using = "button-confirm")]
        private IWebElement confirmOrderButton { get; set; }

        public SuccessPage confirmOrder()
        {
            confirmOrderButton.Click();
            return new SuccessPage(driver); 
        }

        #endregion Step 6: Confirm Order 

        private void select(IWebElement element, string option)
        {
            SelectElement dropdown = new SelectElement(element);
            dropdown.SelectByText(option);
        }

        private static void WaitFor(IWebDriver driver, string locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(locator)));
        }
    }
}