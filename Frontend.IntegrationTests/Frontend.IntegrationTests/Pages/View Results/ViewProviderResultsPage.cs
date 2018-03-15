using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests.Pages.View_Results
{
    public class ViewProviderResultsPage
    {
        public ViewProviderResultsPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.Id, Using = "SearchTerm")]
        public IWebElement providerResultspageSearch { get; set; }

        [FindsBy(How = How.Id, Using = "filter-search-button-image")]
        public IWebElement providerResultspageSearchButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.row:nth-child(4) > div:nth-child(1) > div:nth-child(2) > button:nth-child(1)")]
        public IWebElement providerResultspageProviderDropDown { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.row:nth-child(4) > div:nth-child(2) > div:nth-child(2) > button:nth-child(1)")]
        public IWebElement providerResultspageProviderSubTypeDropDown { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.row:nth-child(4) > div:nth-child(3) > div:nth-child(2) > button:nth-child(1)")]
        public IWebElement providerResultspageLocalAuthorityDropDown { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.providers-searchresult-container:nth-child(1)")]
        public IWebElement providerResultspageResultListContainer { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.providers-searchresult-container:nth-child(1) > div:nth-child(1)")]
        public IWebElement providerResultspageProviderItemContainer { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#dynamic-rownavigation-container > span:nth-child(2)")]
        public IWebElement providerResultsPageFirstResult { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#dynamic-rownavigation-container > span:nth-child(3)")]
        public IWebElement providerResultsPageLastResult { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#dynamic-rownavigation-container > strong:nth-child(4)")]
        public IWebElement providerResultsPageTotalResult { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#dynamic-paging-container > a:nth-child(3)")]
        public IWebElement providerResultsPageNextSetPagination { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a.paging-link:nth-child(1)")]
        public IWebElement providerResultsPagePreviousSetPagination { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.row:nth-child(4)")]
        public IWebElement providerResultsPageFilterContainer { get; set; }


    }
}
