using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests.Pages.View_Results
{
    public class ViewResultsOptionsPage
    {
        public ViewResultsOptionsPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "div.col-sm-4:nth-child(1) > div:nth-child(1) > a:nth-child(1)")]
        public IWebElement viewResultsOptionsViewProviderResults { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.col-xs-12:nth-child(2) > div:nth-child(1) > a:nth-child(1)")]
        public IWebElement viewResultsOptionsViewQATestResults { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.col-xs-12:nth-child(3) > div:nth-child(1) > a:nth-child(1)")]
        public IWebElement viewResultsOptionsViewCalculationResults { get; set; }


    }
}
