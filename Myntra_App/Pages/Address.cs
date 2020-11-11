using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Configuration;
using System.Threading;

namespace Myntra_App.Pages
{
    public class Address
    {
        private IWebDriver driver;
        public int explictWait = Int32.Parse(ConfigurationManager.AppSettings["timeInSeconds"]);

        public Address(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Web Elements for myntra login
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//input[@id='name']")]
        public IWebElement nameField;

        [FindsBy(How = How.XPath, Using = "//input[@id='mobile']")]
        public IWebElement mobileField;

        [FindsBy(How = How.XPath, Using = "//input[@id='pincode']")]
        public IWebElement pincodeField;

        [FindsBy(How = How.XPath, Using = "//input[@id='streetAddress']")]
        public IWebElement streetAddressField;

        [FindsBy(How = How.XPath, Using = "//input[@id='locality']")]
        public IWebElement localityField;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'ADD ADDRESS')]")]
        public IWebElement addAddressButton;

        /// <summary>
        /// Enter address
        /// </summary>
        public void EnterAddressMethod()
        {
            Thread.Sleep(explictWait);
            nameField.SendKeys(ConfigurationManager.AppSettings["name"]);
            Thread.Sleep(explictWait);
            mobileField.SendKeys(ConfigurationManager.AppSettings["mobile"]);
            Thread.Sleep(explictWait);
            pincodeField.SendKeys(ConfigurationManager.AppSettings["pincode"]);
            Thread.Sleep(explictWait);
            streetAddressField.SendKeys(ConfigurationManager.AppSettings["streetAddress"]);
            Thread.Sleep(explictWait);
            localityField.SendKeys(ConfigurationManager.AppSettings["locality"]);
            Thread.Sleep(explictWait);
            addAddressButton.Click();
            Thread.Sleep(explictWait);
        }
    }
}
