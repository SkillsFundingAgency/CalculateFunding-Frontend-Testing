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
using Frontend.IntegrationTests.Pages.Quality_Assurance;
using Frontend.IntegrationTests.Pages.Home_Page;
using System.Linq;

namespace Frontend.IntegrationTests
{
    [Binding]
    public class HomePageSteps

    {
        ManageSpecificationPage managespecificationpage = new ManageSpecificationPage();
        ManageTheDataPage managethedatapage = new ManageTheDataPage();
        ManageCalculationPage managecalculationpage = new ManageCalculationPage();
        ViewProviderResultsPage viewproviderresultspage = new ViewProviderResultsPage();
        ViewResultsOptionsPage viewresultsoptionspage = new ViewResultsOptionsPage();
        TestScenarioListPage testscenariolistpage = new TestScenarioListPage();
        ApprovalOptionsPage approvaloptionspage = new ApprovalOptionsPage();
        HomePage homepage = new HomePage();

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
            testscenariolistpage.testScenarioPageCreateQATestButton.Should().NotBeNull();

        }

        [Then(@"I am redirected to the Manage Calculations page")]
        public void ThenIAmRedirectedToTheManageCalculationsPage()
        {
            Thread.Sleep(1000);
            managecalculationpage.CalculationSearchField.Should().NotBeNull();

        }

        [Then(@"I am redirected to the View the Results Options page")]
        public void ThenIAmRedirectedToTheViewTheResultsOptionsPage()
        {
            Thread.Sleep(1000);
            viewresultsoptionspage.viewResultsOptionsViewCalculationResults.Should().NotBeNull();
        }


        [Then(@"I am redirected to the approval options page")]
        public void ThenIAmRedirectedToTheApprovalOptionsPage()
        {
            approvaloptionspage.PageTitle.Should().NotBeNull();
            string pagetitle = approvaloptionspage.PageTitle.Text;
            Console.WriteLine(pagetitle);
        }

        [Then(@"an option to select to Choose funding specification is displayed")]
        public void ThenAnOptionToSelectToChooseFundingSpecificationIsDisplayed()
        {
            IWebElement fundingLink = approvaloptionspage.ChooseFundingSpecification;
            fundingLink.Should().NotBeNull();
            string linkText = fundingLink.Text;
            Console.WriteLine("Link Text displayed is: " + linkText);
        }

        [Then(@"an option to select to Approve and publish funding is displayed")]
        public void ThenAnOptionToSelectToApproveAndPublishFundingIsDisplayed()
        {
            IWebElement approvePublishLink = approvaloptionspage.ApprovePublishFunding;
            approvePublishLink.Should().NotBeNull();
            string linkText = approvePublishLink.Text;
            Console.WriteLine("Link Text displayed is: " + linkText);
        }

        [Then(@"The Survey Text is displayed correctly on the page")]
        public void ThenTheSurveyTextIsDisplayedCorrectlyOnThePage()
        {
            IWebElement surveyText = homepage.SurveyText;
            surveyText.Should().NotBeNull();
            string survey = surveyText.Text;
            Console.WriteLine("The displayed Survey Text is: " + survey);
        }

        [Then(@"the link to the Survey form is displayed correctly")]
        public void ThenTheLinkToTheSurveyFormIsDisplayedCorrectly()
        {
            IWebElement surveyLink = homepage.SurveyLink;
            surveyLink.Should().NotBeNull();
            string linkText = surveyLink.Text;
            Console.WriteLine("The displayed Survey Link Text is: " + linkText);
        }

        [Then(@"the Link loads the correct Survey page")]
        public void ThenTheLinkLoadsTheCorrectSurveyPage()
        {
            homepage.SurveyLink.Click();
            Thread.Sleep(2000);
            Driver._driver.SwitchTo().Window(Driver._driver.WindowHandles.Last());
            string currentURL = Driver._driver.Url;
            currentURL.Should().Be("https://www.smartsurvey.co.uk/s/cfsbeta/", "Surveyr URL was not loaded correctly");
        }

        [When(@"I update the URL to an incorrect end point")]
        public void WhenIUpdateTheURLToAnIncorrectEndPoint()
        {
            Driver._driver.Navigate().GoToUrl("https://esfacfsftest-web.azurewebsites.net/spec");
            Thread.Sleep(2000);
        }

        [Then(@"a Page Not Found error message is played")]
        public void ThenAPageNotFoundErrorMessageIsPlayed()
        {
            string currentURL = Driver._driver.Url;
            currentURL.Should().Be("https://esfacfsftest-web.azurewebsites.net/errors/404", "Page Not Found Error page was not returned");
            IWebElement pageNotFoundError = Driver._driver.FindElement(By.CssSelector(".heading-large"));
            string errorText = pageNotFoundError.Text;
            Console.WriteLine("Error displayed: " + errorText);

        }

        [Then(@"a link is displayed to return to the Home page")]
        public void ThenALinkIsDisplayedToReturnToTheHomePage()
        {
            IWebElement homePageLink = Driver._driver.FindElement(By.LinkText("visit the Calculate funding home page."));
            homePageLink.Should().NotBeNull();
        }

        [Then(@"a link is displayed to log a Service Desk Incident")]
        public void ThenALinkIsDisplayedToLogAServiceDeskIncident()
        {
            IWebElement logIncidentLink = Driver._driver.FindElement(By.LinkText("Log an incident"));
            logIncidentLink.Should().NotBeNull();
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

