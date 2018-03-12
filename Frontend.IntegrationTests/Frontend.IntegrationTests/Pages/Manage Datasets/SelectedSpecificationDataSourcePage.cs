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

        [FindsBy(How = How.CssSelector, Using = "div.spec-rel-grey-back:nth-child(2) > h2:nth-child(1)")]
        public IWebElement specificationFirstDataSourceSchemaName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.spec-rel-grey-back:nth-child(2) > h4:nth-child(2)")]
        public IWebElement specificationFirstDatasetName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.spec-rel-grey-back:nth-child(2) > p:nth-child(3)")]
        public IWebElement specificationFirstDatasetDescription { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#top > main:nth-child(4) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > p:nth-child(1)")]
        public IWebElement specificationDataSourceCount { get; set; }

        [FindsBy(How = How.LinkText, Using = "Select source dataset")]
        public IWebElement specificationDataSourceMissing { get; set; }

        [FindsBy(How = How.LinkText, Using = "Change source dataset")]
        public IWebElement specificationChangeDataSource { get; set; }


    }
}
