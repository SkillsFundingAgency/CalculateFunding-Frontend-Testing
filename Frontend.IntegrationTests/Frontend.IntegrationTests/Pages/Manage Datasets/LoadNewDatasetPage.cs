using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests.Pages.Manage_Datasets
{
    public class LoadNewDatasetPage
    {
        public LoadNewDatasetPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".select2-selection")]
        public IWebElement loadDataSetsSelectSchema { get; set; }

        [FindsBy(How = How.Id, Using = "CreateDatasetViewModel-Name")]
        public IWebElement loadDatasetName { get; set; }

        [FindsBy(How = How.Id, Using = "description")]
        public IWebElement loadDatasetDescription { get; set; }

        [FindsBy(How = How.Id, Using = ".btn")]
        public IWebElement loadDatasetUploadBrowseButton { get; set; }

        [FindsBy(How = How.Id, Using = "save-button")]
        public IWebElement loadDatasetUploadButton { get; set; }

        [FindsBy(How = How.Id, Using = "cancelLink")]
        public IWebElement loadDatasetCancelLink { get; set; }

        [FindsBy(How = How.Id, Using = "backLink")]
        public IWebElement loadDatasetBackLink { get; set; }







    }
}
