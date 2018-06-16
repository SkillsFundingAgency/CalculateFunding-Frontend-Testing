using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests.Pages.Manage_Calculation
{
    public class ManageCalculationPage
    {
        public ManageCalculationPage()
        { 
        PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.Id, Using = "SearchTerm")]
        public IWebElement CalculationSearchField { get; set; }

        [FindsBy(How = How.Id, Using = "filter-search-button-image")]
        public IWebElement CalculationSearchButton { get; set; }

        [FindsBy(How = How.Id, Using = "dynamic-results-table-body")]
        public IWebElement CalculationResultsList { get; set; }

        [FindsBy(How = How.Id, Using = "allocationLines")]
        public IWebElement AllocationDropDown { get; set; }

        [FindsBy(How = How.Id, Using = "periods")]
        public IWebElement AcademicYearDropDown { get; set; }

        [FindsBy(How = How.Id, Using = "fundingStreams")]
        public IWebElement FundingStreamDropDown { get; set; }

        [FindsBy(How = How.Id, Using = "specifications")]
        public IWebElement SpecificationsDropDown { get; set; }

        [FindsBy(How = How.Id, Using = "calculationStatus")]
        public IWebElement CalculationStatusDropDown { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#dynamic-results-table-body > tr:nth-child(1) > td:nth-child(1) > a:nth-child(1)")]
        public IWebElement FirstCalculationListed { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#totalResultsCount")]
        public IWebElement CalculationsTotalResults { get; set; }

        [FindsBy(How = How.Id, Using = "endItemNumber")]
        public IWebElement CalculationsPageTotal { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#dynamic-rownavigation-container > span:nth-child(2)")]
        public IWebElement CalculationsFirstResult { get; set; }

        [FindsBy(How = How.Id, Using = "dynamic-paging-container")]
        public IWebElement CalculationPaginationOptions { get; set; }

        [FindsBy(How = How.LinkText, Using = "Select specification name")]
        public IWebElement SpecNameDropDownDefault { get; set; }

        [FindsBy(How = How.LinkText, Using = "Select Allocation Line")]
        public IWebElement AllocationLineDropDownDefault { get; set; }

        [FindsBy(How = How.LinkText, Using = "Select year")]
        public IWebElement AcademicYearDropDownDefault { get; set; }

        [FindsBy(How = How.LinkText, Using = "Select funding stream")]
        public IWebElement FundingStreamDropDownDefault { get; set; }

        [FindsBy(How = How.LinkText, Using = "Show all status")]
        public IWebElement CalculationStatusDropDownDefault { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".material-icons")]
        public IWebElement RemoveCalculationFilter { get; set; }

        [FindsBy(How = How.ClassName, Using = "filter-selected-item")]
        public IWebElement CalculationFilterBox { get; set; }
        



    }
}
