using System;
using System.Threading;
using AutoFramework;
using FluentAssertions;
using Frontend.IntegrationTests.Pages;
using Frontend.IntegrationTests.Pages.Manage_Calculation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
//using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;

namespace Frontend.IntegrationTests.Tests.Steps
{
    [Binding]
    public class ManageCalculationsSteps
    {
        ManageCalculationPage managecalculationpage = new ManageCalculationPage();
        EditCalculationsPage editcalculationspage = new EditCalculationsPage();

        [Then(@"the page lists the most recent calculations")]
        public void ThenThePageListsTheMostRecentCalculations()
        {
            Assert.IsNotNull(managecalculationpage.CalculationResultsList);
        }

        [Given(@"I have navigated to the Manage Calculations page")]
        public void GivenIHaveNavigatedToTheManageCalculationsPage()
        {
            NavigateTo.ManagetheCalculation();
            Assert.IsNotNull(managecalculationpage.CalculationSearchField);
            Thread.Sleep(3000);
        }

        [When(@"I click on a calculation in the list")]
        public void WhenIClickOnACalculationInTheList()
        {
            Assert.IsNotNull(managecalculationpage.FirstCalculationListed);
            managecalculationpage.FirstCalculationListed.Click();
        }

        [Then(@"I am navigated to the Edit Calculation screen")]
        public void ThenIAmNavigatedToTheEditCalculationScreen()
        {
            Assert.IsNotNull(editcalculationspage.BuildCalculationButton);
        }


        [When(@"there is greater than (.*) calculations")]
        public void WhenThereIsGreaterThanCalculations(int NoOfCalcs)
        {
            Thread.Sleep(2000);
            Assert.IsNotNull(managecalculationpage.CalculationsPageTotal);
            Assert.IsNotNull(managecalculationpage.CalculationsTotalResults);

            IWebElement CalculationTotal = Driver._driver.FindElement(By.XPath("/html/body/main/div/div/div[3]/div[1]/div[2]/strong"));
            string CalculationTotalValue = CalculationTotal.Text;
            int CalculationTotalNo = int.Parse(CalculationTotalValue);
            //Fluent Assertions
            CalculationTotalNo.Should().BeGreaterThan(NoOfCalcs, "Less than 50 Calculations Displayed");
            Thread.Sleep(2000);


        }

        [Then(@"The the correct pagination options are displayed")]
        public void ThenTheTheCorrectPaginationOptionsAreDisplayed()
        {
            Assert.IsNotNull(managecalculationpage.CalculationsPaginationPage2);
            Assert.IsNotNull(managecalculationpage.CalculationsPaginationPage3);
            Assert.IsNotNull(managecalculationpage.CalculationsPaginationPage4);

        }

        [When(@"I click a pagination option")]
        public void WhenIClickAPaginationOption()
        {
            managecalculationpage.CalculationsPaginationPage2.Click();
            Thread.Sleep(2000);
            Assert.IsNotNull(managecalculationpage.CalculationsFirstResult);
        }

        [Then(@"My list refreshes to display the selected page of calculations")]
        public void ThenMyListRefreshesToDisplayTheSelectedPageOfCalculations()
        {
            IWebElement FirstPageResult = Driver._driver.FindElement(By.XPath("/html/body/main/div/div/div[3]/div[1]/div[2]/span[1]"));
            string FirstCalculationValue = FirstPageResult.Text;
            int CalculationPageFirstNo = int.Parse(FirstCalculationValue);
            //Fluent Assertions
            CalculationPageFirstNo.Should().BeGreaterThan(50, "Next 50 Calculations Failed To Displayed");
            Thread.Sleep(2000);
        }

        [Then(@"I am presented a filter option to select ONE or MORE Year")]
        public void ThenIAmPresentedAFilterOptionToSelectONEOrMOREYear()
        {
            Assert.IsNotNull(managecalculationpage.AcademicYearDropDown);
        }

        [Then(@"I am presented a filter option to select ONE or MORE calculation status")]
        public void ThenIAmPresentedAFilterOptionToSelectONEOrMORECalculationStatus()
        {
            Assert.IsNotNull(managecalculationpage.CalculationStatusDropDown);
        }

        [Then(@"I am presented a filter option to select ONE or MORE funding stream\(s\)")]
        public void ThenIAmPresentedAFilterOptionToSelectONEOrMOREFundingStreamS()
        {
            Assert.IsNotNull(managecalculationpage.FundingStreamDropDown);
        }

        [Then(@"I am presented a filter option to select ONE or MORE policy")]
        public void ThenIAmPresentedAFilterOptionToSelectONEOrMOREPolicy()
        {
            Assert.IsNotNull(managecalculationpage.SpecificationsDropDown);
        }

        [Then(@"I am presented a filter option to select ONE or MORE allocation lines")]
        public void ThenIAmPresentedAFilterOptionToSelectONEOrMOREAllocationLines()
        {
            Assert.IsNotNull(managecalculationpage.AllocationDropDown);
        }

        [Then(@"the filters are defaulted to show all calculations that are specified")]
        public void ThenTheFiltersAreDefaultedToShowAllCalculationsThatAreSpecified()
        {
            managecalculationpage.SpecNameDropDownDefault.Should().Equals("Select specification name");
            managecalculationpage.AllocationLineDropDownDefault.Should().Equals("Select Allocation Line");
            managecalculationpage.AcademicYearDropDownDefault.Should().Equals("Select year");
            managecalculationpage.FundingStreamDropDownDefault.Should().Equals("Select funding stream");
            managecalculationpage.CalculationStatusDropDownDefault.Should().Equals("Show all status");
            Thread.Sleep(2000);
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
