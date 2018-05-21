using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests.Pages.View_Results
{
    public class ViewCalculationResultPage
    {
        public ViewCalculationResultPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.Id, Using = "SearchTerm")]
        public IWebElement viewcalculationPageSearchField { get; set; }

        [FindsBy(How = How.Id, Using = "filter-search-button-image")]
        public IWebElement viewcalculationPageSearchButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.row:nth-child(4) > div:nth-child(1) > div:nth-child(2)")]
        public IWebElement viewcalculationPageFundingPeriodDropDown { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.row:nth-child(4) > div:nth-child(2) > div:nth-child(2)")]
        public IWebElement viewcalculationPageFundingStreamDropDown { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.row:nth-child(4) > div:nth-child(3) > div:nth-child(2)")]
        public IWebElement viewcalculationPageSpecnameDropDown { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#filter-container > div:nth-child(2) > div:nth-child(2) > div:nth-child(2)")]
        public IWebElement viewcalculationPageAllocationLineDropDown { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.row:nth-child(4) > div:nth-child(4) > div:nth-child(2)")]
        public IWebElement viewcalculationPageCalculationStatusDropDown { get; set; }

        [FindsBy(How = How.Id, Using = "calculation-results-table")]
        public IWebElement viewcalculationPageCalculationResultsTable { get; set; }

        [FindsBy(How = How.Id, Using = "dynamic-results-table-body")]
        public IWebElement viewcalculationPageCalculationResultsListContainer { get; set; }

        [FindsBy(How = How.Id, Using = "startItemNumber")]
        public IWebElement viewcalculationPageStartItemCount { get; set; }

        [FindsBy(How = How.Id, Using = "endItemNumber")]
        public IWebElement viewcalculationPageEndItemCount { get; set; }

        [FindsBy(How = How.Id, Using = "totalResultsCount")]
        public IWebElement viewcalculationPageTotalResultcount { get; set; }

    }
}
