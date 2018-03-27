using System;
using System.Globalization;
using System.Threading;
using AutoFramework;
using FluentAssertions;
using Frontend.IntegrationTests.Pages;
using Frontend.IntegrationTests.Pages.Manage_Calculation;
using Frontend.IntegrationTests.Pages.Manage_Datasets;
using Frontend.IntegrationTests.Pages.View_Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
//using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace Frontend.IntegrationTests
{
    [Binding]
    public class HomePageSteps

    {
        ManageSpecificationPage managespecificationpage = new ManageSpecificationPage();
        ManageTheDataPage managethedatapage = new ManageTheDataPage();
        ManageCalculationPage managecalculationpage = new ManageCalculationPage();
        ViewProviderResultsPage viewproviderresultspage = new ViewProviderResultsPage();

        [Given(@"I have successfully navigated to the Home Page")]
        public void IhavesuccessfullynavigatedtotheHomePage()
        {
            //Driver is initiated within the Feature Sceanrio
            Thread.Sleep(1000);
        }

        [When(@"I select (.*)")]
        public void Iselect(string LinkOption)
        {
            //NavigateTo.ManagetheSpecfication();
            Driver._driver.FindElement(By.LinkText(LinkOption)).Click();
            Thread.Sleep(2000);
        }

        [Then(@"I am redirected to the Manage Specification page")]
        public void IamredirectedtotheManageSpecificationpage()
        {
            Thread.Sleep(1000);
            managespecificationpage.CreateSpecification.Should().NotBeNull();
            
        }


        [Then(@"I am redirected to the Manage Data page")]
        public void ThenIAmRedirectedToTheManageDataPage()
        {
            Thread.Sleep(1000);
            managethedatapage.manageDataSetsLink.Should().NotBeNull();

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
            managecalculationpage.CalculationSearchField.Should().NotBeNull();

        }

        [Then(@"I am redirected to the View the Results page")]
        public void ThenIAmRedirectedToTheViewTheResultsPage()
        {
            Thread.Sleep(1000);
            viewproviderresultspage.providerResultspageSearch.Should().NotBeNull();

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

