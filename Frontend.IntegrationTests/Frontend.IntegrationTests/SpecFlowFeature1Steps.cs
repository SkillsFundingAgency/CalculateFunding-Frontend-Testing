using System;
using System.Drawing.Imaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using TechTalk.SpecFlow;

namespace Frontend.IntegrationTests
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {

        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            var driver = new PhantomJSDriver();
            driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().ImplicitWait(TimeSpan.FromSeconds(30));
            driver.Navigate().GoToUrl("https://esfacfsftest-web.azurewebsites.net");
            var header = driver.FindElementById("global-header");
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(@"shot.jpg", ScreenshotImageFormat.Jpeg);
            Assert.IsNotNull(header);
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {

        }
    }
}
