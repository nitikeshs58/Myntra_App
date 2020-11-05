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

        [Test]
        public void LoginTest()
        {
            log.Info("Login test Started.");
            Login login = new Login(driver);
            login.MyntraLoginMethod();
            Assert.AreEqual(driver.Title,expectedHomepageTitle);
            log.Info("SignIn test Ended.");
        }
    }
}
