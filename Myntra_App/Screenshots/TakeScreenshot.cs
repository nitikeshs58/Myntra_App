using Myntra_App.ExceptionHandling;
using OpenQA.Selenium;
using System;
using System.Text;

namespace Myntra_App.Screenshots
{
    public class TakeScreenshot
    {
        /// <summary>
        /// Static method to capture screenshot and saving that to path location
        /// Calling TakesScreenshotWithDate method and getting date and time for Screenshot name
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="testName"></param>
        /// <returns></returns>
        public static string TakeScreenshotMethod(IWebDriver driver, string testName)
        {
            try
            {
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                string screenshotPath = @"C:\Users\Nitikesh\source\repos\Myntra_App\Myntra_App\Screenshots\" + testName + "_Screenshot_" + TakesScreenshotWithDate() + ".png";
                ss.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
                return screenshotPath;
            }
            catch (Exception)
            {
                throw new CustomException("Error in screentshot", CustomException.ExceptionType.SCREENSHOT_NOT_CAPTURED);
            }

        }

        //Updates the number of screenshots that we took during the execution and provides name to taken screenshot
        public static StringBuilder TakesScreenshotWithDate()
        {
            try
            {
                StringBuilder TimeAndDate = new StringBuilder(DateTime.Now.ToString());
                TimeAndDate.Replace("/", "_");
                TimeAndDate.Replace(":", "_");
                return TimeAndDate;
            }
            catch (Exception)
            {
                throw new CustomException("Error in Date and Time", CustomException.ExceptionType.TIME_AND_DATE_NOT_FOUND);
            }
        }
    }
}
