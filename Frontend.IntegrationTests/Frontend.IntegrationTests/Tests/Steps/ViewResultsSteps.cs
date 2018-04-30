﻿using System;
using System.Collections.Generic;
using System.Globalization;
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
        ViewProviderResultsPage viewproviderresultspage = new ViewProviderResultsPage();
        ViewProviderAllocationsPage viewproviderallocationspage = new ViewProviderAllocationsPage();
        ViewResultsOptionsPage viewresultsoptionspage = new ViewResultsOptionsPage();
        ViewQATestResultsPage viewqatestresultspage = new ViewQATestResultsPage();

        public string searchtext = "Primary";

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
            Console.WriteLine(providername);

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
            IWebElement newyearselected = academicyeardropdown.FindElement(By.CssSelector("#PeriodId > option:nth-child(3)"));
            newyearselected.Should().NotBeNull();
            newyearselected.Click();
            Thread.Sleep(2000);
            academicyeardropdown = viewproviderallocationspage.providerAllocationsPageAcademicYearDropDown;
            academicyeardropdown.Should().NotBeNull();
            academicyeardropdown.Displayed.Should().BeTrue();
            newyearselected = academicyeardropdown.FindElement(By.CssSelector("#PeriodId > option:nth-child(3)"));
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
