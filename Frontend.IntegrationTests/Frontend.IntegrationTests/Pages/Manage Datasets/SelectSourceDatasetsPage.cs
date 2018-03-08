using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests.Pages.Manage_Datasets
{
    public class SelectSourceDatasetsPage
    {
        public SelectSourceDatasetsPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".hero-text")]
        public IWebElement selectSourceDatasetSpecName { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".hero-title")]
        public IWebElement selectSourceDatasetSchemaRelationshipName { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".ds-container")]
        public IWebElement selectSourceDatasetList { get; set; }

        [FindsBy(How = How.Id, Using = "save-button")]
        public IWebElement selectSourceDatasetSaveButton { get; set; }

        [FindsBy(How = How.Id, Using = "cancel-link")]
        public IWebElement selectSourceDatasetCancelLink { get; set; }



    }
}
