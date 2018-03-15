using System;
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

        public string searchtext = "Primary";


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
            IWebElement providernameexists = providerresultslistcontainer.FindElement(By.CssSelector("h4.heading-small"));
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

            for(int i = 0; i < propertyElementList.Count; i++)
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
            Thread.Sleep(2000);
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
