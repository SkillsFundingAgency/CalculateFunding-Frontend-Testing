using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests.Pages.Manage_Datasets
{
    public class ManageDatasetsPage
    {
        public ManageDatasetsPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.Id, Using = "SearchTerm")]
        public IWebElement manageDataSetsSearchField { get; set; }

        [FindsBy(How = How.Id, Using = "filter-search-button-image")]
        public IWebElement manageDataSetsSearchButton { get; set; }        

        [FindsBy(How = How.CssSelector, Using = "div.row:nth-child(5) > div:nth-child(1) > div:nth-child(2) > button:nth-child(1)")]
        public IWebElement manageDataSetsDataSchemaDropDown { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.row:nth-child(5) > div:nth-child(2) > div:nth-child(2) > button:nth-child(1)")]
        public IWebElement manageDataSetsSpecificationDropDown { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.row:nth-child(5) > div:nth-child(3) > div:nth-child(2) > button:nth-child(1)")]
        public IWebElement manageDataSetsYearDropDown { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.row:nth-child(5) > div:nth-child(4) > div:nth-child(2) > button:nth-child(1)")]
        public IWebElement manageDataSetsStatusDropDown { get; set; }

        [FindsBy(How = How.Id, Using = "loadNewDatasourcefileButton")]
        public IWebElement loadNewDatasetsButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.col-xs-12:nth-child(2) > div:nth-child(2)")]
        public IWebElement manageDatasetsListView { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.dataset-searchresult-container:nth-child(1) > div:nth-child(1) > div:nth-child(3) > span:nth-child(2) > span:nth-child(2)")]
        public IWebElement manageDatasetsFirstResultLastUpdated { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.dataset-searchresult-container:nth-child(1) > div:nth-child(2) > div:nth-child(3) > span:nth-child(2) > span:nth-child(2)")]
        public IWebElement manageDatasetsSecondResultLastUpdated { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.dataset-searchresult-container:nth-child(1) > div:nth-child(1) > div:nth-child(1)")]
        public IWebElement manageDatasetsFirstResultName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.dataset-searchresult-container:nth-child(1) > div:nth-child(1) > div:nth-child(2) > span:nth-child(1) > span:nth-child(2)")]
        public IWebElement manageDatasetsFirstResultStatus { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#dynamic-rowcount-container > span:nth-child(2)")]
        public IWebElement manageDatasetsEndListItemCount { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#dynamic-rownavigation-container > span:nth-child(2)")]
        public IWebElement manageDatasetsFirstListItemCount { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#totalResultsCount")]
        public IWebElement manageDatasetsTotalResultCount { get; set; }

        [FindsBy(How = How.LinkText, Using = "Download")]
        public IWebElement manageDatasetsDownloadLink { get; set; }

        [FindsBy(How = How.LinkText, Using = "Update")]
        public IWebElement manageDatasetsUpdateLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#dynamic-results-table-body > tr:nth-child(1) > td:nth-child(1) > span:nth-child(1) > span:nth-child(2) > span:nth-child(1)")]
        public IWebElement firstDatasourceName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#dynamic-results-table-body > tr:nth-child(1) > td:nth-child(2) > span:nth-child(1)")]
        public IWebElement firstDatasourceUpdatedDate { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#dynamic-results-table-body > tr:nth-child(1) > td:nth-child(1) > span:nth-child(1) > span:nth-child(1) > a:nth-child(1)")]
        public IWebElement firstDatasourceEditOption { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#dynamic-results-table-body > tr:nth-child(1) > td:nth-child(3) > a:nth-child(1) > i:nth-child(1)")]
        public IWebElement firstDatasourceDownloadOption { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#dynamic-results-table-body > tr:nth-child(1) > td:nth-child(4) > i:nth-child(1)")]
        public IWebElement firstDatasourceExpandOption { get; set; }

                [FindsBy(How = How.CssSelector, Using = "tr.expander-container:nth-child(2) > td:nth-child(1)")]
        public IWebElement firstDatasourceExpandedInfo { get; set; }


    }
}
