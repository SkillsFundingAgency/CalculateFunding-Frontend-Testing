using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests.Pages.View_Results
{
    public class ViewProviderAllocationsPage
    {
        public ViewProviderAllocationsPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.Id, Using = "nav-allocations-tab")]
        public IWebElement providerAllocationsPageNavigationTab { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".col-xs-9")]
        public IWebElement providerAllocationsPageProviderInfoContainer { get; set; }

        [FindsBy(How = How.Id, Using = "PeriodId")]
        public IWebElement providerAllocationsPageAcademicYearDropDown { get; set; }

        [FindsBy(How = How.Id, Using = "SpecificationId")]
        public IWebElement providerAllocationsPageSpecificationDropDown { get; set; }

        [FindsBy(How = How.Id, Using = "nav-allocations-tab")]
        public IWebElement providerAllocationsPageAllocationTab { get; set; }

        [FindsBy(How = How.Id, Using = "nav-calculations-tab")]
        public IWebElement providerAllocationsPageCalculationTab { get; set; }

        [FindsBy(How = How.Id, Using = "nav-test-results-tab")]
        public IWebElement providerAllocationsPageTestTab { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".view-policy")]
        public IWebElement providerAllocationsPageProviderPolicyContainer { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.provider-test-scenario-searchresult-container:nth-child(3)")]
        public IWebElement providerAllocationsPageTestTabSearchResultsContainer { get; set; }



    }
}
