using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests.Pages.Manage_Datasets
{
    public class SpecifyDatasetRelationshipsPage
    {
        public SpecifyDatasetRelationshipsPage()
        { 
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.Id, Using = "SearchTerm")]
        public IWebElement specifyDatasetSearchField { get; set; }

        [FindsBy(How = How.Id, Using = "filter-search-button-image")]
        public IWebElement specifyDatasetSearchButton { get; set; }

        [FindsBy(How = How.Id, Using = "select-spec-period")]
        public IWebElement specifyDatasetFilterByYearDropDown { get; set; }


    }
}
