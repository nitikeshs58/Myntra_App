using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Configuration;
using System.Threading;

namespace Myntra_App.Pages
{
    public class Login
    {
        public IWebDriver driver;
        public int explictWait = Int32.Parse(ConfigurationManager.AppSettings["timeInSeconds"]);

        public Login(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);
        }

        /// <summary>
        /// Web Elements for myntra login
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//input[@id='mobileNumberPass']")]
        public IWebElement mobileNumber;

        [FindsBy(How = How.XPath, Using = "//input[@id='']")]
        public IWebElement password;

        [FindsBy(How = How.XPath, Using = "//button[@class='btn primary  lg block submitButton']")]
        public IWebElement loginButton;

        /// <summary>
        /// To login to Myntra shopping 
        /// Used Data driven for login credencials
        /// </summary>
        public string MyntraLoginMethod()
        {
            Thread.Sleep(explictWait);
            mobileNumber.SendKeys(ConfigurationManager.AppSettings["mobileNumber"]);
            Thread.Sleep(explictWait);
            password.SendKeys(ConfigurationManager.AppSettings["password"]);
            Thread.Sleep(explictWait);
            loginButton.Click();
            Thread.Sleep(explictWait);
            return driver.Title;
        }
    }
}
