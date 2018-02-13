namespace AutoFramework
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using System;
    using System.Drawing.Imaging;
    using TechTalk.SpecFlow;

    [Binding]
    public static class Actions
    {
        [BeforeScenario (new string[] { "Driver" })]
        public static void InitializeHomePage()
        {
            Driver._driver = new FirefoxDriver();
            Driver._driver.Manage().Window.Maximize();
            Driver._driver.Navigate().GoToUrl(Config.BaseURL);
            Driver.WaitForElementUpTo(Config.ElementsWaitingTimeout);
        }

        public static void TakeScreenshot(this IWebDriver driver, string prefix)

        {
            var fileName = String.Format("{0}{1}{2}", prefix, DateTime.Now.ToString("HHmmss"), ".png");
            var screenShot = ((ITakesScreenshot)Driver._driver).GetScreenshot();
            screenShot.SaveAsFile(fileName, ScreenshotImageFormat.Png);
        }
    }

}
