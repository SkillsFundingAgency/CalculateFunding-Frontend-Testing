using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using AutoFramework;
using FluentAssertions;
using Frontend.IntegrationTests.Create;
using Frontend.IntegrationTests.Pages.Manage_Datasets;
using Frontend.IntegrationTests.Pages.Manage_Specification;
using Frontend.IntegrationTests.Pages.Quality_Assurance;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
//using OpenQA.Selenium.PhantomJS;
using TechTalk.SpecFlow;

namespace Frontend.IntegrationTests.Tests.Steps
{
    [Binding]
    public class QualityAssuranceTestsSteps
    {
        TestScenarioListPage testscenariolistpage = new TestScenarioListPage();


        [Then(@"a Search Tests funciton is displayed")]
        public void ThenASearchTestsFuncitonIsDisplayed()
        {
            testscenariolistpage.testScenarioPageSearchField.Displayed.Should().BeTrue();
            testscenariolistpage.testScenarioPageSearchButton.Should().NotBeNull();
            testscenariolistpage.testScenarioPageSearchButton.Displayed.Should().BeTrue();

        }
        
        [Then(@"an option to create a new QA Test is displayed")]
        public void ThenAnOptionToCreateANewQATestIsDisplayed()
        {
            testscenariolistpage.testScenarioPageCreateQATestButton.Should().NotBeNull();
            testscenariolistpage.testScenarioPageCreateQATestButton.Displayed.Should().BeTrue();
        }

        [Then(@"the list shows up to (.*) Test Scenarios")]
        public void ThenTheListShowsUpToTestScenarios(int totalpagecount)
        {
            IWebElement testscenarioLastResultCount = testscenariolistpage.testScenarioPageTotalResultCount;
            string testscenarioLastResult = testscenarioLastResultCount.Text;
            int totalpagescenariocount = int.Parse(testscenarioLastResult);
            totalpagescenariocount.Should().BeLessOrEqualTo(totalpagecount, "More than 50 Scenarios are displayed");
            Console.WriteLine("Test Scenario Page List Count is " + totalpagescenariocount);
        }

        [Then(@"the total Test Scenario Count is displayed")]
        public void ThenTheTotalTestScenarioCountIsDisplayed()
        {
            IWebElement testscenariototalresult = testscenariolistpage.testScenarioPageTotalResultCount;
            string testscenariototal = testscenariototalresult.Text;
            int totalscenariocount = int.Parse(testscenariototal);
            Console.WriteLine("Total Test Scenario Results is " + totalscenariocount);
        }


        [When(@"I have over (.*) Test Scenarios listed")]
        public void WhenIHaveOverTestScenariosListed(int totalpagecount)
        {
            IWebElement testscenarioLastResultCount = testscenariolistpage.testScenarioPageTotalResultCount;
            string testscenarioLastResult = testscenarioLastResultCount.Text;
            int totalpagescenariocount = int.Parse(testscenarioLastResult);
            totalpagescenariocount.Should().BeGreaterThan(totalpagecount, "Less than 50 Test Scenarios are displayed");
        }

        [When(@"I click to navigate to the next page of (.*) test scenarios")]
        public void WhenIClickToNavigateToTheNextPageOfTestScenarios(int p0)
        {
            Actions.PaginationSelectPage();
            Thread.Sleep(2000);
        }

        [Then(@"my test scenarios list view displays the next (.*) results")]
        public void ThenMyTestScenariosListViewDisplaysTheNextResults(int firstpagecount)
        {
            IWebElement testscenarioFirstResultCount = testscenariolistpage.testScenarioPageFirstResultCount;
            string testscenarioFirstResult = testscenarioFirstResultCount.Text;
            int firstpagescenariocount = int.Parse(testscenarioFirstResult);
            firstpagescenariocount.Should().BeGreaterThan(firstpagecount, "The Next list of Test Scenarios have not been are displayed correctly");
        }

        [Then(@"I am able to navigate to the previous page of (.*) test scenarios")]
        public void ThenIAmAbleToNavigateToThePreviousPageOfTestScenarios(int p0)
        {
            Actions.PaginationSelectPage();
            Thread.Sleep(2000);
        }


        [Then(@"the name of test scenario is displayed")]
        public void ThenTheNameOfTestScenarioIsDisplayed()
        {
            IWebElement testscenarioname = testscenariolistpage.testScenarioPageFirstTestScenarioName;
            string scenarioname = testscenarioname.Text;
            scenarioname.Should().NotBeNull();
            Console.WriteLine("First Test Scenario Name displayed is " + scenarioname);
        }

        [Then(@"the description of the test scenario is displayed")]
        public void ThenTheDescriptionOfTheTestScenarioIsDisplayed()
        {
            IWebElement testscenarioresultitemcontainer = testscenariolistpage.testScenarioPageFirstTestScenarioContainer;
            var propertyElements = testscenarioresultitemcontainer.FindElements(By.CssSelector("test-scenario-item-property-container"));
            List<IWebElement> propertyElementList = new List<IWebElement>(propertyElements);
            propertyElementList.Should().HaveCountGreaterThan(0, "Return elements expected");

           for (int i = 0; i < propertyElementList.Count; i++)
            {
                IWebElement currentElement = propertyElementList[i];
                currentElement.Should().NotBeNull("element {0} is null", i);

                IWebElement valueElement = currentElement.FindElement(By.TagName("span"));

                valueElement.Should().NotBeNull("value element {0} is null", i);
                valueElement.Text.Should().NotBeNullOrEmpty("value element {0} does not contain value", i);
                Console.WriteLine(currentElement.Text);
            }
        }

        [Then(@"the current status of the test scenario is displayed")]
        public void ThenTheCurrentStatusOfTheTestScenarioIsDisplayed()
        {

        }

        [Then(@"the specification that the test is associated with is displayed")]
        public void ThenTheSpecificationThatTheTestIsAssociatedWithIsDisplayed()
        {

        }

        [Then(@"the date time the test scenario was last updated is displayed")]
        public void ThenTheDateTimeTheTestScenarioWasLastUpdatedIsDisplayed()
        {

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
