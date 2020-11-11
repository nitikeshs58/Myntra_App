using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Configuration;
using System.Threading;

namespace Myntra_App.Pages
{
    public class AddToBag
    {
        private IWebDriver driver;
        public int explictWait = Int32.Parse(ConfigurationManager.AppSettings["timeInSeconds"]);

        public AddToBag(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);
        }

        /// <summary>
        /// Web Elements for myntra login
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//span[@class='myntraweb-sprite pdp-whiteBag sprites-whiteBag pdp-flex pdp-center']")]
        public IWebElement addToBagButton;
        
        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'GO TO BAG')]")]
        public IWebElement goToBagButton;
        
        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Place Order')]")]
        public IWebElement placeOrderButton;

        /// <summary>
        /// Add Tshirt to AddToBag
        /// </summary>
        public void AddToBagTshirtMethod()
        {
            Thread.Sleep(explictWait);
            addToBagButton.Click();
            Thread.Sleep(explictWait);
            goToBagButton.Click();
            placeOrderButton.Click();
            Thread.Sleep(explictWait);
        }
    }
}
