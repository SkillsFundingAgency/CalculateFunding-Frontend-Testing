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
        private IWebDriver _driver;


        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {

        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {


            _driver.Navigate().GoToUrl("https://esfacfsftest-web.azurewebsites.net");
            var header = _driver.FindElement(By.Id("global-header"));
           // ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(@"shot.jpg", ScreenshotImageFormat.Jpeg);
            Assert.IsNotNull(header);
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {

        }

        [BeforeScenario()]
        public void BeforeScenario()
        {
            _driver = new PhantomJSDriver();
            _driver.Manage().Window.Maximize();
           _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [AfterScenario()]
        public void FixtureTearDown()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose();
            }
        }
    }
}
