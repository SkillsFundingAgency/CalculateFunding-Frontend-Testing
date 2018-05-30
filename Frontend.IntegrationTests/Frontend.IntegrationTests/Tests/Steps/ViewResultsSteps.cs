using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using AutoFramework;
using FluentAssertions;
using Frontend.IntegrationTests.Create;
using Frontend.IntegrationTests.Pages;
using Frontend.IntegrationTests.Pages.View_Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
//using OpenQA.Selenium.PhantomJS;
using TechTalk.SpecFlow;

namespace Frontend.IntegrationTests.Tests.Steps
{
    [Binding]
    public class ViewResultsSteps
    {
        HomePage homepage = new HomePage();
        ViewProviderResultsPage viewproviderresultspage = new ViewProviderResultsPage();
        ViewProviderAllocationsPage viewproviderallocationspage = new ViewProviderAllocationsPage();
        ViewResultsOptionsPage viewresultsoptionspage = new ViewResultsOptionsPage();
        ViewQATestResultsPage viewqatestresultspage = new ViewQATestResultsPage();
        ViewTestResultsAllProvidersSingleTest viewtestresultsallproviders = new ViewTestResultsAllProvidersSingleTest();
        ViewCalculationResultPage viewcalculationresultpage = new ViewCalculationResultPage();

        public string searchtext = "Primary";
        public string provider = "Academy";

        [When(@"I click on the View provider results option")]
        public void WhenIClickOnTheViewProviderResultsOption()
        {
            viewresultsoptionspage.viewResultsOptionsViewProviderResults.Click();
            Thread.Sleep(2000);
        }

        [Then(@"I am navigated to a page displaying providers")]
        public void ThenIAmNavigatedToAPageDisplayingProviders()
        {
            viewproviderresultspage.providerResultspageSearch.Should().NotBeNull();
            Thread.Sleep(2000);

        }

        [Then(@"the name of the provider is displayed")]
        public void ThenTheNameOfTheProviderIsDisplayed()
        {
            IWebElement providerresultslistcontainer = viewproviderresultspage.providerResultspageResultListContainer;
            IWebElement providernameexists = providerresultslistcontainer.FindElement(By.CssSelector("div.provider-item-header"));
            providernameexists.Should().NotBeNull();
            providernameexists.Displayed.Should().BeTrue();
            string providername = providernameexists.Text;
            Console.WriteLine("The Provider Name Displayed is: " + providername);

        }

