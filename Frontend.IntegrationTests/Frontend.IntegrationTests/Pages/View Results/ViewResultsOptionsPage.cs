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

        [FindsBy(How = How.LinkText, Using = "View provider results")]
        public IWebElement viewResultsOptionsViewProviderResults { get; set; }

        [FindsBy(How = How.LinkText, Using = "View QA test results")]
        public IWebElement viewResultsOptionsViewQATestResults { get; set; }

        [FindsBy(How = How.LinkText, Using = "View calculation results")]
        public IWebElement viewResultsOptionsViewCalculationResults { get; set; }


    }
}
