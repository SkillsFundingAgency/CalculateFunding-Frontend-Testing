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

        [FindsBy(How = How.XPath, Using = "/html/body/main/div/div/div[3]/div[1]/div[2]/strong")]
        public IWebElement CalculationsTotalResults { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/main/div/div/div[3]/div[1]/div[2]/span[2]")]
        public IWebElement CalculationsPageTotal { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/main/div/div/div[3]/div[1]/div[2]/span[1]")]
        public IWebElement CalculationsFirstResult { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#dynamic-paging-container > span:nth-child(2) > a:nth-child(4) > span:nth-child(1)")]
        public IWebElement CalculationsPaginationPage2 { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a.paging-link:nth-child(6) > span:nth-child(1)")]
        public IWebElement CalculationsPaginationPage3 { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a.paging-link:nth-child(8) > span:nth-child(1)")]
        public IWebElement CalculationsPaginationPage4 { get; set; }

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
