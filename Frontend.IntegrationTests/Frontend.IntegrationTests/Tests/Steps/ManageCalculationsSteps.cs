using System;
using System.Collections.Generic;
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

        [Given(@"the filters are defaulted to show all calculations that are specified")]
        public void GivenTheFiltersAreDefaultedToShowAllCalculationsThatAreSpecified()
        {
            managecalculationpage.SpecNameDropDownDefault.Should().Equals("Select specification name");
            managecalculationpage.AllocationLineDropDownDefault.Should().Equals("Select Allocation Line");
            managecalculationpage.AcademicYearDropDownDefault.Should().Equals("Select year");
            managecalculationpage.FundingStreamDropDownDefault.Should().Equals("Select funding stream");
            managecalculationpage.CalculationStatusDropDownDefault.Should().Equals("Show all status");
            Thread.Sleep(2000);
        }

        [When(@"I chosen to select the academic year filter option")]
        public void WhenIChosenToSelecttheacademicyearFilterOption()
        {
            Actions.SelectCalculationYear();
            managecalculationpage.AcademicYearDropDownDefault.Should().Equals(Actions.PeriodTextValue);
            Thread.Sleep(2000);
        }

        [Then(@"All other filters will update")]
        public void ThenAllOtherFiltersWillUpdate()
        {
           

        }

        [Then(@"display only those options that return results")]
        public void ThenDisplayOnlyThoseOptionsThatReturnResults()
        {

        }

        [Then(@"a total count of all filtered results is displayed above the list of results")]
        public void ThenATotalCountOfAllFilteredResultsIsDisplayedAboveTheListOfResults()
        {
            IWebElement CalculationTotal = Driver._driver.FindElement(By.XPath("/html/body/main/div/div/div[3]/div[1]/div[2]/strong"));
            string CalculationTotalValue = CalculationTotal.Text;
            CalculationTotalValue.Should().NotBeNullOrEmpty();
            //Actions.CalculationTotalResult.CalculationTotalValue.Should().NotBeNullOrEmpty();

        }

        [Then(@"a count of the specific filter results is displayed")]
        public void ThenACountOfTheSpecificFilterResultsIsDisplayed()
        {
            IWebElement selectedFiterOption = Driver._driver.FindElement(By.ClassName("filter-selected-item"));
            string selectedFilter = selectedFiterOption.Text;
            IWebElement Period1819 = Driver._driver.FindElement(By.CssSelector("div.row:nth-child(4) > div:nth-child(1) > div:nth-child(2) > button:nth-child(1)"));
            string PeriodTextValue = Period1819.Text;
            selectedFiterOption.Should().Equals(PeriodTextValue);

        }

        [Then(@"the filter options are sorted in descending order by the count of results")]
        public void ThenTheFilterOptionsAreSortedInDescendingOrderByTheCountOfResults()
        {

        }

        [When(@"I choose to filter my list by funding stream")]
        public void WhenIChooseToFilterMyListByFundingStream()
        {
            Actions.SelectCalculationFundingStream();
            managecalculationpage.FundingStreamDropDownDefault.Should().Equals(Actions.Fundingstreamvalue);
            Thread.Sleep(2000);
        }

        [Then(@"the list view of calculations updates to display only calculations for the selected funding streams")]
        public void ThenTheListViewOfCalculationsUpdatesToDisplayOnlyCalculationsForTheSelectedFundingStreams()
        {
            IWebElement CalculationTotal = Driver._driver.FindElement(By.XPath("/html/body/main/div/div/div[3]/div[1]/div[2]/strong"));
            string CalculationTotalValue = CalculationTotal.Text;
            CalculationTotalValue.Should().NotBeNullOrEmpty();

            IWebElement selectedFiterOption = Driver._driver.FindElement(By.ClassName("filter-selected-item"));
            string selectedFilter = selectedFiterOption.Text;
            IWebElement FundingStream = Driver._driver.FindElement(By.CssSelector("div.row:nth-child(4) > div:nth-child(2) > div:nth-child(2) > button:nth-child(1)"));
            string FundingTextValue = FundingStream.Text;
            selectedFiterOption.Should().Equals(FundingTextValue);
        }

        [When(@"I choose to filter my list by policy")]
        public void WhenIChooseToFilterMyListByPolicy()
        {
            Actions.SelectCalculationSpecification();
            managecalculationpage.SpecNameDropDownDefault.Should().Equals(Actions.Specificationvalue);
            Thread.Sleep(2000);
        }

        [Then(@"the list view of calculations updates to display only calculations for the selected policy")]
        public void ThenTheListViewOfCalculationsUpdatesToDisplayOnlyCalculationsForTheSelectedPolicy()
        {
            IWebElement CalculationTotal = Driver._driver.FindElement(By.XPath("/html/body/main/div/div/div[3]/div[1]/div[2]/strong"));
            string CalculationTotalValue = CalculationTotal.Text;
            CalculationTotalValue.Should().NotBeNullOrEmpty();

            IWebElement selectedFiterOption = Driver._driver.FindElement(By.ClassName("filter-selected-item"));
            string selectedFilter = selectedFiterOption.Text;
            IWebElement PolicySchedule = Driver._driver.FindElement(By.CssSelector("div.row:nth-child(4) > div:nth-child(3) > div:nth-child(2) > button:nth-child(1)"));
            string PolicyScheduleTextValue = PolicySchedule.Text;
            selectedFiterOption.Should().Equals(PolicyScheduleTextValue);
        }

        [When(@"I choose to filter my list by Status")]
        public void WhenIChooseToFilterMyListByStatus()
        {
            Actions.SelectCalculationStatus();
            managecalculationpage.CalculationStatusDropDownDefault.Should().Equals(Actions.Calculationstatusvalue);
            Thread.Sleep(2000);
        }

        [Then(@"the list view of calculations updates to display only calculations for the selected Status")]
        public void ThenTheListViewOfCalculationsUpdatesToDisplayOnlyCalculationsForTheSelectedStatus()
        {
            IWebElement CalculationTotal = Driver._driver.FindElement(By.XPath("/html/body/main/div/div/div[3]/div[1]/div[2]/strong"));
            string CalculationTotalValue = CalculationTotal.Text;
            CalculationTotalValue.Should().NotBeNullOrEmpty();

            IWebElement selectedFiterOption = Driver._driver.FindElement(By.ClassName("filter-selected-item"));
            string selectedFilter = selectedFiterOption.Text;
            IWebElement PolicyStatus = Driver._driver.FindElement(By.CssSelector("div.row:nth-child(4) > div:nth-child(4) > div:nth-child(2) > button:nth-child(1)"));
            string PolicyStatusTextValue = PolicyStatus.Text;
            selectedFiterOption.Should().Equals(PolicyStatusTextValue);
        }

        [When(@"I choose to filter my list by Allocation Lines")]
        public void WhenIChooseToFilterMyListByAllocationLines()
        {
            Actions.SelectCalculationAllocationLine();
            managecalculationpage.AllocationLineDropDownDefault.Should().Equals(Actions.Allocationlinevalue);
            Thread.Sleep(2000);
        }

        [Then(@"the list view of calculations updates to display only calculations for the selected Allocation Lines")]
        public void ThenTheListViewOfCalculationsUpdatesToDisplayOnlyCalculationsForTheSelectedAllocationLines()
        {
            IWebElement CalculationTotal = Driver._driver.FindElement(By.XPath("/html/body/main/div/div/div[3]/div[1]/div[2]/strong"));
            string CalculationTotalValue = CalculationTotal.Text;
            CalculationTotalValue.Should().NotBeNullOrEmpty();

            IWebElement selectedFiterOption = Driver._driver.FindElement(By.ClassName("filter-selected-item"));
            string selectedFilter = selectedFiterOption.Text;
            IWebElement AllocationLine = Driver._driver.FindElement(By.CssSelector("#filter-container > div:nth-child(2) > div:nth-child(2) > div:nth-child(2) > button:nth-child(1)"));
            string AllocationLineTextValue = AllocationLine.Text;
            selectedFiterOption.Should().Equals(AllocationLineTextValue);
        }

        [Given(@"ONE or MORE filter Options have previously been selected")]
        public void GivenONEOrMOREFilterOptionsHavePreviouslyBeenSelected()
        {
            Actions.SelectCalculationStatus();
            Thread.Sleep(2000);
            Actions.SelectCalculationYear();
            managecalculationpage.AcademicYearDropDownDefault.Should().Equals(Actions.PeriodTextValue);
            managecalculationpage.CalculationStatusDropDownDefault.Should().Equals(Actions.Calculationstatusvalue);
            Thread.Sleep(2000);

        }

        [When(@"I deselect one or more filter options")]
        public void WhenIDeselectOneOrMoreFilterOptions()
        {
            managecalculationpage.RemoveCalculationFilter.Click();
            Thread.Sleep(5000);
        }

        [Given(@"No additional filter options have been selected")]
        public void GivenNoAdditionalFilterOptionsHaveBeenSelected()
        {
            Actions.ManageCalculationFiltersAreSetAsDefault();
            Thread.Sleep(2000);
        }

        [When(@"I enter text in the search field")]
        public void WhenIEnterTextInTheSearchField()
        {
            managecalculationpage.CalculationSearchField.Clear();
            managecalculationpage.CalculationSearchField.SendKeys("Test");
            Thread.Sleep(2000);
        }

        [When(@"I click the search button")]
        public void WhenIClickTheSearchButton()
        {
            managecalculationpage.CalculationSearchButton.Click();
            Thread.Sleep(2000);
        }

        [Then(@"the list view of calculations updates to display only calculations that comply with the search term entered")]
        public void ThenTheListViewOfCalculationsUpdatesToDisplayOnlyCalculationsThatComplyWithTheSearchTermEntered()
        {
            IWebElement CalculationTotal = Driver._driver.FindElement(By.XPath("/html/body/main/div/div/div[3]/div[1]/div[2]/strong"));
            string CalculationTotalValue = CalculationTotal.Text;
            CalculationTotalValue.Should().NotBeEmpty();
            managecalculationpage.FirstCalculationListed.Text.Contains("Test");
            Thread.Sleep(2000);
        }

        [When(@"the text i enter into a search matches a calculation name exactly")]
        public void WhenTheTextIEnterIntoASearchMatchesACalculationNameExactly()
        {
            IWebElement GetListedCalculation = Driver._driver.FindElement(By.CssSelector("#dynamic-results-table-body > tr:nth-child(1) > td:nth-child(1) > a:nth-child(1)"));
            string GetListedCalculationText = GetListedCalculation.Text;
            managecalculationpage.CalculationSearchField.Clear();
            managecalculationpage.CalculationSearchField.SendKeys(GetListedCalculationText);
            Thread.Sleep(5000);

        }

        [Then(@"the list view of calculations updates to display the specfic search calculation only")]
        public void ThenTheListViewOfCalculationsUpdatesToDisplayTheSpecficSearchCalculationOnly()
        {
            IWebElement CalculationTotal = Driver._driver.FindElement(By.XPath("/html/body/main/div/div/div[3]/div[1]/div[2]/strong"));
            string CalculationTotalValue = CalculationTotal.Text;
            CalculationTotalValue.Should().NotBeEmpty();
            Thread.Sleep(2000);
        }

        [Then(@"the previously selected filter options")]
        public void ThenThePreviouslySelectedFilterOptions()
        {
            managecalculationpage.AcademicYearDropDownDefault.Should().Equals(Actions.PeriodTextValue);
            managecalculationpage.CalculationStatusDropDownDefault.Should().Equals(Actions.Calculationstatusvalue);
            managecalculationpage.CalculationFilterBox.Should().NotBeNull();

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
