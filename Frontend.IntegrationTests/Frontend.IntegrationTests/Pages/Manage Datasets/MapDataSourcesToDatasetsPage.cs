using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests.Pages.Manage_Datasets
{
   public class MapDataSourcesToDatasetsPage
    {
        public MapDataSourcesToDatasetsPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.Id, Using = "SearchTerm")]
        public IWebElement mapDataSourcesSearchTermField { get; set; }

        [FindsBy(How = How.Id, Using = "filter-search-button-image")]
        public IWebElement mapDataSourcesSearchTermButton { get; set; }

        [FindsBy(How = How.Id, Using = "select-spec-period")]
        public IWebElement mapDataSourcesSpecficationYearDropDown { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#dynamic-rownavigation-container > strong:nth-child(4)")]
        public IWebElement mapDataSourcesTotalSpecificationsListed { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#dynamic-rownavigation-container > span:nth-child(2)")]
        public IWebElement mapDataSourcesFirstSpecificationsListed { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#dynamic-rownavigation-container > span:nth-child(3)")]
        public IWebElement mapDataSourcesLastSpecificationsListed { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#dynamic-paging-container > span:nth-child(2) > span:nth-child(1)")]
        public IWebElement mapDataSounrcesFirstPage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a.paging-link:nth-child(4) > span:nth-child(1)")]
        public IWebElement mapDataSourcesSecondPage { get; set; }

        [FindsBy(How = How.ClassName, Using = "periodId")]
        public IWebElement mapDataSourcesSpecificationYearDropDownDefault { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#dynamic-results-container > div:nth-child(1) > h2:nth-child(1) > a:nth-child(1)")]
        public IWebElement mapDataSourcesFirstSpecificationName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#dynamic-results-container > div:nth-child(1) > p:nth-child(2)")]
        public IWebElement mapDataSourcesFirstSpecificationRelationships { get; set; }





    }
}
