using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests.Pages.View_Results
{
    public class ViewTestResultsAllProvidersSingleTest
    {
        public ViewTestResultsAllProvidersSingleTest()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.Id, Using = "SearchTerm")]
        public IWebElement singleTestProviderResultsSearchField { get; set; }

        [FindsBy(How = How.Id, Using = "filter-search-button-image")]
        public IWebElement singleTestProviderResultsSearchButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.row:nth-child(4) > div:nth-child(1) > div:nth-child(2) > button:nth-child(1)")]
        public IWebElement singleTestProviderResultsSelectProviderType { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.row:nth-child(4) > div:nth-child(2) > div:nth-child(2) > button:nth-child(1)")]
        public IWebElement singleTestProviderResultsSelectProviderSubType { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.row:nth-child(4) > div:nth-child(3) > div:nth-child(2) > button:nth-child(1)")]
        public IWebElement singleTestProviderResultsSelectLocalAuthority { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".alert")]
        public IWebElement singleTestProviderResultsQATestInfo { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.col-xs-12:nth-child(4) > div:nth-child(3)")]
        public IWebElement singleTestProviderResultsProviderResultsList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.providers-searchresult-container:nth-child(1) > div:nth-child(1)")]
        public IWebElement singleTestProviderResultsProviderResultsListContainer { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#dynamic-rownavigation-container > span:nth-child(2)")]
        public IWebElement singleTestProviderResultsProviderListStartCount { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#dynamic-rownavigation-container > span:nth-child(3)")]
        public IWebElement singleTestProviderResultsProviderListEndCount { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#dynamic-rownavigation-container > strong:nth-child(4)")]
        public IWebElement singleTestProviderResultsProviderListTotalCount { get; set; }
    }
}
