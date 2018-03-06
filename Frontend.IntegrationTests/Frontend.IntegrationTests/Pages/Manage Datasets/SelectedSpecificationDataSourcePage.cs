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


    }
}
