using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests.Pages.Manage_Datasets
{
   public class UpdateDatasetPage
    {
        public UpdateDatasetPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.Id, Using = "description")]
        public IWebElement updateDataSetDescription { get; set; }

        [FindsBy(How = How.Id, Using = "comment")]
        public IWebElement updateDataSetChangeNote { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".hero-description")]
        public IWebElement updateDataSetNameVersion { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".hero-spacing-right")]
        public IWebElement updateDataSetUser { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".hero-text > span:nth-child(2)")]
        public IWebElement updateDataSetLastUpdated { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".btn")]
        public IWebElement updateDataSetBrowseButton { get; set; }

        [FindsBy(How = How.Id, Using = "cancelLink")]
        public IWebElement updateDataSetCancelLink { get; set; }

        [FindsBy(How = How.Id, Using = "save-button")]
        public IWebElement updateDataSetUpdateButton { get; set; }




    }
}
