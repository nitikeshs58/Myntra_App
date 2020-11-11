using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Threading;


namespace Myntra_App.Pages
{
    public class SearchTshirt
    {
        private IWebDriver driver;
        public int explictWait = Int32.Parse(ConfigurationManager.AppSettings["timeInSeconds"]);

        public SearchTshirt(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);
        }

        /// <summary>
        /// Web Elements for to search Levis Tshirt
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//header/div[2]/div[3]/input[1]")]
        public IWebElement searchBox;
        
        [FindsBy(How = How.XPath, Using = "//span[@class='myntraweb-sprite desktop-iconSearch sprites-search']")]
        public IWebElement searchButton;

        [FindsBy(How = How.XPath, Using = "//p[@class='size-buttons-unified-size' and text()='M']")]
        public IWebElement size;
        
        /// <summary>
        /// Search for levis Tshirt
        /// Select 3rd t-shirt with Medium size
        /// </summary>
        public void SearchLevisTshirtMethod()
        {
            Thread.Sleep(explictWait);
            searchBox.SendKeys(ConfigurationManager.AppSettings["brandToSearch"]);
            Thread.Sleep(explictWait);
            searchButton.Click();
            Thread.Sleep(explictWait);
            IList<IWebElement> listOfTshirts = driver.FindElements(By.XPath("//li[@class='product-base']"));
            Thread.Sleep(explictWait);
            listOfTshirts[3].Click();
            Thread.Sleep(explictWait);
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            Thread.Sleep(explictWait);
            size.Click();
            Thread.Sleep(explictWait);
        }
    }
}
