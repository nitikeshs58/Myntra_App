using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using Myntra_App.MailReport;
using Myntra_App.Screenshots;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;

namespace Myntra_App.MyntraBase
{
    [TestFixture]
    public class Base
    {
        public IWebDriver driver;
        public ExtentReports report = new ExtentReports();
        public ExtentTest extentTest;
        public static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [OneTimeSetUp]
        public void InitilizeMethod()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized", "--disable-notifications");
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(@"C:\Users\Nitikesh\source\repos\Myntra_App\Myntra_App\ExtentReports\MyntraReport.cs");
            report.AttachReporter(htmlReporter);
            driver = new ChromeDriver(options);
            log.Info("Navigating to login page");
            driver.Url =ConfigurationManager.AppSettings["myntraLoginUrl"];
        }

        [TearDown]
        public void CloseMethod()
        {
            extentTest = report.CreateTest(TestContext.CurrentContext.Test.Name);
            if(TestContext.CurrentContext.Result.Outcome.Status==TestStatus.Passed)
            {
                extentTest.Log(Status.Pass, "Test Passed");
                extentTest.AddScreenCaptureFromPath(TakeScreenshot.TakeScreenshotMethod(driver, TestContext.CurrentContext.Test.Name));
                extentTest.Pass(MarkupHelper.CreateLabel(TestContext.CurrentContext.Test.Name, ExtentColor.Green));
            }
            else if(TestContext.CurrentContext.Result.Outcome.Status==TestStatus.Failed)
            {
                extentTest.Log(Status.Fail, "Test Failed");
                extentTest.AddScreenCaptureFromPath(TakeScreenshot.TakeScreenshotMethod(driver, TestContext.CurrentContext.Test.Name));
                extentTest.Fail(MarkupHelper.CreateLabel(TestContext.CurrentContext.Test.Name, ExtentColor.Red));
            }

            // Closes all the connections to the extend reports
            report.Flush();
        }

        [OneTimeTearDown]
        public void TeardownMethod()
        {
            driver.Quit();
            SendMail.SendEmailMethod();
        }
    }
}
