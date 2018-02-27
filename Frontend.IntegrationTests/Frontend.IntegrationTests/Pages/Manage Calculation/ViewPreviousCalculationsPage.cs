using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests.Pages.Manage_Calculation
{
    public class ViewPreviousCalculationsPage
    {
        public ViewPreviousCalculationsPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.Id, Using = "compare-button")]
        public IWebElement ComparePreviousCalculationsButton { get; set; }

        [FindsBy(How = How.Id, Using = "back-link")]
        public IWebElement ComparePreviousCalculationsBackLink { get; set; }

        [FindsBy(How = How.Id, Using = "calculation-version-compare-checkbox-0")]
        public IWebElement CompareFirstCheckBox { get; set; }

        [FindsBy(How = How.Id, Using = "calculation-version-compare-checkbox-1")]
        public IWebElement CompareSecondCheckBox { get; set; }

        [FindsBy(How = How.Id, Using = "calculation-version-compare-checkbox-2")]
        public IWebElement CompareThirdCheckBox { get; set; }

        [FindsBy(How = How.Id, Using = "calculation-version-compare-checkbox-3")]
        public IWebElement CompareFourthCheckBox { get; set; }

        [FindsBy(How = How.CssSelector, Using = "span.calculation-author")]
        public IWebElement CalculationVersionAuthor { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".calculation-Updated")]
        public IWebElement CalculationVersionUpdatedDate { get; set; }

        [FindsBy(How = How.CssSelector, Using = "span.calculation-version")]
        public IWebElement CalculationVersionId { get; set; }

        [FindsBy(How = How.CssSelector, Using = "span.calculation-status")]
        public IWebElement CalculationVersionStatus { get; set; }










    }
}
