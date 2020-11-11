using Myntra_App.MyntraBase;
using Myntra_App.Pages;
using NUnit.Framework;
using System.Configuration;

namespace Myntra_App.TestScenarios
{
    [TestFixture]
    public class Test : Base
    {
        public string expectedHomepageTitle = ConfigurationManager.AppSettings["validateHomepageTitle"];        

        [Test,Order(1)]
        public void LoginTest()
        {
            log.Info("Login test Started.");
            Login login = new Login(driver);
            string actualTitle = login.MyntraLoginMethod();
            actualTitle.Contains(expectedHomepageTitle);
            log.Info("SignIn test Ended.");
        }

        [Test, Order(2)]
        public void SearchTShirtTest()
        {
            log.Info("Search Tshirt test Started.");
            SearchTshirt search = new SearchTshirt(driver);
            search.SearchLevisTshirtMethod();
            log.Info("Search Tshirt test Ended.");
        }

        [Test, Order(3)]
        public void AddToBagTest()
        {
            log.Info("AddToBag test Started.");
            AddToBag add = new AddToBag(driver);
            add.AddToBagTshirtMethod();
            log.Info("AddToBag Tshirt test Ended.");
        }

        [Test, Order(4)]
        public void AddressTest()
        {
            log.Info("Address test Started.");
            Address add = new Address(driver);
            add.EnterAddressMethod();
            log.Info("Address test Ended.");
        }
    }
}
