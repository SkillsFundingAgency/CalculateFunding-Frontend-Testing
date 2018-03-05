using System;
using System.Threading;
using AutoFramework;
using Frontend.IntegrationTests.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
//using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace Frontend.IntegrationTests
{
    [Binding]
    public class HomePageSteps

    {
        [Given(@"I have successfully navigated to the Home Page")]
        public void IhavesuccessfullynavigatedtotheHomePage()
        {
            Actions.InitializeHomePage();
            Thread.Sleep(1000);
        }

        [When(@"I select (.*)")]
        public void Iselect(string LinkOption)
        {
            //NavigateTo.ManagetheSpecfication();
            Driver._driver.FindElement(By.LinkText(LinkOption)).Click();
        }

        [Then(@"I am redirected to the Manage Specification page")]
        public void IamredirectedtotheManageSpecificationpage()
        {
            Thread.Sleep(1000);
            Assert.IsNotNull(new ManageSpecificationPage().SelectYear);
            ((ITakesScreenshot)Driver._driver).GetScreenshot().SaveAsFile(@"C:\Users\Richard\Documents\Work\ESFA Allocations\ESFA Selenium Screenshots\Manage Spec Screenshot.jpg", ScreenshotImageFormat.Jpeg);

        }


        [Then(@"I am redirected to the Manage Data page")]
        public void ThenIAmRedirectedToTheManageDataPage()
        {
            Thread.Sleep(1000);
            String currentURL = Driver._driver.Url;
            Assert.AreEqual("https://esfacfsftest-web.azurewebsites.net/datasets", currentURL);
            Assert.IsTrue(Driver._driver.Title.Equals("Manage Data - Calculate funding"));

        }

        [Then(@"I am redirected to the Manage Tests page")]
        public void ThenIAmRedirectedToTheManageTestsPage()
        {
            Thread.Sleep(1000);
            String currentURL = Driver._driver.Url;
            Assert.AreEqual("https://esfacfsftest-web.azurewebsites.net/tests/manage", currentURL);
            Assert.IsTrue(Driver._driver.Title.Equals("Manage the Tests - Calculate funding"));

        }

        [Then(@"I am redirected to the Manage Calculations page")]
        public void ThenIAmRedirectedToTheManageCalculationsPage()
        {
            Thread.Sleep(1000);
            String currentURL = Driver._driver.Url;
            Assert.AreEqual("https://esfacfsftest-web.azurewebsites.net/calcs", currentURL);

        }

        [Then(@"I am redirected to the View the Results page")]
        public void ThenIAmRedirectedToTheViewTheResultsPage()
        {
            Thread.Sleep(1000);
            String currentURL = Driver._driver.Url;
            Assert.AreEqual("https://esfacfsftest-web.azurewebsites.net/results/index", currentURL);
            Assert.IsTrue(Driver._driver.Title.Equals("View provider results - Calculate funding"));

        }

        [Then(@"I am redirected to the Publish the Results page")]
        public void ThenIAmRedirectedToThePublishTheResultsPage()
        {
            Thread.Sleep(1000);
            String currentURL = Driver._driver.Url;
            Assert.AreEqual("https://esfacfsftest-web.azurewebsites.net/results/publish", currentURL);
            Assert.IsTrue(Driver._driver.Title.Equals("Publish the Results - Calculate funding"));

        }

        [AfterScenario()]
        public void FixtureTearDown()
        {
            if (Driver._driver != null)
            {
                Driver._driver.Quit();
                Driver._driver.Dispose();
            }

        }
    }
}

