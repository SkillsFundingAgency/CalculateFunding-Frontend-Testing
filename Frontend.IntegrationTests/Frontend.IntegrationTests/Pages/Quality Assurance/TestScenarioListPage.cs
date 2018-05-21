using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests.Pages.Quality_Assurance
{
    public class TestScenarioListPage
    {
        public TestScenarioListPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.Id, Using = "SearchTerm")]
        public IWebElement testScenarioPageSearchField { get; set; }

        [FindsBy(How = How.Id, Using = "filter-search-button-image")]
        public IWebElement testScenarioPageSearchButton { get; set; }

        [FindsBy(How = How.Id, Using = "createQATestButton")]
        public IWebElement testScenarioPageCreateQATestButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#dynamic-rownavigation-container > span:nth-child(2)")]
        public IWebElement testScenarioPageFirstResultCount { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#dynamic-rownavigation-container > span:nth-child(3)")]
        public IWebElement testScenarioPageLastResultCount { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#dynamic-rownavigation-container > strong:nth-child(4)")]
        public IWebElement testScenarioPageTotalResultCount { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.test-scenario-searchresult-container:nth-child(3)")]
        public IWebElement testScenarioPageScenarioListContainer { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.test-scenario-searchresult-container:nth-child(3) > div:nth-child(1) > div:nth-child(1)")]
        public IWebElement testScenarioPageFirstTestScenarioContainer { get; set; }

        [FindsBy(How = How.Id, Using = "specification-link-dynamic-0")]
        public IWebElement testScenarioPageFirstTestScenarioName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.test-scenario-searchresult-container:nth-child(3) > div:nth-child(1) > div:nth-child(1) > div:nth-child(2) > span:nth-child(1)")]
        public IWebElement testScenarioPageFirstTestScenarioDescription { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.test-scenario-searchresult-container:nth-child(3) > div:nth-child(1) > div:nth-child(1) > div:nth-child(3) > span:nth-child(1) > strong:nth-child(1) > span:nth-child(1)")]
        public IWebElement testScenarioPageFirstTestScenarioSpecification { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.test-scenario-searchresult-container:nth-child(3) > div:nth-child(1) > div:nth-child(1) > div:nth-child(4) > span:nth-child(1) > strong:nth-child(1) > span:nth-child(1)")]
        public IWebElement testScenarioPageFirstTestScenarioStatus { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.test-scenario-searchresult-container:nth-child(3) > div:nth-child(1) > div:nth-child(1) > div:nth-child(4) > span:nth-child(2) > strong:nth-child(1) > span:nth-child(1)")]
        public IWebElement testScenarioPageFirstTestScenarioLastUpdated { get; set; }


    }
}
