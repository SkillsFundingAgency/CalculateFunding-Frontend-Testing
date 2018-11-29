using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests.Pages.Manage_Datasets
{
    public class SelectedSpecificationDataSourcePage
    {
        public SelectedSpecificationDataSourcePage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "head > title:nth-child(6)")]
        public IWebElement specificationDataSourcePageTitle { get; set; }

        [FindsBy(How = How.Id, Using = "noDatasourceMappedMessage")]
        public IWebElement specificationNoDataSourceMappedMessage { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".heading-small")]
        public IWebElement specificationNoDataSourceMappedHowToMessage { get; set; }

        [FindsBy(How = How.Id, Using = "noDatasourceMappedHowToSteps")]
        public IWebElement specificationNoDataSourceMappedHowToSteps { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".dataset-name-holder")]
        public IWebElement specificationFirstDatasetName { get; set; }

        [FindsBy(How = How.Id, Using = "datasourceCount")]
        public IWebElement specificationDataSourceCount { get; set; }

        [FindsBy(How = How.LinkText, Using = "Map data source file")]
        public IWebElement specificationDataSourceMissing { get; set; }

        [FindsBy(How = How.LinkText, Using = "Change data source file")]
        public IWebElement specificationChangeDataSource { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".alert")]
        public IWebElement specificationDataSourceAddedAlert { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".alert > span:nth-child(1)")]
        public IWebElement specificationDataSourceAddedAlertText { get; set; }

        [FindsBy(How = How.Id, Using = "dismiss-link")]
        public IWebElement specificationDataSourceDismissAlert { get; set; }

        [FindsBy(How = How.Id, Using = "datasets-table")]
        public IWebElement specificationDataSourceDatasetTableContainer { get; set; }

        [FindsBy(How = How.Id, Using = "dataset-header-column")]
        public IWebElement specificationDataSourceDatasetTableDatasetHeader { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#datasets-table > thead:nth-child(1) > tr:nth-child(1) > th:nth-child(2)")]
        public IWebElement specificationDataSourceDatasetTableDataSourceHeader { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".dataset-isprovider-text")]
        public IWebElement specificationDataSourceDatasetTableIsProviderData { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".button-split-icon")]
        public IWebElement specificationDataSourceDatasetTableEditDataSource { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = ".expander-trigger-cell")]
        public IWebElement specificationDataSourceDatasetTableExpandInfo { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".button-split-container > span:nth-child(2)")]
        public IWebElement specificationDataSourceDatasetTableMappedFileName { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".expander-container")]
        public IWebElement specificationDataSourceDatasetTableDisplayExpandedInfo { get; set; }
        



    }
}
