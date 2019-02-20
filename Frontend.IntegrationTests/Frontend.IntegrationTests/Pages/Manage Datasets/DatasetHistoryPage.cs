using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests.Pages.Manage_Datasets
{
    public class DatasetHistoryPage
    {
        public DatasetHistoryPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.Id, Using = "datasource-history-page")]
        public IWebElement datasethistoryContainer { get; set; }

        [FindsBy(How = How.Id, Using = "back-link")]
        public IWebElement datasethistoryBackLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".cf")]
        public IWebElement datasethistoryTableContainer { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".hero-description-skinny")]
        public IWebElement datasethistoryName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#datasource-history-page > div:nth-child(1) > h3:nth-child(4)")]
        public IWebElement datasethistoryDescription { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#datasource-history-page > div:nth-child(1) > h3:nth-child(6)")]
        public IWebElement datasethistoryDataSchema { get; set; }


    }
}
