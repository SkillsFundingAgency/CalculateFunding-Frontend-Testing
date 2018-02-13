using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests.Pages.Manage_Calculation
{
    public class EditCalculationsPage
    {
        public EditCalculationsPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "div.spacing-30:nth-child(4) > input:nth-child(1)")]
        public IWebElement BuildCalculationButton { get; set; }





    }
}
