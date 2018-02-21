using System;
using System.Threading;
using AutoFramework;
using FluentAssertions;
using Frontend.IntegrationTests.Pages.Manage_Calculation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
//using OpenQA.Selenium.PhantomJS;
using TechTalk.SpecFlow;

namespace Frontend.IntegrationTests.Tests.Steps
{
    [Binding]
    public class ManageCalculationsSteps
    {
        ManageCalculationPage managecalculationpage = new ManageCalculationPage();
        EditCalculationsPage editcalculationspage = new EditCalculationsPage();
        ViewPreviousCalculationsPage viewpreviouscalculationpage = new ViewPreviousCalculationsPage();
        CompareCalculationsPage comparecalculationspage = new CompareCalculationsPage();

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

        [Given(@"I click on a calculation in the displayed list")]
        public void GivenIClickOnACalculationInTheDisplayedList()
        {
            Thread.Sleep(2000);
            Actions.SearchFilterForTestCalculations();
            managecalculationpage.FirstCalculationListed.Text.Contains("Test");
            managecalculationpage.FirstCalculationListed.Click();


        }

        [When(@"The Edit Calculation screen is displayed")]
        public void WhenTheEditCalculationScreenIsDisplayed()
        {
            Thread.Sleep(2000);
            editcalculationspage.SaveCalculationButton.Should().NotBeNull();
        }

        [Then(@"The Name of the specification is displayed")]
        public void ThenTheNameOfTheSpecificationIsDisplayed()
        {
            editcalculationspage.CalculationSpecName.Should().NotBeNull();
        }

        [Then(@"The Description of the specification is displayed")]
        public void ThenTheDescriptionOfTheSpecificationIsDisplayed()
        {
            editcalculationspage.CalculationSpecDescription.Should().NotBeNull();
        }

        [Then(@"The Build Calculation button is disabled")]
        public void ThenTheBuildCalculationButtonIsDisabled()
        {
            editcalculationspage.BuildCalculationButton.Should().NotBeNull();
            editcalculationspage.BuildCalculationButton.GetAttribute("enabled");
        }

        [Then(@"The Save Calculation button is disabled")]
        public void ThenTheSaveCalculationButtonIsDisabled()
        {
            editcalculationspage.SaveCalculationButton.Should().NotBeNull();
            editcalculationspage.SaveCalculationButton.GetAttribute("disabled");
        }

        [Then(@"The Publish Calculation button is disabled")]
        public void ThenThePublishCalculationButtonIsDisabled()
        {
            editcalculationspage.PublishCalculationButton.Should().NotBeNull();
            editcalculationspage.PublishCalculationButton.GetAttribute("disabled");
            Thread.Sleep(2000);
        }

        [When(@"I have edited the visual basic code")]
        public void WhenIHaveEditedTheVisualBasicCode()
        {
            editcalculationspage.CalculationVBEditor.Should().NotBeNull();
            editcalculationspage.CalculationVBTextEditor.SendKeys(OpenQA.Selenium.Keys.Control + "A");
            editcalculationspage.CalculationVBTextEditor.SendKeys("Return Decimal.MinValue + 1");
            Thread.Sleep(2000);
        }

        [When(@"I click the Build Calculation button")]
        public void WhenIClickTheBuildCalculationButton()
        {
            editcalculationspage.BuildCalculationButton.Click();

        }

        [Then(@"I am notified that my code is compiling in the output box")]
        public void ThenIAmNotifiedThatMyCodeIsCompilingInTheOutputBox()
        {
            IWebElement EditCalculationCompiling = Driver._driver.FindElement(By.Id("compiler-response"));
            string CalculationCompiling = EditCalculationCompiling.Text;
            CalculationCompiling.Should().Equals("Compiling...");
            Thread.Sleep(2000);
        }

        [Then(@"I am notified that my code has finished compiling in the output box")]
        public void ThenIAmNotifiedThatMyCodeHasFinishedCompilingInTheOutputBox()
        {
            IWebElement EditCalculationCompiled = Driver._driver.FindElement(By.Id("compiler-response"));
            string CalculationCompiled = EditCalculationCompiled.Text;
            CalculationCompiled.Should().Equals("Code compiled successfully:");
            Console.WriteLine(CalculationCompiled);
            Thread.Sleep(2000);
        }