        [Then(@"all the relevant provider details are displayed")]
        public void ThenAllTheRelevantProviderDetailsAreDisplayed()
        {
            IWebElement providerresultitemcontainer = viewproviderresultspage.providerResultspageProviderItemContainer;
            var propertyElements = providerresultitemcontainer.FindElements(By.CssSelector("span.provider-item-property"));
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

        [Then(@"the list is displayed by provider name in ascending order")]
        public void ThenTheListIsDisplayedByProviderNameInAscendingOrder()
        {
            IWebElement providerresultitemcontainer = viewproviderresultspage.providerResultspageProviderItemContainer;
            var providerElements = providerresultitemcontainer.FindElements(By.CssSelector("h4.heading-small"));
            List<IWebElement> providerElementList = new List<IWebElement>(providerElements);
            providerElementList.Should().HaveCountGreaterThan(0, "Return elements expected");
            providerElementList.Should().BeInAscendingOrder();

            for (int i = 0; i < providerElementList.Count; i++)
            {
                IWebElement currentElement = providerElementList[i];
                currentElement.Should().NotBeNull("element {0} is null", i);

                IWebElement valueElement = currentElement.FindElement(By.TagName("a"));

                valueElement.Should().NotBeNull("value element {0} is null", i);
                valueElement.Text.Should().NotBeNullOrEmpty("value element {0} does not contain value", i);
            }

        }

        [Given(@"I have navigated to the View Provider Results Page")]
        public void GivenIHaveNavigatedToTheViewProviderResultsPage()
        {
            NavigateTo.ViewResultsPage();
            Thread.Sleep(2000);
        }

        [Then(@"the list displays up to (.*) providers per page")]
        public void ThenTheListDisplaysUpToProvidersPerPage(int endproviderlistcount)
        {
            IWebElement providerendResultCount = viewproviderresultspage.providerResultsPageLastResult;
            string endPageResultCount = providerendResultCount.Text;
            int endPageCount = int.Parse(endPageResultCount);
            endPageCount.Should().BeLessOrEqualTo(endproviderlistcount, "More than 50 Results are displayed on this Page");
            Console.WriteLine("Total Page Results Displayed is " + providerendResultCount.Text);
        }

        [Then(@"an option to filter by search is displayed")]
        public void ThenAnOptionToFilterBySearchIsDisplayed()
        {
            viewproviderresultspage.providerResultspageSearch.Should().NotBeNull();
        }

        [Then(@"options are displayed to filter the results by specific fields")]
        public void ThenOptionsAreDisplayedToFilterTheResultsBySpecificFields()
        {
            viewproviderresultspage.providerResultspageLocalAuthorityDropDown.Should().NotBeNull();
            viewproviderresultspage.providerResultspageProviderDropDown.Should().NotBeNull();
            viewproviderresultspage.providerResultspageProviderSubTypeDropDown.Should().NotBeNull();
        }


        [Given(@"I have over (.*) providers with results")]
        public void GivenIHaveOverProvidersWithResults(int totalproviderlistcount)
        {
            IWebElement providertotalResultCount = viewproviderresultspage.providerResultsPageTotalResult;
            string totalPageResultCount = providertotalResultCount.Text;
            int totalPageCount = int.Parse(totalPageResultCount);
            totalPageCount.Should().BeGreaterOrEqualTo(totalproviderlistcount, "Less than " + totalproviderlistcount + "Results are displayed on this Page");
            Console.WriteLine("The Total results returned is " + totalPageCount);
        }

        [When(@"I click to navigate to the next page of (.*) providers")]
        public void WhenIClickToNavigateToTheNextPageOfProviders(int p0)
        {
            Actions.PaginationSelectPage();
            Thread.Sleep(2000);
        }

        [Then(@"my list view displays the next (.*) results")]
        public void ThenMyListViewDisplaysTheNextResults(int firstproviderlistcount)
        {
            IWebElement providerfirstResultCount = viewproviderresultspage.providerResultsPageFirstResult;
            string firstPageResultCount = providerfirstResultCount.Text;
            int firstPageCount = int.Parse(firstPageResultCount);
            firstPageCount.Should().BeGreaterOrEqualTo(firstproviderlistcount, "Less than 50 Results have been returned");
        }

        [Then(@"I am able to navigate to the previous page of (.*) providers")]
        public void ThenIAmAbleToNavigateToThePreviousPageOfProviders(int firstproviderlistcount)
        {
            Actions.PaginationSelectPage();
            Thread.Sleep(2000);
            IWebElement providerfirstResultCount = viewproviderresultspage.providerResultsPageFirstResult;
            string firstPageResultCount = providerfirstResultCount.Text;
            int firstPageCount = int.Parse(firstPageResultCount);
            firstPageCount.Should().BeLessOrEqualTo(firstproviderlistcount, "Previous 50 Results have been returned correctly");
        }

        [When(@"I click the Next option")]
        public void WhenIClickTheNextOption()
        {
            viewproviderresultspage.providerResultsPageNextSetPagination.Should().NotBeNull();
            viewproviderresultspage.providerResultsPageNextSetPagination.Click();
            Thread.Sleep(2000);

        }

        [When(@"I click the Previous option")]
        public void WhenIClickThePreviousOption()
        {
            viewproviderresultspage.providerResultsPagePreviousSetPagination.Should().NotBeNull();
            viewproviderresultspage.providerResultsPagePreviousSetPagination.Click();
            Thread.Sleep(4000);
        }

        [Then(@"my list view displays the previous (.*) results")]
        public void ThenMyListViewDisplaysThePreviousResults(int firstproviderlistcount)
        {
            IWebElement providerfirstResultCount = viewproviderresultspage.providerResultsPageFirstResult;
            string firstPageResultCount = providerfirstResultCount.Text;
            int firstPageCount = int.Parse(firstPageResultCount);
            firstPageCount.Should().BeLessOrEqualTo(firstproviderlistcount, "Less than  " + firstproviderlistcount + "Results are displayed on this Page");
        }


        [When(@"I click a provider")]
        public void WhenIClickAProvider()
        {
            IWebElement providerresultslistcontainer = viewproviderresultspage.providerResultspageResultListContainer;
            IWebElement providernameexists = providerresultslistcontainer.FindElement(By.CssSelector("h4.heading-small"));
            IWebElement providernamelink = providernameexists.FindElement(By.TagName("a"));
            providernamelink.Should().NotBeNull();
            providernamelink.Displayed.Should().BeTrue();
            providernamelink.Click();
            Thread.Sleep(2000);
        }

        [Then(@"I am redirected to the View provider allocations page for the selected provider")]
        public void ThenIAmRedirectedToTheViewProviderAllocationsPageForTheSelectedProvider()
        {
            viewproviderallocationspage.providerAllocationsPageNavigationTab.Should().NotBeNull();

        }

        [When(@"I enter text in the Search Provider field")]
        public void WhenIEnterTextInTheSearchProviderField()
        {
            IWebElement providertotalResultCount = viewproviderresultspage.providerResultsPageTotalResult;
            string totalPageResultCount = providertotalResultCount.Text;
            int totalPageCount = int.Parse(totalPageResultCount);
            Console.WriteLine("Total Default Provider Results displayed is " + totalPageCount);
            viewproviderresultspage.providerResultspageSearch.SendKeys(searchtext);

        }

        [When(@"click the Search Provider button")]
        public void WhenClickTheSearchProviderButton()
        {
            viewproviderresultspage.providerResultspageSearchButton.Click();
            Thread.Sleep(2000);
        }

        [Then(@"the list of displayed providers refreshes to display only the providers that comply with the search text entered")]
        public void ThenTheListOfDisplayedProvidersRefreshesToDisplayOnlyTheProvidersThatComplyWithTheSearchTextEntered()
        {
            IWebElement providertotalResultCount = viewproviderresultspage.providerResultsPageTotalResult;
            string totalPageResultCount = providertotalResultCount.Text;
            int totalPageCount = int.Parse(totalPageResultCount);
            Console.WriteLine("Total Provider Results filtered by Search is " + totalPageCount);
            totalPageCount.Should().BeGreaterOrEqualTo(1, "Search returned no results");
        }

        [When(@"I enter text in the Search Provider field that matches or contains (.*)")]
        public void WhenIEnterTextInTheSearchProviderFieldThatMatchesOrContains(string text)
        {
            IWebElement providertotalResultCount = viewproviderresultspage.providerResultsPageTotalResult;
            string totalPageResultCount = providertotalResultCount.Text;
            int totalPageCount = int.Parse(totalPageResultCount);
            Console.WriteLine("Total Default Provider Results displayed is " + totalPageCount);
            viewproviderresultspage.providerResultspageSearch.SendKeys(text);
        }

        [Given(@"I have selected one or more filter options from the top navigation pane")]
        public void GivenIHaveSelectedOneOrMoreFilterOptionsFromTheTopNavigationPane()
        {
            IWebElement filtercontainer = viewproviderresultspage.providerResultsPageFilterContainer;
            IWebElement providertypefilter = filtercontainer.FindElement(By.CssSelector("button"));
            providertypefilter.Click();
            Thread.Sleep(2000);
            IWebElement selectfilteroption = filtercontainer.FindElement(By.CssSelector("label"));
            string providertypeselected = selectfilteroption.Text;
            Console.WriteLine("Provider Type Filter Option selected = " + providertypeselected);
            selectfilteroption.Click();
            viewproviderresultspage.providerResultspageSearch.Click();
            Thread.Sleep(2000);
        }

        [Then(@"the list of displayed providers refreshes to display only the providers that comply with the search text & filters selected")]
        public void ThenTheListOfDisplayedProvidersRefreshesToDisplayOnlyTheProvidersThatComplyWithTheSearchTextFiltersSelected()
        {
            IWebElement providertotalResultCount = viewproviderresultspage.providerResultsPageTotalResult;
            string totalPageResultCount = providertotalResultCount.Text;
            int totalPageCount = int.Parse(totalPageResultCount);
            Console.WriteLine("Total Provider Results filtered by Search is " + totalPageCount);
            totalPageCount.Should().BeGreaterOrEqualTo(1, "Search returned no results");
        }


        [When(@"I click on a listed provider")]
        public void WhenIClickOnAListedProvider()
        {
            IWebElement providerresultslistcontainer = viewproviderresultspage.providerResultspageResultListContainer;
            IWebElement providernamelink = providerresultslistcontainer.FindElement(By.TagName("a"));
            providernamelink.Should().NotBeNull();
            providernamelink.Click();
            Thread.Sleep(2000);
        }

        [Then(@"I am navigated to the View Provider Allocation page")]
        public void ThenIAmNavigatedToTheViewProviderAllocationPage()
        {
            viewproviderallocationspage.providerAllocationsPageNavigationTab.Should().NotBeNull();
        }

        [Then(@"the relevant provider information is displayed")]
        public void ThenTheRelevantProviderInformationIsDisplayed()
        {
            IWebElement providernamedisplayed = viewproviderallocationspage.providerAllocationsPageProviderInfoContainer;
            IWebElement providername = providernamedisplayed.FindElement(By.TagName("h1"));
            providername.Should().NotBeNull();
            providername.Displayed.Should().BeTrue();
            string provider = providername.Text;
            Console.WriteLine("The Provider Name " + provider + " is displayed");

            IWebElement providerinfocontainer = viewproviderallocationspage.providerAllocationsPageProviderInfoContainer;
            var propertyElements = providerinfocontainer.FindElements(By.CssSelector("p.hero-text:nth-child(3)"));
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

            IWebElement providerinfolocalauth = viewproviderallocationspage.providerAllocationsPageProviderInfoContainer;
            IWebElement localauthinfo = providerinfolocalauth.FindElement(By.CssSelector(".col-xs-9 > div:nth-child(5)"));
            localauthinfo.Should().NotBeNull();
            string localauthname = localauthinfo.Text;
            localauthname.Should().NotBeNullOrEmpty("value element does not exist");
            Console.WriteLine(localauthname);

            IWebElement providerinfotype = viewproviderallocationspage.providerAllocationsPageProviderInfoContainer;
            var providerinfotypeElements = providerinfotype.FindElements(By.CssSelector(".col-xs-9 > div:nth-child(6)"));
            List<IWebElement> providerinfotypeElementList = new List<IWebElement>(providerinfotypeElements);
            providerinfotypeElementList.Should().HaveCountGreaterThan(0, "Return elements expected");

            for (int i = 0; i < providerinfotypeElementList.Count; i++)
            {
                IWebElement currentElement = providerinfotypeElementList[i];
                currentElement.Should().NotBeNull("element {0} is null", i);

                IWebElement valueElement = currentElement.FindElement(By.TagName("span"));

                valueElement.Should().NotBeNull("value element {0} is null", i);
                valueElement.Text.Should().NotBeNullOrEmpty("value element {0} does not contain value", i);
                Console.WriteLine(currentElement.Text);
            }


            IWebElement providerinfodateopened = viewproviderallocationspage.providerAllocationsPageProviderInfoContainer;
            IWebElement dateopenedinfo = providerinfodateopened.FindElement(By.CssSelector(".col-xs-9 > div:nth-child(7)"));
            dateopenedinfo.Should().NotBeNull();
            string dateopenedtext = dateopenedinfo.Text;
            dateopenedtext.Should().NotBeNullOrEmpty("value element does not exist");
            Console.WriteLine(dateopenedtext);


        }

        [Then(@"a drop down option is displayed to select a year with the default year pre selected")]
        public void ThenADropDownOptionIsDisplayedToSelectAYearWithTheDefaultYearPreSelected()
        {
            IWebElement academicyeardropdown = viewproviderallocationspage.providerAllocationsPageAcademicYearDropDown;
            academicyeardropdown.Should().NotBeNull();
            academicyeardropdown.Displayed.Should().BeTrue();
            IWebElement defaultyearselected = academicyeardropdown.FindElement(By.CssSelector("#PeriodId > option:nth-child(2)"));
            defaultyearselected.Should().NotBeNull();
            string defaultyeardisplayed = defaultyearselected.Text;
            Console.WriteLine("The Default Year displayed is " + defaultyeardisplayed);
        }

        [Then(@"a drop down option is displayed to select a specification where the default is blank")]
        public void ThenADropDownOptionIsDisplayedToSelectASpecificationWhereTheDefaultIsBlank()
        {
            IWebElement specificationdropdown = viewproviderallocationspage.providerAllocationsPageSpecificationDropDown;
            specificationdropdown.Should().NotBeNull();
            specificationdropdown.Displayed.Should().BeTrue();
            IWebElement defaultspecificationblank = specificationdropdown.FindElement(By.CssSelector("#SpecificationId > option:nth-child(1)"));
            string specificationblank = defaultspecificationblank.Text;
            specificationblank.Should().BeNullOrEmpty();
        }


        [Given(@"I have navigated to the View Provider Allocations Page")]
        public void GivenIHaveNavigatedToTheViewProviderAllocationsPage()
        {
            NavigateTo.ViewProviderAllocationsPage();
            Thread.Sleep(2000);
        }

        [Then(@"the default view is the tab displaying the allocation lines")]
        public void ThenTheDefaultViewIsTheTabDisplayingTheAllocationLines()
        {
            viewproviderallocationspage.providerAllocationsPageAllocationTab.Should().NotBeNull();

        }

        [Then(@"a selectable tab is available to display the calculation results")]
        public void ThenASelectableTabIsAvailableToDisplayTheCalculationResults()
        {
            viewproviderallocationspage.providerAllocationsPageCalculationTab.Should().NotBeNull();
        }

        [Then(@"no results are listed by default as no specification has been selected")]
        public void ThenNoResultsAreListedByDefaultAsNoSpecificationHasBeenSelected()
        {
            IWebElement viewresultscontainer = viewproviderallocationspage.providerAllocationsPageProviderPolicyContainer;
            IWebElement viewresultsmessage = viewresultscontainer.FindElement(By.TagName("p"));
            string noresultsdisplayedmessage = viewresultsmessage.Text;
            Console.WriteLine(noresultsdisplayedmessage);


        }


        [When(@"I choose a specification from the drop down")]
        public void WhenIChooseASpecificationFromTheDropDown()
        {
            Actions.SelectSpecificationProviderAllocationPage();
            Thread.Sleep(2000);
        }

        [When(@"I am on the allocation view")]
        public void WhenIAmOnTheAllocationView()
        {
            viewproviderallocationspage.providerAllocationsPageAllocationTab.Should().NotBeNull();
        }

        [Then(@"the results are updated according to the year and spec selected")]
        public void ThenTheResultsAreUpdatedAccordingToTheYearAndSpecSelected()
        {
            IWebElement academicyeardropdown = viewproviderallocationspage.providerAllocationsPageAcademicYearDropDown;
            academicyeardropdown.Should().NotBeNull();
            academicyeardropdown.Displayed.Should().BeTrue();
            IWebElement defaultyearselected = academicyeardropdown.FindElement(By.CssSelector("#PeriodId > option:nth-child(2)"));
            defaultyearselected.Should().NotBeNull();
            string defaultyeardisplayed = defaultyearselected.Text;
            Console.WriteLine("The Default Year displayed is " + defaultyeardisplayed);
            Thread.Sleep(2000);

            IWebElement viewresultscontainer = viewproviderallocationspage.providerAllocationsPageProviderPolicyContainer;
            IWebElement allocationsresulttable = viewresultscontainer.FindElement(By.CssSelector(".table"));
            allocationsresulttable.Should().NotBeNull();
            allocationsresulttable.Displayed.Should().BeTrue();
        }

        [Then(@"I can see a list of Allocation names and the subtotals against the Allocation names")]
        public void ThenICanSeeAListOfAllocationNamesAndTheSubtotalsAgainstTheAllocationNames()
        {
            IWebElement viewresultscontainer = viewproviderallocationspage.providerAllocationsPageProviderPolicyContainer;
            var allocationsresults = viewresultscontainer.FindElements(By.CssSelector(".table"));
            List<IWebElement> allocationElementList = new List<IWebElement>(allocationsresults);
            allocationElementList.Should().HaveCountGreaterThan(0, "Return elements expected");

            for (int i = 0; i < allocationElementList.Count; i++)
            {
                IWebElement currentElement = allocationElementList[i];
                currentElement.Should().NotBeNull("element {0} is null", i);

                IWebElement valueElement = currentElement.FindElement(By.TagName("tr"));

                valueElement.Should().NotBeNull("value element {0} is null", i);
                valueElement.Text.Should().NotBeNullOrEmpty("value element {0} does not contain value", i);
                Console.WriteLine(currentElement.Text);
            }
        }

        [Given(@"I am on the Allocation view")]
        public void GivenIAmOnTheAllocationView()
        {
            viewproviderallocationspage.providerAllocationsPageAllocationTab.Should().NotBeNull();
        }

        [When(@"I choose a new year from the drop down option")]
        public void WhenIChooseANewYearFromTheDropDownOption()
        {
            IWebElement academicyeardropdown = viewproviderallocationspage.providerAllocationsPageAcademicYearDropDown;
            academicyeardropdown.Should().NotBeNull();
            academicyeardropdown.Displayed.Should().BeTrue();
            IWebElement newyearselected = academicyeardropdown.FindElement(By.CssSelector("#FundingPeriodId > option:nth-child(4)"));
            newyearselected.Should().NotBeNull();
            newyearselected.Click();
            Thread.Sleep(2000);
            academicyeardropdown = viewproviderallocationspage.providerAllocationsPageAcademicYearDropDown;
            academicyeardropdown.Should().NotBeNull();
            academicyeardropdown.Displayed.Should().BeTrue();
            newyearselected = academicyeardropdown.FindElement(By.CssSelector("#FundingPeriodId > option:nth-child(4)"));
            newyearselected.Should().NotBeNull();
            string defaultyeardisplayed = newyearselected.Text;
            Console.WriteLine("The Selected Year displayed is " + defaultyeardisplayed);
        }

        [When(@"I choose to view the Calculation Tab")]
        public void WhenIChooseToViewTheCalculationTab()
        {
            viewproviderallocationspage.providerAllocationsPageCalculationTab.Should().NotBeNull();
            viewproviderallocationspage.providerAllocationsPageCalculationTab.Click();
            Thread.Sleep(2000);
        }

        [Then(@"I can see a list of Calculation names and the subtotals against the Calculation names")]
        public void ThenICanSeeAListOfCalculationNamesAndTheSubtotalsAgainstTheCalculationNames()
        {
            IWebElement viewresultscontainer = viewproviderallocationspage.providerAllocationsPageProviderPolicyContainer;
            var calculationresults = viewresultscontainer.FindElements(By.CssSelector(".table"));
            List<IWebElement> allocationElementList = new List<IWebElement>(calculationresults);
            allocationElementList.Should().HaveCountGreaterThan(0, "Return elements expected");

            for (int i = 0; i < allocationElementList.Count; i++)
            {
                IWebElement currentElement = allocationElementList[i];
                currentElement.Should().NotBeNull("element {0} is null", i);

                IWebElement valueElement = currentElement.FindElement(By.TagName("tr"));

                valueElement.Should().NotBeNull("value element {0} is null", i);
                valueElement.Text.Should().NotBeNullOrEmpty("value element {0} does not contain value", i);
                Console.WriteLine(currentElement.Text);
            }
        }

        [Then(@"a selectable tab is available to display the allocation results")]
        public void ThenASelectableTabIsAvailableToDisplayTheAllocationResults()
        {
            viewproviderallocationspage.providerAllocationsPageAllocationTab.Should().NotBeNull();
            viewproviderallocationspage.providerAllocationsPageAllocationTab.Displayed.Should().BeTrue();
        }


        [Then(@"where a provider record has a (.*) value the content No data found is displayed")]
        public void ThenWhereAProviderRecordHasAValueTheContentNoDataFoundIsDisplayed(int zerovalueproviderrecord)
        {
            var containerElements = Driver._driver.FindElement(By.CssSelector("div.providers-searchresult-container:nth-child(1)"));
            IWebElement firstNoDatafoundRecord = null;
            if (containerElements != null)
            {
                var options = containerElements.FindElements(By.TagName("p"));
                foreach (var optionelement in options)
                {
                    if (optionelement != null)
                    {
                        if (optionelement.Text.Contains("No data found"))
                        {

                            firstNoDatafoundRecord = optionelement;

                            break;
                        }

                    }
                }

                Thread.Sleep(1000);
                if (firstNoDatafoundRecord != null)
                {
                    string zeroproviderrecord = firstNoDatafoundRecord.Text;
                    Console.WriteLine("The following Provider record has a zero value: " + zeroproviderrecord);
                }
                else
                {
                    firstNoDatafoundRecord.Should().NotBeNull("Unable to find an item with No Data Found Provider Record");
                }
            }

        }


        [Then(@"I am presented the View Results landing page")]
        public void ThenIAmPresentedTheViewResultsLandingPage()
        {
            Thread.Sleep(2000);
            viewresultsoptionspage.viewResultsOptionsViewCalculationResults.Should().NotBeNull();
            viewresultsoptionspage.viewResultsOptionsViewProviderResults.Should().NotBeNull();
            viewresultsoptionspage.viewResultsOptionsViewQATestResults.Should().NotBeNull();
        }

        [Then(@"An option is displayed view the View provider results page")]
        public void ThenAnOptionIsDisplayedViewTheViewProviderResultsPage()
        {
            viewresultsoptionspage.viewResultsOptionsViewProviderResults.Displayed.Should().BeTrue();
        }

        [Then(@"An option is displayed view the View QA test results page")]
        public void ThenAnOptionIsDisplayedViewTheViewQATestResultsPage()
        {
            viewresultsoptionspage.viewResultsOptionsViewQATestResults.Displayed.Should().BeTrue();
        }

        [Then(@"An option is displayed view the View calculation results page")]
        public void ThenAnOptionIsDisplayedViewTheViewCalculationResultsPage()
        {
            viewresultsoptionspage.viewResultsOptionsViewCalculationResults.Displayed.Should().BeTrue();
        }

        [When(@"I click on the View QA test results option")]
        public void WhenIClickOnTheViewQATestResultsOption()
        {
            viewresultsoptionspage.viewResultsOptionsViewQATestResults.Should().NotBeNull();
            viewresultsoptionspage.viewResultsOptionsViewQATestResults.Click();
            Thread.Sleep(2000);
        }

        [Then(@"I am naviagted to the View QA test results page")]
        public void ThenIAmNaviagtedToTheViewQATestResultsPage()
        {
            viewqatestresultspage.viewQATestResultspageSearch.Should().NotBeNull();
        }

        [Given(@"I have navigated to the view all test results screen")]
        public void GivenIHaveNavigatedToTheViewAllTestResultsScreen()
        {
            NavigateTo.ViewQATestResults();
        }

        [Then(@"the Search QA Test option is displayed")]
        public void ThenTheSearchQATestOptionIsDisplayed()
        {
            viewqatestresultspage.viewQATestResultspageSearch.Should().NotBeNull();
        }

        [Then(@"the Select Period drop down option is displayed")]
        public void ThenTheSelectPeriodDropDownOptionIsDisplayed()
        {
            viewqatestresultspage.viewQATestResultspageYearDropDown.Should().NotBeNull();
        }

        [Then(@"the Select Specification drop down option is displayed")]
        public void ThenTheSelectSpecificationDropDownOptionIsDisplayed()
        {
            viewqatestresultspage.viewQATestResultspageSpecificationDropDown.Should().NotBeNull();
        }

        [Then(@"a list of QA Test Results listed by Test is displayed with the correct column headers")]
        public void ThenAListOfQATestResultsListedByTestIsDisplayedWithTheCorrectColumnHeaders()
        {
            viewqatestresultspage.viewQATestResultspageQATestResultList.Should().NotBeNull();

            IWebElement providerresultitemcontainer = viewqatestresultspage.viewQATestResultspageQATestResultList;
            var propertyElements = providerresultitemcontainer.FindElements(By.CssSelector("#calculation-results-table > thead:nth-child(1) > tr:nth-child(1)"));
            List<IWebElement> propertyElementList = new List<IWebElement>(propertyElements);
            propertyElementList.Should().HaveCountGreaterThan(0, "Return elements expected");

            for (int i = 0; i < propertyElementList.Count; i++)
            {
                IWebElement currentElement = propertyElementList[i];
                currentElement.Should().NotBeNull("element {0} is null", i);

                IWebElement valueElement = currentElement.FindElement(By.TagName("th"));

                valueElement.Should().NotBeNull("value element {0} is null", i);
                valueElement.Text.Should().NotBeNullOrEmpty("value element {0} does not contain value", i);
                Console.WriteLine("The following headers were displayed correctly: " + currentElement.Text);
            }
        }

        [Then(@"I am presented with a list of QA Test results")]
        public void ThenIAmPresentedWithAListOfQATestResults()
        {
            viewqatestresultspage.viewQATestResultspageQATestResultTable.Should().NotBeNull();
        }

        [Then(@"the appropriate information is displayed for each QA Test")]
        public void ThenTheAppropriateInformationIsDisplayedForEachQATest()
        {
            IWebElement providerresultitemcontainer = viewqatestresultspage.viewQATestResultspageQATestResultTable;
            var propertyElements = Driver._driver.FindElements(By.CssSelector("#dynamic-results-table-body > tr:nth-child(1)"));
            List<IWebElement> propertyElementList = new List<IWebElement>(propertyElements);
            propertyElementList.Should().HaveCountGreaterThan(0, "Return elements expected");

            for (int i = 0; i < propertyElementList.Count; i++)
            {
                IWebElement currentElement = propertyElementList[i];
                currentElement.Should().NotBeNull("element {0} is null", i);

                IWebElement valueElement = currentElement.FindElement(By.TagName("td"));

                valueElement.Should().NotBeNull("value element {0} is null", i);
                valueElement.Text.Should().NotBeNullOrEmpty("value element {0} does not contain value", i);
                Console.WriteLine("The following information was displayed correctly for each QA Test: " + currentElement.Text);
            }
        }

        [Given(@"I have over (.*) QA Tests displayed")]
        public void GivenIHaveOverQATestsDisplayed(int totaltestresults)
        {
            IWebElement qatestresultcount = viewqatestresultspage.viewQATestResultspagetotalResults;
            string endPageResultCount = qatestresultcount.Text;
            int endPageCount = int.Parse(endPageResultCount);
            endPageCount.Should().BeGreaterOrEqualTo(totaltestresults, "Less than 50 QA Test Results are available");
            Console.WriteLine("Total Page Results Displayed is " + qatestresultcount.Text);
        }

        [When(@"I click to navigate to the next page of (.*) QA Test Results")]
        public void WhenIClickToNavigateToTheNextPageOfQATestResults(int totaltestresults)
        {
            Actions.PaginationSelectPage();
            Thread.Sleep(2000);
        }

        [Then(@"my list view updates to display the next set of (.*) Results")]
        public void ThenMyListViewUpdatesToDisplayTheNextSetOfResults(int totaltestresults)
        {
            IWebElement qatestresultfirstrecord = viewqatestresultspage.viewQATestResultspagestartItemNumber;
            string firstPageResultCount = qatestresultfirstrecord.Text;
            int firstPageCount = int.Parse(firstPageResultCount);
            firstPageCount.Should().BeGreaterOrEqualTo(totaltestresults, "The next 50 Results have been displayed Incorrectly");
            Console.WriteLine("First Page Results Displayed is " + qatestresultfirstrecord.Text);
        }

        [Then(@"I am able to navigate to the previous page of (.*) Results")]
        public void ThenIAmAbleToNavigateToThePreviousPageOfResults(int totaltestresults)
        {
            Actions.PaginationSelectPage();
            Thread.Sleep(2000);
            IWebElement qatestresultcount = viewqatestresultspage.viewQATestResultspageendItemNumber;
            string endPageResultCount = qatestresultcount.Text;
            int endPageCount = int.Parse(endPageResultCount);
            endPageCount.Should().BeLessOrEqualTo(totaltestresults, "The previous 50 Results have been displayed Incorrectly");
            Console.WriteLine("Total Page Results Displayed is " + qatestresultcount.Text);
        }

        [When(@"I choose to search for an existing QA Test")]
        public void WhenIChooseToSearchForAnExistingQATest()
        {
            Actions.SearchQATestResultsPageByQATestName();
            Thread.Sleep(6000);
        }

        [Then(@"The list of QA Test Results is updated to display the correct QA Test")]
        public void ThenTheListOfQATestResultsIsUpdatedToDisplayTheCorrectQATest()
        {
            string testName = ScenarioContext.Current["QATestName"] as string;
            testName.Should().NotBeNullOrEmpty();

            ViewQATestResultsPage viewqatestresultspage = new ViewQATestResultsPage();

            var containerElements = viewqatestresultspage.viewQATestResultspageQATestResultTable;
            IWebElement SelectFirstTest = null;
            if (containerElements != null)
            {
                var options = containerElements.FindElements(By.CssSelector("td a"));
                foreach (var optionelement in options)
                {
                    if (optionelement != null && optionelement.Text == testName)
                    {

                        SelectFirstTest = optionelement;
                        Console.WriteLine(testName + " QA Test Result correctly found");

                        break;


                    }
                }
                Thread.Sleep(1000);

                SelectFirstTest.Should().NotBeNull("Unable to find the result " + testName);

            }
            else
            {
                SelectFirstTest.Should().NotBeNull("No QA Test was successfully found");
            }
        }

        [When(@"I change the selected QA Test period drop down to (.*)")]
        public void WhenIChangeTheSelectedQATestPeriodDropDownTo(string year)
        {
            var selectYear = viewqatestresultspage.viewQATestResultspageYearDropDown;
            var selectElement = new SelectElement(selectYear);
            selectElement.SelectByValue(year);
            Thread.Sleep(20000);
        }

        [Then(@"the list of QA Test Results refreshes to display the selected years QA Tests")]
        public void ThenTheListOfQATestResultsRefreshesToDisplayTheSelectedYearsQATests()
        {
            IWebElement qatestresultcount = viewqatestresultspage.viewQATestResultspagetotalResults;
            string endPageResultCount = qatestresultcount.Text;
            int endPageCount = int.Parse(endPageResultCount);
            endPageCount.Should().BeGreaterOrEqualTo(0, "The selected years results have not been returned correctly");
            Console.WriteLine("The total results displayed on for the selected year is: " + endPageCount);
        }

        [When(@"I change the selected QA Test specificaiton drop down to (.*)")]
        public void WhenIChangeTheSelectedQATestSpecificaitonDropDownToYPLearnerResponsive(string specification)
        {
            var selectSpecification = viewqatestresultspage.viewQATestResultspageSpecificationDropDown;
            selectSpecification.Click();
            var selectElement = new SelectElement(selectSpecification);
            selectElement.SelectByText(specification);
            Thread.Sleep(20000);
        }

        [Then(@"the list of QA Test Results refreshes to display the selected specifications QA Tests")]
        public void ThenTheListOfQATestResultsRefreshesToDisplayTheSelectedSpecificationsQATests()
        {
            IWebElement qatestresultcount = viewqatestresultspage.viewQATestResultspagetotalResults;
            string endPageResultCount = qatestresultcount.Text;
            int endPageCount = int.Parse(endPageResultCount);
            endPageCount.Should().BeGreaterOrEqualTo(0, "The selected specifications results have not been returned correctly");
            Console.WriteLine("The total results displayed on for the selected specification is: " + endPageCount);
        }

        [When(@"I choose a QA Test from the displayed list of tests")]
        public void WhenIChooseAQATestFromTheDisplayedListOfTests()
        {
            Actions.SelectQATestResultByQATestName();
            Thread.Sleep(2000);
        }

        [Then(@"I am redirected to the selected QA Test results for all providers page")]
        public void ThenIAmRedirectedToTheSelectedQATestResultsForAllProvidersPage()
        {
            viewtestresultsallproviders.singleTestProviderResultsSearchField.Should().NotBeNull();
        }

        [Given(@"I choose a QA Test from the displayed list of tests")]
        public void GivenIChooseAQATestFromTheDisplayedListOfTests()
        {
            Actions.SelectQATestResultByQATestName();
            Thread.Sleep(2000);
        }

        [When(@"I am redirected to the selected QA Test results for all providers page")]
        public void WhenIAmRedirectedToTheSelectedQATestResultsForAllProvidersPage()
        {
            viewtestresultsallproviders.singleTestProviderResultsSearchField.Should().NotBeNull();
        }

        [Then(@"A Search Filter option is correctly displayed")]
        public void ThenASearchFilterOptionIsCorrectlyDisplayed()
        {
            viewtestresultsallproviders.singleTestProviderResultsSearchField.Should().NotBeNull();
        }

        [Then(@"A Provider Type Filter drop Down is correctly displayed")]
        public void ThenAProviderTypeFilterDropDownIsCorrectlyDisplayed()
        {
            viewtestresultsallproviders.singleTestProviderResultsSelectProviderType.Should().NotBeNull();
        }

        [Then(@"A Provider Sub Type Filter drop down is correctly displayed")]
        public void ThenAProviderSubTypeFilterDropDownIsCorrectlyDisplayed()
        {
            viewtestresultsallproviders.singleTestProviderResultsSelectProviderSubType.Should().NotBeNull();
        }

        [Then(@"A Local Authority Filter drop down is correctly displayed")]
        public void ThenALocalAuthorityFilterDropDownIsCorrectlyDisplayed()
        {
            viewtestresultsallproviders.singleTestProviderResultsSelectLocalAuthority.Should().NotBeNull();
        }


        [Then(@"the page lists up to the first (.*) Providers")]
        public void ThenThePageListsUpToTheFirstProviders(int endPageListCount)
        {
            IWebElement testresultsallprovidersResultCount = viewtestresultsallproviders.singleTestProviderResultsProviderListEndCount;
            string endPageResultCount = testresultsallprovidersResultCount.Text;
            int endPageCount = int.Parse(endPageResultCount);
            endPageCount.Should().BeLessOrEqualTo(endPageListCount, "More than 50 Results are displayed on this Page");
            Console.WriteLine("Total Page Results Displayed is " + testresultsallprovidersResultCount.Text);
        }

        [When(@"there are more than (.*) Providers returned")]
        public void WhenThereAreMoreThanProvidersReturned(int totalPageListCount)
        {
            IWebElement testresultsalltotalResultCount = viewtestresultsallproviders.singleTestProviderResultsProviderListTotalCount;
            string totalPageResultCount = testresultsalltotalResultCount.Text;
            int totalPageCount = int.Parse(totalPageResultCount);
            totalPageCount.Should().BeGreaterOrEqualTo(totalPageListCount, "Less than " + totalPageListCount + "Results are displayed on this Page");
            Console.WriteLine("The Total results returned is " + totalPageCount);
        }

        [When(@"I click to navigate to the next page of (.*) providers test results")]
        public void WhenIClickToNavigateToTheNextPageOfProvidersTestResults(int p0)
        {
            Actions.PaginationSelectPage();
            Thread.Sleep(2000);
        }

        [Then(@"my page list view displays the next (.*) test results")]
        public void ThenMyPageListViewDisplaysTheNextTestResults(int endPageListCount)
        {
            IWebElement testresultsallprovidersResultCount = viewtestresultsallproviders.singleTestProviderResultsProviderListEndCount;
            string endPageResultCount = testresultsallprovidersResultCount.Text;
            int endPageCount = int.Parse(endPageResultCount);
            endPageCount.Should().BeGreaterOrEqualTo(endPageListCount, "Less than 50 Results are displayed on this Page");
            Console.WriteLine("Total Page Results Displayed is " + testresultsallprovidersResultCount.Text);
        }

        [Then(@"I am able to navigate to the previous page of (.*) providers test results")]
        public void ThenIAmAbleToNavigateToThePreviousPageOfProvidersTestResults(int endPageListCount)
        {
            Actions.PaginationSelectPage();
            Thread.Sleep(2000);

            IWebElement testresultsallprovidersResultCount = viewtestresultsallproviders.singleTestProviderResultsProviderListEndCount;
            string endPageResultCount = testresultsallprovidersResultCount.Text;
            int endPageCount = int.Parse(endPageResultCount);
            endPageCount.Should().BeLessOrEqualTo(endPageListCount, "More than 50 Results are displayed on this Page");
            Console.WriteLine("Total Page Results Displayed is " + testresultsallprovidersResultCount.Text);

        }


        [Then(@"The name of the provider for the single test is displayed")]
        public void ThenTheNameOfTheProviderForTheSingleTestIsDisplayed()
        {
            IWebElement providerresultslistcontainer = viewtestresultsallproviders.singleTestProviderResultsProviderResultsList;
            IWebElement providernameexists = providerresultslistcontainer.FindElement(By.CssSelector("div.provider-item-header a"));
            providernameexists.Should().NotBeNull();
            providernameexists.Displayed.Should().BeTrue();
            string providername = providernameexists.Text;
            Console.WriteLine("The Provider Name Displayed is: " + providername);
        }

        [Then(@"all the relevant provider details for the single are displayed")]
        public void ThenAllTheRelevantProviderDetailsForTheSingleAreDisplayed()
        {
            IWebElement providerresultitemcontainer = viewtestresultsallproviders.singleTestProviderResultsProviderResultsListContainer;
            var propertyElements = providerresultitemcontainer.FindElements(By.CssSelector("span.provider-item-property"));
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


        [Then(@"the QA Test Result for the provider is displayed")]
        public void ThenTheQATestResultForTheProviderIsDisplayed()
        {
            IWebElement providerresultslistcontainer = viewtestresultsallproviders.singleTestProviderResultsProviderResultsList;
            IWebElement providerresultexists = providerresultslistcontainer.FindElement(By.CssSelector("div.provider-item-header span"));
            providerresultexists.Should().NotBeNull();
            providerresultexists.Displayed.Should().BeTrue();
            string providerresult = providerresultexists.Text;
            Console.WriteLine("The QA Test Result for this Provider is: " + providerresult);
        }


        [Then(@"details of the Test selected are displayed on the page correctly")]
        public void ThenDetailsOfTheTestSelectedAreDisplayedOnThePageCorrectly()
        {
            IWebElement providerresultitemcontainer = viewtestresultsallproviders.singleTestProviderResultsQATestInfo;
            var propertyElements = providerresultitemcontainer.FindElements(By.CssSelector("p.alert__message"));
            List<IWebElement> propertyElementList = new List<IWebElement>(propertyElements);
            propertyElementList.Should().HaveCountGreaterThan(0, "Return elements expected");

            for (int i = 0; i < propertyElementList.Count; i++)
            {
                IWebElement currentElement = propertyElementList[i];
                currentElement.Should().NotBeNull("element {0} is null", i);

                IWebElement valueElement = currentElement.FindElement(By.TagName("span"));

                valueElement.Should().NotBeNull("value element {0} is null", i);
                valueElement.Text.Should().NotBeNullOrEmpty("value element {0} does not contain value", i);
                Console.WriteLine("Selected QA Test Details displayed are: " + currentElement.Text);
            }
        }

        [When(@"I decide to filter my results by using the search filter")]
        public void WhenIDecideToFilterMyResultsByUsingTheSearchFilter()
        {
            IWebElement testresultsalltotalResultCount = viewtestresultsallproviders.singleTestProviderResultsProviderListTotalCount;
            string totalPageResultCount = testresultsalltotalResultCount.Text;
            int totalPageCount = int.Parse(totalPageResultCount);
            Console.WriteLine("The Total results returned is " + totalPageCount);
            ScenarioContext.Current["totalResults"] = totalPageResultCount;

            viewtestresultsallproviders.singleTestProviderResultsSearchField.SendKeys(searchtext);
            viewtestresultsallproviders.singleTestProviderResultsSearchButton.Click();
            Thread.Sleep(5000);
        }


        [Then(@"the Provider Results list is refreshed to display only the providers that comply with the filter selected")]
        public void ThenTheProviderResultsListIsRefreshedToDisplayOnlyTheProvidersThatComplyWithTheFilterSelected()
        {
            string totalPageListCount = ScenarioContext.Current["totalResults"] as string;
            int initialTotalPageCount = int.Parse(totalPageListCount);

            IWebElement testresultsalltotalResultCount = viewtestresultsallproviders.singleTestProviderResultsProviderListTotalCount;
            string totalPageResultCount = testresultsalltotalResultCount.Text;
            int newTotalPageCount = int.Parse(totalPageResultCount);
            newTotalPageCount.Should().BeLessOrEqualTo(initialTotalPageCount, "More than the initial unfiltered result count of " + initialTotalPageCount + " are being displayed on this Page");
            Console.WriteLine("The New Filtered Total results returned is " + newTotalPageCount);
        }


        [When(@"I decide to filter my results by using the Provider Type Filter")]
        public void WhenIDecideToFilterMyResultsByUsingTheProviderTypeFilter()
        {
            IWebElement testresultsalltotalResultCount = viewtestresultsallproviders.singleTestProviderResultsProviderListTotalCount;
            string totalPageResultCount = testresultsalltotalResultCount.Text;
            int totalPageCount = int.Parse(totalPageResultCount);
            Console.WriteLine("The Total results returned is " + totalPageCount);
            ScenarioContext.Current["totalResults"] = totalPageResultCount;

            IWebElement selectProviderDropdown = viewtestresultsallproviders.singleTestProviderResultsSelectProviderType;
            selectProviderDropdown.Click();
            var selectProviderOption = Driver._driver.FindElements(By.CssSelector(".open > ul > li"));
            IWebElement firstProviderOption = selectProviderOption.FirstOrDefault();

            if (firstProviderOption != null)
            {
                firstProviderOption.Click();
                string selectedProviderOption = firstProviderOption.Text;
                Thread.Sleep(2000);
                viewtestresultsallproviders.singleTestProviderResultsSelectProviderType.Click();
                Console.WriteLine("Provider Option selected is: " + selectedProviderOption);
            }
            else
            {
                firstProviderOption.Should().NotBeNull("Unable to find Provider Option to select");
            }

        }


        [When(@"I decide to filter my results by using the Provider Sub Type Filter")]
        public void WhenIDecideToFilterMyResultsByUsingTheProviderSubTypeFilter()
        {
            IWebElement testresultsalltotalResultCount = viewtestresultsallproviders.singleTestProviderResultsProviderListTotalCount;
            string totalPageResultCount = testresultsalltotalResultCount.Text;
            int totalPageCount = int.Parse(totalPageResultCount);
            Console.WriteLine("The Total results returned is " + totalPageCount);
            ScenarioContext.Current["totalResults"] = totalPageResultCount;

            IWebElement selectProviderSubDropdown = viewtestresultsallproviders.singleTestProviderResultsSelectProviderSubType;
            selectProviderSubDropdown.Click();
            var selectProviderSubOption = Driver._driver.FindElements(By.CssSelector(".open > ul > li"));
            IWebElement firstProviderSubOption = selectProviderSubOption.FirstOrDefault();

            if (firstProviderSubOption != null)
            {
                firstProviderSubOption.Click();
                string selectedProviderSubOption = firstProviderSubOption.Text;
                Thread.Sleep(2000);
                viewtestresultsallproviders.singleTestProviderResultsSelectProviderSubType.Click();
                Console.WriteLine("Provider Sub Type Option selected is: " + selectedProviderSubOption);
            }
            else
            {
                firstProviderSubOption.Should().NotBeNull("Unable to find Provider Sub Type Option to select");
            }

        }


        [When(@"I decide to filter my results by using the Local Authority Filter")]
        public void WhenIDecideToFilterMyResultsByUsingTheLocalAuthorityFilter()
        {
            IWebElement testresultsalltotalResultCount = viewtestresultsallproviders.singleTestProviderResultsProviderListTotalCount;
            string totalPageResultCount = testresultsalltotalResultCount.Text;
            int totalPageCount = int.Parse(totalPageResultCount);
            Console.WriteLine("The Total results returned is " + totalPageCount);
            ScenarioContext.Current["totalResults"] = totalPageResultCount;

            IWebElement selectLocalAuthDropdown = viewtestresultsallproviders.singleTestProviderResultsSelectProviderSubType;
            selectLocalAuthDropdown.Click();
            var selectLocalAuthOption = Driver._driver.FindElements(By.CssSelector(".open > ul > li"));
            IWebElement firstLocalAuthOption = selectLocalAuthOption.FirstOrDefault();

            if (firstLocalAuthOption != null)
            {
                firstLocalAuthOption.Click();
                string selectedLocalAuthOption = firstLocalAuthOption.Text;
                Thread.Sleep(2000);
                viewtestresultsallproviders.singleTestProviderResultsSelectLocalAuthority.Click();
                Console.WriteLine("Provider Sub Type Option selected is: " + selectedLocalAuthOption);
            }
            else
            {
                firstLocalAuthOption.Should().NotBeNull("Unable to find Local Authority Option to select");
            }
        }


        [Given(@"I have navigated to the Provider results for an Individual Provider Page")]
        public void GivenIHaveNavigatedToTheProviderResultsForAnIndividualProviderPage()
        {
            NavigateTo.ViewProviderAllocationsPage();
            Thread.Sleep(2000);
        }

        [Then(@"a tab is displayed to show the Allocation Line results")]
        public void ThenATabIsDisplayedToShowTheAllocationLineResults()
        {
            viewproviderallocationspage.providerAllocationsPageAllocationTab.Should().NotBeNull();

        }

        [Then(@"a tab is displayed to show the Calculation results")]
        public void ThenATabIsDisplayedToShowTheCalculationResults()
        {
            viewproviderallocationspage.providerAllocationsPageCalculationTab.Should().NotBeNull();
        }

        [Then(@"a tab is displayed to show the Test results")]
        public void ThenATabIsDisplayedToShowTheTestResults()
        {
            viewproviderallocationspage.providerAllocationsPageTestTab.Should().NotBeNull();
        }

        [Then(@"the drop down option to select an academic year is displayed")]
        public void ThenTheDropDownOptionToSelectAnAcademicYearIsDisplayed()
        {
            viewproviderallocationspage.providerAllocationsPageAcademicYearDropDown.Should().NotBeNull();
        }

        [Then(@"the drop down option to select a specification is displayed")]
        public void ThenTheDropDownOptionToSelectASpecificationIsDisplayed()
        {
            viewproviderallocationspage.providerAllocationsPageSpecificationDropDown.Should().NotBeNull();
        }



        [Given(@"I have created a New Specification")]
        public void GivenIHaveCreatedANewSpecification()
        {
            CreateNewSpecification.CreateANewSpecification();
        }

        [Given(@"I have created a New Policy for that Specification")]
        public void GivenIHaveCreatedANewPolicyForThatSpecification()
        {
            ManageSpecificationCreateNewPolicy.CreateANewSpecificationPolicy();
        }

        [Given(@"I have created a New Calculation Specification for that Specification")]
        public void GivenIHaveCreatedANewCalculationSpecificationForThatSpecification()
        {
            ManageSpecificationCreateNewCalculationSpecification.CreateANewSpecificationPolicy();
        }

        [Given(@"I have create a New Dataset for that Specificaton")]
        public void GivenIHaveCreateANewDatasetForThatSpecificaton()
        {
            ManageSpecificationCreateNewProviderDataset.CreateANewProviderDataset();
        }

        [When(@"I have specified a data Source Relationship for the Specification")]
        public void WhenIHaveSpecifiedADataSourceRelationshipForTheSpecification()
        {
            CreateDataSourceMapping.CreateADataSourceMapping();
        }

        [When(@"I edit the New Calculation for that Specification")]
        public void WhenIEditTheNewCalculationForThatSpecification()
        {
            EditNewCalculaton.EditANewCalculaton();
        }

        [When(@"I have created a New Test for the Specification")]
        public void WhenIHaveCreatedANewTestForTheSpecification()
        {
            CreateNewQATest.CreateANewQATest();
        }

        [When(@"I then select the appropriate Test from the View provider results list page")]
        public void WhenIThenSelectTheAppropriateTestFromTheViewProviderResultsListPage()
        {
            homepage.Header.Click();
            Thread.Sleep(2000);

            NavigateTo.ViewQATestResults();

            var qaTestName = ScenarioContext.Current["QATestName"];
            string qaTestcreated = qaTestName.ToString();
            Driver._driver.FindElement(By.LinkText(qaTestcreated)).Should().NotBeNull();
            Driver._driver.FindElement(By.LinkText(qaTestcreated)).Click();
            Thread.Sleep(2000);
        }

        [Then(@"I can select the Provider with a Passed Test Result from the View provider results for an Individual Provider Page")]
        public void ThenICanSelectTheProviderWithAPassedTestResultFromTheViewProviderResultsForAnIndividualProviderPage()
        {
            Actions.SelectProviderWhereQATestResultMarkedPassed();
            Thread.Sleep(2000);
        }


        [Then(@"I can click on the Test Tab to view the Test result for the Individual Provider and Specification")]
        public void ThenICanClickOnTheTestTabToViewTheTestResultForTheIndividualProviderAndSpecification()
        {
            viewproviderallocationspage.providerAllocationsPageTestTab.Should().NotBeNull();
            viewproviderallocationspage.providerAllocationsPageTestTab.Click();
            Thread.Sleep(2000);
        }

        [Then(@"the Provider List of Test results for the selected QA Test is displayed")]
        public void ThenTheProviderListOfTestResultsForTheSelectedQATestIsDisplayed()
        {
            Thread.Sleep(2000);
            viewproviderresultspage.providerResultspageResultListContainer.Should().NotBeNull();
        }

        [Then(@"a Provider where the QA Test has Passed can be selected to display the specific QA Test Result")]
        public void ThenAProviderWhereTheQATestHasPassedCanBeSelectedToDisplayTheSpecificQATestResult()
        {
            Actions.SelectProviderWhereQATestResultMarkedPassed();
            Thread.Sleep(2000);
            viewproviderallocationspage.providerAllocationsPageTestTab.Should().NotBeNull();
            viewproviderallocationspage.providerAllocationsPageTestTab.Click();
        }

        [Then(@"the QA Test Coverage for the Provider is displayed correctly")]
        public void ThenTheQATestCoverageForTheProviderIsDisplayedCorrectly()
        {
            var providerresultitemcontainer = viewproviderallocationspage.providerAllocationsPageTestTabResultsAlert;
            string providerresults = providerresultitemcontainer.Text;
            Console.WriteLine("The Test Result Coverage for this QA Test is: " + providerresults);
        }



        [Then(@"the QA Test Results for the Provider are displayed correctly")]
        public void ThenTheQATestResultsForTheProviderAreDisplayedCorrectly()
        {
            IWebElement viewresultscontainer = viewproviderallocationspage.providerAllocationsPageTestTabSearchResultsContainer;
            var allocationsresults = viewresultscontainer.FindElements(By.CssSelector(".table"));
            List<IWebElement> allocationElementList = new List<IWebElement>(allocationsresults);
            allocationElementList.Should().HaveCountGreaterThan(0, "Return elements expected");

            for (int i = 0; i < allocationElementList.Count; i++)
            {
                IWebElement currentElement = allocationElementList[i];
                currentElement.Should().NotBeNull("element {0} is null", i);

                IWebElement valueElement = currentElement.FindElement(By.TagName("tr"));

                valueElement.Should().NotBeNull("value element {0} is null", i);
                valueElement.Text.Should().NotBeNullOrEmpty("value element {0} does not contain value", i);
                Console.WriteLine(currentElement.Text);
            }
        }

        [Then(@"I can select the Provider with a Failed Test Result from the View provider results for an Individual Provider Page")]
        public void ThenICanSelectTheProviderWithAFailedTestResultFromTheViewProviderResultsForAnIndividualProviderPage()
        {
            Actions.SelectProviderWhereQATestResultMarkedFailed();
            Thread.Sleep(2000);
        }

        [Then(@"a Provider where the QA Test has Failed can be selected to display the specific QA Test Result")]
        public void ThenAProviderWhereTheQATestHasFailedCanBeSelectedToDisplayTheSpecificQATestResult()
        {
            Actions.SelectProviderWhereQATestResultMarkedFailed();
            Thread.Sleep(2000);
            viewproviderallocationspage.providerAllocationsPageTestTab.Should().NotBeNull();
            viewproviderallocationspage.providerAllocationsPageTestTab.Click();
        }

        [When(@"I click on the View calculation results option")]
        public void WhenIClickOnTheViewCalculationResultsOption()
        {
            viewresultsoptionspage.viewResultsOptionsViewCalculationResults.Should().NotBeNull();
            viewresultsoptionspage.viewResultsOptionsViewCalculationResults.Click();
            Thread.Sleep(2000);
        }

        [Then(@"I am redirected to the View calculation results Page")]
        public void ThenIAmRedirectedToTheViewCalculationResultsPage()
        {
            viewcalculationresultpage.viewcalculationPageSearchField.Should().NotBeNull();
        }


        [Given(@"I have successfully navigated to the View Calculation Page")]
        public void GivenIHaveSuccessfullyNavigatedToTheViewCalculationPage()
        {
            NavigateTo.ViewCalculationResultsPage();
        }

        [Then(@"the Search option filter is displayed correctly")]
        public void ThenTheSearchOptionFilterIsDisplayedCorrectly()
        {
            viewcalculationresultpage.viewcalculationPageSearchField.Should().NotBeNull();
        }

        [Then(@"the Allocation Line Dropdown option is displayed correctly")]
        public void ThenTheAllocationLineDropdownOptionIsDisplayedCorrectly()
        {
            viewcalculationresultpage.viewcalculationPageAllocationLineDropDown.Should().NotBeNull();
        }

        [Then(@"the Funding Period Dropdown option is displayed correctly")]
        public void ThenTheFundingPeriodDropdownOptionIsDisplayedCorrectly()
        {
            viewcalculationresultpage.viewcalculationPageFundingPeriodDropDown.Should().NotBeNull();
        }

        [Then(@"the Funding Stream Dropdown option is displayed correctly")]
        public void ThenTheFundingStreamDropdownOptionIsDisplayedCorrectly()
        {
            viewcalculationresultpage.viewcalculationPageFundingStreamDropDown.Should().NotBeNull();
        }

        [Then(@"the Specificaiton Name Dropdown option is displayed correctly")]
        public void ThenTheSpecificaitonNameDropdownOptionIsDisplayedCorrectly()
        {
            viewcalculationresultpage.viewcalculationPageSpecnameDropDown.Should().NotBeNull();
        }

        [Then(@"the Calculation Status Dropdown option is displayed correctly")]
        public void ThenTheCalculationStatusDropdownOptionIsDisplayedCorrectly()
        {
            viewcalculationresultpage.viewcalculationPageCalculationStatusDropDown.Should().NotBeNull();
        }

        [Given(@"I have over (.*) calculations")]
        public void GivenIHaveOverCalculations(int totalItemCount)
        {
            IWebElement calculationtotalResultCount = viewcalculationresultpage.viewcalculationPageTotalResultcount;
            string totalPageResultCount = calculationtotalResultCount.Text;
            int totalPageCount = int.Parse(totalPageResultCount);

            if (totalPageCount < totalItemCount)
            {
                Assert.Inconclusive("Only 1 page of results is displayed as the Total results returned is less than " + totalItemCount);

            }
            else
            {
                Console.WriteLine("The Total results returned is " + totalPageCount);
            }
        }

        [When(@"I click to navigate to the next page of (.*) calculations")]
        public void WhenIClickToNavigateToTheNextPageOfCalculations(int endItemCount)
        {
            Actions.PaginationSelectPage();
            Thread.Sleep(2000);
        }

        [Then(@"my list view displays the next (.*) calculations")]
        public void ThenMyListViewDisplaysTheNextCalculations(int startItemCount)
        {
            IWebElement calculationstartResultCount = viewcalculationresultpage.viewcalculationPageStartItemCount;
            string startPageResultCount = calculationstartResultCount.Text;
            int startPageCount = int.Parse(startPageResultCount);
            startPageCount.Should().BeGreaterOrEqualTo(startItemCount, "Less than " + startItemCount + "Results are displayed on this Page");

        }

        [Then(@"I am able to navigate to the previous page of (.*) calculations")]
        public void ThenIAmAbleToNavigateToThePreviousPageOfCalculations(int endItemCount)
        {
            Actions.PaginationSelectPage();
            Thread.Sleep(2000);

            IWebElement calculationendResultCount = viewcalculationresultpage.viewcalculationPageTotalResultcount;
            string totalPageResultCount = calculationendResultCount.Text;
            int totalPageCount = int.Parse(totalPageResultCount);
            totalPageCount.Should().BeLessOrEqualTo(endItemCount, "Less than " + endItemCount + "Results are displayed on this Page");

        }

        [Then(@"a list of calculations is displayed with the correct column headers")]
        public void ThenAListOfCalculationsIsDisplayedWithTheCorrectColumnHeaders()
        {
            IWebElement calculationsResultTable = viewcalculationresultpage.viewcalculationPageCalculationResultsTable;
            calculationsResultTable.Should().NotBeNull();
            var calculationHeaders = calculationsResultTable.FindElements(By.CssSelector("tr th"));
            List<IWebElement> calculationheaderText = new List<IWebElement>(calculationHeaders);
            calculationheaderText.Should().HaveCountGreaterThan(0, "Return elements expected");

            for (int i = 0; i < calculationheaderText.Count; i++)
            {
                IWebElement currentElement = calculationheaderText[i];
                currentElement.Should().NotBeNull("element {0} is null", i);

                currentElement.Should().NotBeNull("value element {0} is null", i);
                currentElement.Text.Should().NotBeNullOrEmpty("value element {0} does not contain value", i);
                Console.WriteLine(currentElement.Text);
            }
        }

        [Then(@"the appropriate calculation information is displayed in the list")]
        public void ThenTheAppropriateCalculationInformationIsDisplayedInTheList()
        {
            IWebElement viewresultscontainer = viewcalculationresultpage.viewcalculationPageCalculationResultsListContainer;
            var calculationresults = viewresultscontainer.FindElements(By.CssSelector("#dynamic-results-table-body > tr:nth-child(1)"));
            List<IWebElement> calculationElementList = new List<IWebElement>(calculationresults);
            calculationElementList.Should().HaveCountGreaterThan(0, "Return elements expected");

            for (int i = 0; i < calculationElementList.Count; i++)
            {
                IWebElement currentElement = calculationElementList[i];
                currentElement.Should().NotBeNull("element {0} is null", i);

                IWebElement valueElement = currentElement.FindElement(By.TagName("td"));

                valueElement.Should().NotBeNull("value element {0} is null", i);
                valueElement.Text.Should().NotBeNullOrEmpty("value element {0} does not contain value", i);
                Console.WriteLine(currentElement.Text);
            }
        }

        [When(@"I choose to filter the results by Funding Period")]
        public void WhenIChooseToFilterTheResultsByFundingPeriod()
        {
            IWebElement calculationtotalResultCount = viewcalculationresultpage.viewcalculationPageTotalResultcount;
            string totalPageResultCount = calculationtotalResultCount.Text;
            int totalPageCount = int.Parse(totalPageResultCount);
            ScenarioContext.Current["TotalResultCount"] = totalPageCount;
            Console.WriteLine("The Total Number of Calculations displayed is: " + totalPageCount);

            IWebElement filtercontainer = viewcalculationresultpage.viewcalculationPageFundingPeriodDropDown;
            IWebElement fundingperiodfilter = filtercontainer.FindElement(By.CssSelector("button"));
            fundingperiodfilter.Click();
            Thread.Sleep(2000);
            IWebElement selectfilteroption = filtercontainer.FindElement(By.CssSelector("label"));
            string providertypeselected = selectfilteroption.Text;
            Console.WriteLine("Funding Period Filter Option selected = " + providertypeselected);
            selectfilteroption.Click();
            Thread.Sleep(2000);
            fundingperiodfilter.Click();
            Thread.Sleep(2000);

        }

        [Then(@"the calculation results are updated accordingly")]
        public void ThenTheCalculationResultsAreUpdatedAccordingly()
        {
            IWebElement newcalculationtotalResultCount = viewcalculationresultpage.viewcalculationPageTotalResultcount;
            string newtotalPageResultCount = newcalculationtotalResultCount.Text;
            int newtotalPageCount = int.Parse(newtotalPageResultCount);
            var unfilteredpagecount = ScenarioContext.Current["TotalResultCount"];
            string unfilteredpagecountext = unfilteredpagecount.ToString();
            int originalpagecount = int.Parse(unfilteredpagecountext);
            newtotalPageCount.Should().BeLessOrEqualTo(originalpagecount, "there has been an error in filtering the results by Funding Period");
            Console.WriteLine("The new Filtered Total of Calculations displayed is: " + newtotalPageCount);
        }


        [When(@"I choose to filter the results by Funding Stream")]
        public void WhenIChooseToFilterTheResultsByFundingStream()
        {
            IWebElement calculationtotalResultCount = viewcalculationresultpage.viewcalculationPageTotalResultcount;
            string totalPageResultCount = calculationtotalResultCount.Text;
            int totalPageCount = int.Parse(totalPageResultCount);
            ScenarioContext.Current["TotalResultCount"] = totalPageCount;
            Console.WriteLine("The Total Number of Calculations displayed is: " + totalPageCount);

            IWebElement filtercontainer = viewcalculationresultpage.viewcalculationPageFundingStreamDropDown;
            IWebElement fundingstreamfilter = filtercontainer.FindElement(By.CssSelector("button"));
            fundingstreamfilter.Click();
            Thread.Sleep(2000);
            IWebElement selectfilteroption = filtercontainer.FindElement(By.CssSelector("label"));
            string providertypeselected = selectfilteroption.Text;
            Console.WriteLine("Funding Stream Filter Option selected = " + providertypeselected);
            selectfilteroption.Click();
            Thread.Sleep(2000);
            fundingstreamfilter.Click();
            Thread.Sleep(2000);
        }

        [When(@"I choose to filter the results by Spec Name")]
        public void WhenIChooseToFilterTheResultsBySpecName()
        {
            IWebElement calculationtotalResultCount = viewcalculationresultpage.viewcalculationPageTotalResultcount;
            string totalPageResultCount = calculationtotalResultCount.Text;
            int totalPageCount = int.Parse(totalPageResultCount);
            ScenarioContext.Current["TotalResultCount"] = totalPageCount;
            Console.WriteLine("The Total Number of Calculations displayed is: " + totalPageCount);

            IWebElement filtercontainer = viewcalculationresultpage.viewcalculationPageSpecnameDropDown;
            IWebElement specnamefilter = filtercontainer.FindElement(By.CssSelector("button"));
            specnamefilter.Click();
            Thread.Sleep(2000);
            IWebElement selectfilteroption = filtercontainer.FindElement(By.CssSelector("label"));
            string providertypeselected = selectfilteroption.Text;
            Console.WriteLine("Spec Name Filter Option selected = " + providertypeselected);
            selectfilteroption.Click();
            Thread.Sleep(2000);
            specnamefilter.Click();
            Thread.Sleep(2000);
        }


        [When(@"I choose to filter the results by Calculation Status")]
        public void WhenIChooseToFilterTheResultsByCalculationStatus()
        {
            IWebElement calculationtotalResultCount = viewcalculationresultpage.viewcalculationPageTotalResultcount;
            string totalPageResultCount = calculationtotalResultCount.Text;
            int totalPageCount = int.Parse(totalPageResultCount);
            ScenarioContext.Current["TotalResultCount"] = totalPageCount;
            Console.WriteLine("The Total Number of Calculations displayed is: " + totalPageCount);

            IWebElement filtercontainer = viewcalculationresultpage.viewcalculationPageCalculationStatusDropDown;
            IWebElement calcstatusfilter = filtercontainer.FindElement(By.CssSelector("button"));
            calcstatusfilter.Click();
            Thread.Sleep(2000);
            IWebElement selectfilteroption = filtercontainer.FindElement(By.CssSelector("label"));
            string providertypeselected = selectfilteroption.Text;
            Console.WriteLine("Calculation Status Filter Option selected = " + providertypeselected);
            selectfilteroption.Click();
            Thread.Sleep(2000);
            calcstatusfilter.Click();
            Thread.Sleep(2000);
        }

        [When(@"I choose to filter the results by Allocation Line")]
        public void WhenIChooseToFilterTheResultsByAllocationLine()
        {
            IWebElement calculationtotalResultCount = viewcalculationresultpage.viewcalculationPageTotalResultcount;
            string totalPageResultCount = calculationtotalResultCount.Text;
            int totalPageCount = int.Parse(totalPageResultCount);
            ScenarioContext.Current["TotalResultCount"] = totalPageCount;
            Console.WriteLine("The Total Number of Calculations displayed is: " + totalPageCount);

            IWebElement filtercontainer = viewcalculationresultpage.viewcalculationPageAllocationLineDropDown;
            IWebElement allocationlinefilter = filtercontainer.FindElement(By.CssSelector("button"));
            allocationlinefilter.Click();
            Thread.Sleep(2000);
            IWebElement selectfilteroption = filtercontainer.FindElement(By.CssSelector("label"));
            string providertypeselected = selectfilteroption.Text;
            Console.WriteLine("Allocation Line Filter Option selected = " + providertypeselected);
            selectfilteroption.Click();
            Thread.Sleep(2000);
            allocationlinefilter.Click();
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
