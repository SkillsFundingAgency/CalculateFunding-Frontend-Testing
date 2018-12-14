using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests.Pages.View_Results
{
    public class ViewQATestResultsPage
    {
        public ViewQATestResultsPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.Id, Using = "SearchTerm")]
        public IWebElement viewQATestResultspageSearch { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".search-button")]
        public IWebElement viewQATestResultspageSearchButton { get; set; }
        
        [FindsBy(How = How.Id, Using = "FundingPeriodId")]
        public IWebElement viewQATestResultspageYearDropDown { get; set; }

        [FindsBy(How = How.Id, Using = "SpecificationId")]
        public IWebElement viewQATestResultspageSpecificationDropDown { get; set; }

        [FindsBy(How = How.Id, Using = "calculation-results-table")]
        public IWebElement viewQATestResultspageQATestResultList { get; set; }

        [FindsBy(How = How.Id, Using = "dynamic-results-table-body")]
        public IWebElement viewQATestResultspageQATestResultTable { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#dynamic-rownavigation-container > span:nth-child(2)")]
        public IWebElement viewQATestResultspagestartItemNumber { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#dynamic-rownavigation-container > span:nth-child(3)")]
        public IWebElement viewQATestResultspageendItemNumber { get; set; }

        [FindsBy(How = How.Id, Using = "totalResultsCount")]
        public IWebElement viewQATestResultspagetotalResults { get; set; }


    }
}