        [Then(@"the results of the compilation is recorded in the output box")]
        public void ThenTheResultsOfTheCompilationIsRecordedInTheOutputBox()
        {
            IWebElement ValidateCalculationCompile = Driver._driver.FindElement(By.CssSelector("#compiler-response > span:nth-child(1)"));
            string CalculationCompileResult = ValidateCalculationCompile.Text;
            CalculationCompileResult.Should().Equals("True");
            Console.WriteLine(CalculationCompileResult);
            Thread.Sleep(2000);

        }

        [When(@"I have incorrectly edited the visual basic code")]
        public void WhenIHaveIncorrectlyEditedTheVisualBasicCode()
        {
            editcalculationspage.CalculationVBEditor.Should().NotBeNull();
            editcalculationspage.CalculationVBTextEditor.SendKeys(OpenQA.Selenium.Keys.Control + "A");
            editcalculationspage.CalculationVBTextEditor.SendKeys("Return Decimal.MinVa + 1");
            Thread.Sleep(2000);
        }

        [Then(@"the error result of the compilation is recorded in the output box")]
        public void ThenTheErrorResultOfTheCompilationIsRecordedInTheOutputBox()
        {
            IWebElement ValidateCalculationCompile = Driver._driver.FindElement(By.CssSelector("#compiler-response > span:nth-child(1)"));
            string CalculationCompileResult = ValidateCalculationCompile.Text;
            CalculationCompileResult.Should().Equals("False");
            Console.WriteLine(editcalculationspage.CalculationCompilierMessage.Text);
            IWebElement savebutton = editcalculationspage.SaveCalculationButton;
            savebutton.GetAttribute("disabled");
            Console.WriteLine("The Save Button is Disabled");
            Thread.Sleep(2000);
        }

        [Then(@"I click the Save Calculation button")]
        public void ThenIClickTheSaveCalculationButton()
        {
            editcalculationspage.SaveCalculationButton.Click();
            Thread.Sleep(2000);
        }

        [Then(@"I am returned to the manage calculation page")]
        public void ThenIAmReturnedToTheManageCalculationPage()
        {
            Assert.IsNotNull(managecalculationpage.CalculationSearchField);
            Thread.Sleep(3000);
        }

        [Then(@"a full audit record of my calculation is created")]
        public void ThenAFullAuditRecordOfMyCalculationIsCreated()
        {

        }

        [Given(@"The Edit Calculation screen is displayed")]
        public void GivenTheEditCalculationScreenIsDisplayed()
        {
            Thread.Sleep(2000);
            editcalculationspage.SaveCalculationButton.Should().NotBeNull();
        }

        [When(@"I click the View previous versions link")]
        public void WhenIClickTheViewPreviousVersionsLink()
        {
            editcalculationspage.PreviousCalculationVersionsLink.Click();
            Thread.Sleep(2000);

        }

        [Then(@"I am redirected to the Compare Calculation Versions page")]
        public void ThenIAmRedirectedToTheCompareCalculationVersionsPage()
        {
            viewpreviouscalculationpage.ComparePreviousCalculationsButton.Should().NotBeNull();
            Thread.Sleep(2000);
        }

        [Then(@"a list view of calculation versions is displayed")]
        public void ThenAListViewOfCalculationVersionsIsDisplayed()
        {
            viewpreviouscalculationpage.CompareFirstCheckBox.Should().NotBeNull();
            Thread.Sleep(2000);
        }

        [Given(@"I have navigated to the Compare Calculation Versions page")]
        public void GivenIHaveNavigatedToTheCompareCalculationVersionsPage()
        {
            NavigateTo.ComparePreviousCalculationVersions();
            Thread.Sleep(2000);
        }

        [Then(@"I can see who created the calculation version as the Author")]
        public void ThenICanSeeWhoCreatedTheCalculationVersionAsTheAuthor()
        {
            viewpreviouscalculationpage.CalculationVersionAuthor.Should().NotBeNull();
        }

        [Then(@"the date time the version was Created or Updated")]
        public void ThenTheDateTimeTheVersionWasCreatedOrUpdated()
        {
            viewpreviouscalculationpage.CalculationVersionUpdatedDate.Should().NotBeNull();
        }

        [Then(@"the calculation version number is displayed")]
        public void ThenTheCalculationVersionNumberIsDisplayed()
        {
            viewpreviouscalculationpage.CalculationVersionId.Should().NotBeNull();
        }

        [Then(@"the calculation status is displayed")]
        public void ThenTheCalculationStatusIsDisplayed()
        {
            viewpreviouscalculationpage.CalculationVersionStatus.Should().NotBeNull();
        }


