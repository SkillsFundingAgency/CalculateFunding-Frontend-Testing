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

    }
}
