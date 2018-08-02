using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests.Pages.Manage_Datasets
{
    public class DownloadDataSchemasPage
    {
        public DownloadDataSchemasPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.Id, Using = "SearchTerm")]
        public IWebElement searchDataSchemaTemplateField { get; set; }

        [FindsBy(How = How.Id, Using = "filter-search-button-image")]
        public IWebElement searchDataSchemaTemplateButton { get; set; }

        [FindsBy(How = How.LinkText, Using = "Download change request form")]
        public IWebElement downloadChangeRequestFormLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#dynamic-rowcount-container > span:nth-child(1)")]
        public IWebElement searchDataSchemaTemplatePageCountStart { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#dynamic-rowcount-container > span:nth-child(2)")]
        public IWebElement searchDataSchemaTemplatePageCountEnd { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#totalResultsCount")]
        public IWebElement searchDataSchemaTemplatePageTotalCount { get; set; }

        [FindsBy(How = How.Id, Using = "datasetDefinitions-table")]
        public IWebElement searchDataSchemaTemplateDatasetDefinitionsTable { get; set; }

        [FindsBy(How = How.Id, Using = "dynamic-results-table-body")]
        public IWebElement searchDataSchemaTemplateDatasetDefinitionsTableBody { get; set; }

    }
}