        [Then(@"the list is sorted in descending order by Updated date")]
        public void ThenTheListIsSortedInDescendingOrderByUpdatedDate()
        {
            var versionNumber = viewpreviouscalculationpage.CalculationVersionId;
            string versionId = versionNumber.Text;
            int calculationVersionId = int.Parse(versionId);
            calculationVersionId.Should().BeGreaterOrEqualTo(1, "Calculations Are Not Sorted Correctly");
            Thread.Sleep(2000);

        }

        [Given(@"More than one version of code has been previously saved")]
        public void GivenMoreThanOneVersionOfCodeHasBeenPreviouslySaved()
        {
            var versionNumber = viewpreviouscalculationpage.CalculationVersionId;
            string versionId = versionNumber.Text;
            int calculationVersionId = int.Parse(versionId);
            calculationVersionId.Should().BeGreaterOrEqualTo(2, "There is only One current version of this Calculation");
            Thread.Sleep(2000);
        }

        [When(@"I click only one version of the calculation code")]
        public void WhenIClickOnlyOneVersionOfTheCalculationCode()
        {
            viewpreviouscalculationpage.CompareFirstCheckBox.Click();
            Thread.Sleep(2000);
        }

        [Then(@"The Compare Calculations button remains disabled")]
        public void ThenTheCompareCalculationsButtonRemainsDisabled()
        {
            IWebElement compareCalculationButton = viewpreviouscalculationpage.ComparePreviousCalculationsButton;
            compareCalculationButton.GetAttribute("disabled");
            Console.WriteLine("The Compare Calculation Button is Disabled");
            Thread.Sleep(2000);
        }

        [When(@"I click to select two versions of the code")]
        public void WhenIClickToSelectTwoVersionsOfTheCode()
        {
            viewpreviouscalculationpage.CompareFirstCheckBox.Click();
            viewpreviouscalculationpage.CompareSecondCheckBox.Click();
            Thread.Sleep(1000);
        }

        [When(@"I click the Compare The Calculations button")]
        public void WhenIClickTheCompareTheCalculationsButton()
        {
            viewpreviouscalculationpage.ComparePreviousCalculationsButton.Click();
            Thread.Sleep(2000);

        }

        [Then(@"I am redirected to the Calculation Comparison page")]
        public void ThenIAmRedirectedToTheCalculationComparisonPage()
        {
            comparecalculationspage.inlineCodeEditor.Should().NotBeNull();
            comparecalculationspage.inlineCodeEditorTextArea.Should().NotBeNull();
            Thread.Sleep(2000);
        }

        [Given(@"I have navigated to the Calculation Comparison page")]
        public void GivenIHaveNavigatedToTheCalculationComparisonPage()
        {
            NavigateTo.CalculationComparisonPage();
            Thread.Sleep(2000);
        }

        [Then(@"the status of each version is correctly displayed")]
        public void ThenTheStatusOfEachVersionIsCorrectlyDisplayed()
        {
            comparecalculationspage.leftInlineCodeEditorStatus.Should().NotBeNull();
            comparecalculationspage.rightInlineCodeEditorStatus.Should().NotBeNull();
        }

        [Then(@"the date time each version was Created or Updated is displayed")]
        public void ThenTheDateTimeEachVersionWasCreatedOrUpdatedIsDisplayed()
        {
            comparecalculationspage.leftInlineCodeEditorDateTime.Should().NotBeNull();
            comparecalculationspage.rightInlineCodeEditorDateTime.Should().NotBeNull();
        }

        [Then(@"the name of the Author of each version is displayed")]
        public void ThenTheNameOfTheAuthorOfEachVersionIsDisplayed()
        {
            comparecalculationspage.leftInlineCodeEditorAuthor.Should().NotBeNull();
            comparecalculationspage.rightInlineCodeEditorAuthor.Should().NotBeNull();
        }

        [Then(@"The applicable code for both versions is displayed side by side")]
        public void ThenTheApplicableCodeForBothVersionsIsDisplayedSideBySide()
        {
            comparecalculationspage.inlineCodeEditorTextArea.Should().NotBeNull();

        }

        [Then(@"The Inline Code Editor option can be selected")]
        public void ThenTheInlineCodeEditorOptionCanBeSelected()
        {
            comparecalculationspage.inlineCodeEditor.Click();

        }

        [Then(@"The Back Link can be selected to return to the Previous Calculation Page")]
        public void ThenTheBackLinkCanBeSelectedToReturnToThePreviousCalculationPage()
        {
            comparecalculationspage.compareCalculationsBackLink.Click();
            Thread.Sleep(2000);
            viewpreviouscalculationpage.ComparePreviousCalculationsButton.Should().NotBeNull();
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
