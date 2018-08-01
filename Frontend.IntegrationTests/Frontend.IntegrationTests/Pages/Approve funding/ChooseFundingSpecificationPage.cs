using AutoFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Frontend.IntegrationTests.Pages.Approve_funding
{
    public class ChooseFundingSpecificationPage
    {
        public ChooseFundingSpecificationPage()
        {
            PageFactory.InitElements(Driver._driver, this);
        }

        [FindsBy(How = How.Id, Using = "fundingPeriod")]
        public IWebElement chooseFundingSpecFundingPeriodDropdown { get; set; }

        [FindsBy(How = How.Id, Using = "fundingStream")]
        public IWebElement chooseFundingSpecFundingStreamDropdown { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".cf")]
        public IWebElement chooseFundingSpecContainer { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".cf > tbody:nth-child(2)")]
        public IWebElement chooseFundingSpecTableBody { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".noresults-panel")]
        public IWebElement chooseFundingSpecNoResultsPanel { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#fundingPeriod > option:nth-child(1)")]
        public IWebElement chooseFundingSpecDefaultFundingPeriod { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".cf > tbody:nth-child(2) > tr:nth-child(1) > td:nth-child(1) > span:nth-child(1)")]
        public IWebElement chooseFundingSpecFirstSpecName { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".cf > tbody:nth-child(2) > tr:nth-child(1) > td:nth-child(2) > span:nth-child(1)")]
        public IWebElement chooseFundingSpecFirstSpecFundingValue { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".cf > tbody:nth-child(2) > tr:nth-child(1) > td:nth-child(3)")]
        public IWebElement chooseFundingSpecFirstSpecStatus { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".cf > tbody:nth-child(2) > tr:nth-child(1) > td:nth-child(4)")]
        public IWebElement chooseFundingSpecFirstSpecQACoverage { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".cf > tbody:nth-child(2) > tr:nth-child(1) > td:nth-child(5)")]
        public IWebElement chooseFundingSpecFirstSpecQATests { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".cf > tbody:nth-child(2) > tr:nth-child(1) > td:nth-child(6)")]
        public IWebElement chooseFundingSpecFirstSpecCalcs { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".cf > tbody:nth-child(2) > tr:nth-child(1) > td:nth-child(7) > a:nth-child(1)")]
        public IWebElement chooseFundingSpecFirstActionButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".cf > tbody:nth-child(2) > tr:nth-child(2) > td:nth-child(1) > div:nth-child(1)")]
        public IWebElement chooseFundingSpecFirstFundingStream { get; set; }

        [FindsBy(How = How.LinkText, Using = "View funding")]
        public IWebElement chooseFundingViewFundingLink { get; set; }











    }
}
