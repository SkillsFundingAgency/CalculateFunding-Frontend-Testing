using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests.Pages.Manage_Specification
{
    public class ViewSpecificationDatasets
    {
        public ViewSpecificationDatasets()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.Id, Using = "datasets-table")]
        public IWebElement datasetsTableContainer { get; set; }

        [FindsBy(How = How.Id, Using = "static-results-table-body")]
        public IWebElement datasetsResultsContainer { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".expander-trigger-cell > i:nth-child(1)")]
        public IWebElement datasetsResultsMoreInfoExpander { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".datsets-provider-data-notification-text")]
        public IWebElement datasetsResultsProviderDataAlert { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".expander-container")]
        public IWebElement datasetsResultsExpanderResultsContainer { get; set; }





    }
}
